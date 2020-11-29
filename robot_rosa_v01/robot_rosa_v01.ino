// Robot Móvil Rosa
// LLega a un punto indicado usando algoritmo BUG tipo 1
// https://www.arduino.cc/reference/en/language/functions/external-interrupts/attachinterrupt/

// Historial de versiones
// v0.1 Leer distancias y pulsos de encoders

// Definir pines
// Pines disponibles para PWM 3, 5, 6, 9, 10, 11 (3 y 11 usan Timer2) (490 Hz, 5 y 6 980 Hz)
#define PIN_E1 2 //encoder izquierdo (interrupt)
#define PIN_E2 3 //encoder derecho (interrupt)
#define PIN_MI_PWM 5
#define PIN_MD_PWM 6
#define PIN_MI1 8 //motor izquierdo 1
#define PIN_MI2 9 //motor izquierdo 2
#define PIN_STBY 10 //pin stand-by del puente H (usar 5V para salir del stand-by)
#define PIN_MD1 11 //motor derecho 1
#define PIN_MD2 12 //motor derecho 2
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
volatile int32_t contE1; //contador de pulsos encoder 1
volatile int32_t contE2; //contador de pulsos encoder 2

// las siguientes variables sirven para guardar el conteo previo de pulsos
// se obtiene la diferencia del conteo actual respecto al conteo previo
// con ese valor se calcula la velocidad
int32_t contE1prev; //valor previo del contador E1
int32_t contE2prev; //valor previo del contador E2

// Variables globales
unsigned long pingTimer; //momento de hacer ping
unsigned int pingSpeed = 100; //tiempo de espera entre pings (ms)

double x; //posición x
double y; //posición y
double z; //azimut o ángulo phi

unsigned long t; //momento actual
unsigned long tPrev; //tiempo del loop anterior
double tt = 0.1; //periodo de muestreo (s) es la diferencia entre los milis actuales y los del loop anterior
const double r = 6.5; //radio de las llantas (cm)
const double b = 10.3; //distancia entre llantas (cm)
const int ppv = 40; //pulsos por vuelta (20 orif. en rueda de encoder)
double v_i; //velocidad de rueda izquierda
double v_d; //velocidad de rueda derecha
double v; //velocidad instantánea en el centro del robot
double w; //velocidad angular del robot
double a; //posición angular en grados
double pos; //posición del servo en grados
double posRad; //posición del servo en radianes
double dist; //lectura de distancia
double linea_x; //componentes de la línea de visión
double linea_y;

void setup() {
  Serial.begin(115200);

  // Activar interrupciones en pines de encoders
  pinMode(PIN_E1, INPUT); //INPUT_PULLUP
  pinMode(PIN_E2, INPUT); //INPUT_PULLUP
  attachInterrupt(digitalPinToInterrupt(PIN_E1), isrE1, CHANGE);
  attachInterrupt(digitalPinToInterrupt(PIN_E2), isrE2, CHANGE);

  // Encender motores
  // El voltaje de entrada es 7V, duty cycle 55 es aprox 1.5V
  pinMode(PIN_MI_PWM, OUTPUT);
  pinMode(PIN_MI_PWM, OUTPUT);
  pinMode(PIN_MI1, OUTPUT);
  pinMode(PIN_MI2, OUTPUT);
  pinMode(PIN_MD1, OUTPUT);
  pinMode(PIN_MD2, OUTPUT);
  
  pinMode(PIN_STBY, OUTPUT);
  digitalWrite(PIN_STBY, 1); //salir de stand-by

  digitalWrite(PIN_MI1, 1);
  digitalWrite(PIN_MD1, 1);
  analogWrite(PIN_MI_PWM, 55);
  analogWrite(PIN_MD_PWM, 55);

  pingTimer = millis();
}

void loop() {
  t = millis(); //tiempo actual
  if (t >= pingTimer) {
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
