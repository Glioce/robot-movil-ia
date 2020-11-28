// Robot Móvil Rosa
// LLega a un punto indicado usando algoritmo BUG tipo 1
// https://www.arduino.cc/reference/en/language/functions/external-interrupts/attachinterrupt/

// Historial de versiones
// v0.1 Leer distancias y pulsos de encoders

// Definir pines
// Pines disponibles para PWM 3, 5, 6, 9, 10, 11 (3 y 11 usan Timer2) (490 Hz, 5 y 6 980 Hz)
#define PIN_E1 2 //encoder izquierdo (interrupt)
#define PIN_E2 3 //encoder derecho (interrupt)
#define PIN_MI1 5 //motor izquierdo 1
#define PIN_MI2 6 //motor izquierdo 2
#define PIN_MD1 9 //motor derecho 1
#define PIN_MD2 10 //motor derecho 2
#define PIN_TRIG1 A0 //sensor 1 frontal
#define PIN_ECHO1 A0
#define PIN_TRIG2 A1 //sensor 2 izquierdo
#define PIN_ECHO2 A1
#define PIN_TRIG3 A2 //sensor 3 derecho
#define PIN_ECHO3 A2
#define PIN_TRIG4 A3 //sensor 4 trasero
#define PIN_ECHO4 A3
// Pines libres 4, 7, 8, 11, 12, 13, A4, A5

#define MAX_DIST 50 //distancia máxima que deben leer los sensores

// Objetos para los sensores
#include <NewPing.h>
NewPing sonar1(PIN_TRIG1, PIN_ECHO1, MAX_DIST); //sensor 1 frontal
NewPing sonar2(PIN_TRIG2, PIN_ECHO2, MAX_DIST); //sensor 2 izquierdo
NewPing sonar3(PIN_TRIG3, PIN_ECHO3, MAX_DIST); //sensor 3 derecho
NewPing sonar4(PIN_TRIG4, PIN_ECHO4, MAX_DIST); //sensor 4 trasero

// Varaibles editables en rutina de interrupción
volatile int contE1; 
volatile int contE2; 

// Variables globales
unsigned long pingTimer; //momento de hacer ping
unsigned int pingSpeed = 100; //tiempo de espera entre pings (ms)

void setup() {
  Serial.begin(115200);

  // Activar interrupciones en pines de encoders
  pinMode(PIN_E1, INPUT); //INPUT_PULLUP
  pinMode(PIN_E2, INPUT); //INPUT_PULLUP
  attachInterrupt(digitalPinToInterrupt(PIN_E1), isrE1, CHANGE);
  attachInterrupt(digitalPinToInterrupt(PIN_E2), isrE2, CHANGE);

  // Encender motores
  // El voltaje de entrada es 7V, duty cycle 55 es aprox 1.5V
  pinMode(PIN_MI1, OUTPUT);
  pinMode(PIN_MI2, OUTPUT);
  pinMode(PIN_MD1, OUTPUT);
  pinMode(PIN_MD2, OUTPUT);
  analogWrite(PIN_MI1, 55);
  analogWrite(PIN_MD1, 55);

  pingTimer = millis();
}

void loop() {
  if (millis() >= pingTimer) {
    pingTimer += pingSpeed;
    int d1 = sonar1.ping_cm();
    int d2 = sonar2.ping_cm();
    int d3 = sonar3.ping_cm();
    int d4 = sonar4.ping_cm();
    
    Serial.print(contE1); Serial.print(" ");
    Serial.print(contE2); Serial.print(" ");
    
    Serial.print(d1); Serial.print(" ");
    Serial.print(d2); Serial.print(" ");
    Serial.print(d3); Serial.print(" ");
    Serial.print(d4); Serial.println();
  }
}

// Interrupt encoder 1
void isrE1() {
  contE1++;
}

// Interrupt encoder 2
void isrE2() {
  contE2++;
}
