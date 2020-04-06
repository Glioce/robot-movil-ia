// Robot Móvil con IA
// Equipo Dinamita
// Puede recibir 6 comando por puerto serial
// 'A' avanza
// 'P' para
// 'I' izquierda
// 'D' derecha
// '1' rotar servo a la izquierda
// '2' rotar servo a la derecha

// definición de pines
#define PIN_E1 8  //encoder 1
#define PIN_E2 13 //encoder 2
#define PIN_MI1 4  //motor izquierdo 1
#define PIN_MI2 3  //motor izquierdo 2
#define PIN_MD1 4  //motor derecho 1
#define PIN_MD2 3  //motor derecho 2
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
int pos = 0; // posición del servo
int incre = 0; //incremento de posición del servo
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

  // iniciar comunicación serial
  Serial.begin(9600);

  //debug
  //pinMode(13, OUTPUT);
}

void loop() {
  while (Serial.available() > 0) {
    char c = Serial.read(); //obtener 1 caracter

    if (c == ',' or c == '\n') { //si hay un separador
      buffer_entrada[buffer_pos] = 0; //null terminator
      buffer_pos = 0; //volver al inicio

      // convertir a entero
      arr_int[arr_pos] = atoi(buffer_entrada);

      if (c == '\n') {//ultimo comando
        arr_pos = 0;

        //verficar conversión
        //if (arr_int[0] == 133 and arr_int[1] == 2 and arr_int[2] == 200 and arr_int[3] == 42) digitalWrite(13, 1);
        //if (arr_int[0] == -77) digitalWrite(13, 0);
        delta_i = arr_int[0];
        delta_d = arr_int[1];
        pwm_i = arr_int[2] * sign(delta_i);
        pwm_d = arr_int[3] * sign(delta_d);

        // calcular posición meta
        meta_i += delta_i;
        meta_d += delta_d;
      }
      else {
        arr_pos ++; //incrementar posición en array
      }
    }
    else { //si no es un separador
      buffer_entrada[buffer_pos] = c; //agregar caracter
      buffer_pos ++; //incrementar posición
    }
  } //fin  while Serial.available

  // Mover motor izquierdo
  if ((delta_i < 0 and encoder1.cont > meta_i) or (delta_i > 0 and encoder1.cont < meta_i)) {
    if (pwm_i < 0) {//reversa
      analogWrite(PIN_MI1, 0);
      analogWrite(PIN_MI2, abs(pwm_i));
    }
    else {//adelante
      analogWrite(PIN_MI1, pwm_i);
      analogWrite(PIN_MI2, 0);
    }
  }
  // Mover motor derecho
  if ((delta_d < 0 and encoder2.cont > meta_d) or (delta_d > 0 and encoder2.cont < meta_d)) {
    if (pwm_d < 0) {//reversa
      analogWrite(PIN_MD1, 0);
      analogWrite(PIN_MD2, abs(pwm_d));
    }
    else {//adelante
      analogWrite(PIN_MD1, pwm_d);
      analogWrite(PIN_MD2, 0);
    }
  }
  // Detectar pulsos
  encoder1.pulso( pwm_i);
  encoder2.pulso( pwm_d);

  // rotar servo
  if ((incre < 0 and pos > 0) or (incre > 0 and pos < 180)) {
    pos += incre;
    myservo.write(pos);
  }

  // Enviar información de encoders, servo y sensor
  // Valores separados por comas
  Serial.print(encoder1.cont);
  Serial.print(',');
  Serial.print(encoder2.cont);
  Serial.print(',');
  Serial.print(pos);
  Serial.print(',');
  Serial.println(sharp1.distancia(10));

  delay(9); //retardo entre loops
}

// Función signo
int sign(int x) {
  if (x < 0) return -1;
  if (x == 0) return 0;
  return 1;
}
