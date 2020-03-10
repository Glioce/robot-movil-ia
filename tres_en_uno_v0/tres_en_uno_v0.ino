// Robot Móvil con IA
// Equipo Dinamita

// definición de pines
#define PIN_E1 8  //encoder 1
#define PIN_E2 13 //encoder 2
#define PIN_M1 4  //motor 1
#define PIN_M2 3  //motor 2

// crear objeto para el sensor Sharp
#include "Sharp.h"
Sharp sharp1(A0);

// crear objetos para encoders
#include "Encoder.h"
Encoder encoder1(PIN_E1);
Encoder encoder2(PIN_E2);

// crear objeto para el servo
#include <Servo.h>
Servo myservo; 

int pos = 0; // posición del servo
int incre = 1; //incremento de posición del servo
void setup() {
  // put your setup code here, to run once:
pinMode (PIN_E1, INPUT);
pinMode (PIN_E2, INPUT);

pinMode (PIN_M1, OUTPUT);
pinMode (PIN_M2, OUTPUT);



analogWrite(PIN_M1, 255);
analogWrite(PIN_M2, 255);

Serial.begin(9600);

myservo.attach(A1);  // attaches the servo on pin 9 to the servo object

}

void loop() {
  // put your main code here, to run repeatedly:

if(encoder1.pulso()){
  Serial.println(encoder1.e);
  delay(2);  
}
if(encoder2.pulso()){
  Serial.println(encoder2.e);
  delay(2);  
}

Serial.println(sharp1.distancia(20));
delay(10);



      pos += incre;
    myservo.write(pos);              // tell servo to go to position in variable 'pos'
    delay(15);
   if (pos == 180){
                          // waits 15ms for the servo to reach the position

     incre=-1;
  }
   if (pos == 0){
                          // waits 15ms for the servo to reach the position

     incre=1;
  }
  




}
