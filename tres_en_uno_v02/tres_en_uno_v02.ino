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
#define PIN_M1 4  //motor 1
#define PIN_M2 3  //motor 2
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

void setup() {
  // entradas para encoders
  pinMode(PIN_E1, INPUT);
  pinMode(PIN_E2, INPUT);

  // salidas para motores
  pinMode(PIN_M1, OUTPUT);
  pinMode(PIN_M2, OUTPUT);

  // motores apagados
  analogWrite(PIN_M1, 0);
  analogWrite(PIN_M2, 0);

  myservo.attach(PIN_SERVO);

  // iniciar comunicación serial
  Serial.begin(9600);
}

void loop() {
  while (Serial.available() > 0) {
    byte comando = Serial.read();

    switch (comando) {
      case 'A': //avanzar
        analogWrite(PIN_M1, 255);
        analogWrite(PIN_M2, 255);
        break;
      case 'P': //parar
        analogWrite(PIN_M1, 0);
        analogWrite(PIN_M2, 0);
        break;
      case 'I': //izquierda
        analogWrite(PIN_M1, 0);
        analogWrite(PIN_M2, 255);
        break;
      case 'D': //derecha
        analogWrite(PIN_M1, 255);
        analogWrite(PIN_M2, 0);
        break;
      case '1': //rotar servo a la izquierda
        incre = -1;
        break;
      case '2': //rotar servo a la derecha
        incre = 1;
        break;
    }
  }

  if (encoder1.pulso()) {
    Serial.println(encoder1.e);
    //delay(2);
  }
  if (encoder2.pulso()) {
    Serial.println(encoder2.e);
    //delay(2);
  }

  Serial.println(sharp1.distancia(20));

  if ((incre < 0 and pos > 0) or (incre > 0 and pos < 180)) {
    pos += incre;
    myservo.write(pos);
  }

  delay(10); //retardo entre loops
}
