// Robot Móvil con IA
// Equipo Dinamita
// Recibe 2 tipos de comandos por puerto serial: mover llantas y mover servo
// Envía contadores de encoders

// Este programa está modificado para simular los pulsos de los encoders.
// Entonces parecerá que se mueve a la perfección.
// El fin es probar el algoritmo programado en C# 
// aunque el hardware no funcione todavía.

// Historial de versiones
// v0.1 Mantiene motores girando en una dirección, muestra pulsos y lectura de distancia
// v0.2 ???
// v0.3 Envía conteo de pulsos y recibe comandos para movimiento
// v0.4 Corrección de bug en el que los motores no se detienen
// v0.4.1 Hacer que el servo rote continuamente
// v0.4.2 Calcular la posición meta usando el contador actual no la meta anterior
// v0.5 Interpreta 2 tipos de comandos: mover llantas y mover servo

// definición de pines
#define PIN_E1 8  //encoder 1
#define PIN_E2 9 //encoder 2
#define PIN_MI1 3  //motor izquierdo 1
#define PIN_MI2 4  //motor izquierdo 2
#define PIN_MD1 6  //motor derecho 1
#define PIN_MD2 5  //motor derecho 2
#define PIN_SHARP A0 //sensor sharp
#define PIN_SERVO A1 //servomotor

// crear objeto para el sensor Sharp
#include "Sharp.h"
Sharp sharp1(PIN_SHARP);

// crear objetos para encoders
#include "Encoder.h"
Encoder encoder1(PIN_E1);
Encoder encoder2(PIN_E2);

// crear objeto para el servo
#include <Servo.h>
Servo myservo;

// Variables globales
//int pos = 0; // posición del servo en grados (ya no se usa)
//int incre = 2; //incremento de posición del servo (ya no se usa)
int pos_final_servo = 0; //posición en grados
int pwm_i = 0; //pwm aplicado al motor izquierdo
int pwm_d = 0; //pwm aplicado al motor derecho
int delta_i = 0; //pulsos que debe sumar o restar el encoder izquierdo
int delta_d = 0; //pulsos que debe sumar o restar el encoder derecho
int meta_i = 0; //posición a la que debe llegar la rueda izquierda
int meta_d = 0; //posición a la que debe llegar la rueda derecha

// buffers para recibir valores por el puerto serial
// Los comandos son número enteros separados por coma,
// para indicar el final de la cadena se usa salto de línea (\n)
char buffer_entrada[8]; //buffer de entrada
byte buffer_pos = 0; //posición dentro del buffer
int  arr_int[4]; //para guardar valores convertidos a enteros
byte arr_pos = 0; //posición en el array de enteros

void setup() {
  // entradas para encoders
  pinMode(PIN_E1, INPUT);
  pinMode(PIN_E2, INPUT);

  // salidas para motores
  pinMode(PIN_MI1, OUTPUT); //izq 1
  pinMode(PIN_MI2, OUTPUT); //izq 2
  pinMode(PIN_MD1, OUTPUT); //der 1
  pinMode(PIN_MD2, OUTPUT); //der 2

  // asignar pin al servo
  myservo.attach(PIN_SERVO);
  myservo.write(0);

  // iniciar comunicación serial
  Serial.begin(9600);

  //debug
  //pinMode(13, OUTPUT);
  // inicializar encoders, en esta versión "truco", no se leen los encoders
  encoder1.e = 0; //digitalRead(PIN_E1); //estado actual del encoder
  encoder1.ePrev = 0; //encoder1.e; //estado previo igual al actual
  encoder2.e = 0; //digitalRead(PIN_E2); //estado actual del encoder
  encoder2.ePrev = 0; //encoder2.e; //estado previo igual al actual
  delay(300);
}

void loop() {
  // Recibir datos por puerto serial
  while (Serial.available() > 0) {//si hay datos disponibles
    char c = Serial.read(); //obtener 1 caracter

    if (c == '\n') { //si el caracter es salto de línea
      buffer_entrada[buffer_pos] = 0; //agregar null terminator
      buffer_pos = 0; //volver al inicio del buffer
      arr_pos = 0; //volver al inicio del array

      // se ha recibido una línea completa
      // ¿qué acción debe realizar el robot?
      // el buffer contiene ahora una letra, esa letra indica la acción
      switch (buffer_entrada[0])
      {
        case 'a': // mover llantas
          // asignar valores del array a variables delta y pwm
          delta_i = arr_int[0];
          delta_d = arr_int[1];
          pwm_i = arr_int[2];
          pwm_d = arr_int[3];

          // calcular posición meta
          meta_i = encoder1.cont + delta_i;
          meta_d = encoder2.cont + delta_d;
          break;

        case 'b': // mover servo
          pos_final_servo = arr_int[0];
          break;
      }
    }
    else if (c == ',') {//se el caracter es un separador
      buffer_entrada[buffer_pos] = 0; //agregar null terminator
      arr_int[arr_pos] = atoi(buffer_entrada); // convertir buffer a entero
      buffer_pos = 0; //volver al inicio del buffer
      arr_pos ++; //incrementar posición en array
    }
    else { //es un número o letra
      buffer_entrada[buffer_pos] = c; //agregar caracter al buffer
      buffer_pos ++; //incrementar posición
    }
  } //fin  while Serial.available

  // Simular movimiento de motor izquierdo
  if (delta_i < 0 and encoder1.cont > meta_i) {//reversa
    //analogWrite(PIN_MI1, 0);
    //analogWrite(PIN_MI2, pwm_i);
    encoder1.cont --; //restar al contador
  }
  else if (delta_i > 0 and encoder1.cont < meta_i) {//adelante
    //analogWrite(PIN_MI1, pwm_i);
    //analogWrite(PIN_MI2, 0);
    encoder1.cont ++; //sumar al contador
  }
  else {//detener motores
    //analogWrite(PIN_MI1, 0);
    //analogWrite(PIN_MI2, 0);
  }

  // Simular movimiento de motor derecho
  if (delta_d < 0 and encoder2.cont > meta_d) {//reversa
    //analogWrite(PIN_MD1, 0);
    //analogWrite(PIN_MD2, pwm_d);
    encoder2.cont --;
  }
  else if (delta_d > 0 and encoder2.cont < meta_d) {//adelante
    //analogWrite(PIN_MD1, pwm_d);
    //analogWrite(PIN_MD2, 0);
    encoder2.cont ++;
  }
  else {//detener motores
    //analogWrite(PIN_MD1, 0);
    //analogWrite(PIN_MD2, 0);
  }

  // NO Detectar pulsos en esta versión
  //encoder1.pulso( delta_i);
  //encoder2.pulso( delta_d);

  // rotar servo
  myservo.write(pos_final_servo); //mover servo a la nueva posición
  //pos += incre; //sumar incremento
  //myservo.write(pos / 10); //mover servo a la nueva posición
  //if ((pos <= 0) or (pos >= 1800)) { //si llega al limite
  //  incre *= -1; //incremento cambia de signo
  //}

  // Enviar información de encoders, servo y sensor
  // Valores separados por comas
  Serial.print(encoder1.cont);
  Serial.print(',');
  Serial.print(encoder2.cont);
  Serial.print(',');
  Serial.print(pos_final_servo);
  Serial.print(',');
  Serial.println(sharp1.distancia(10)); //aquí se mide la distancia

  delay(7); //retardo entre loops
}

// Fin del programa :)
