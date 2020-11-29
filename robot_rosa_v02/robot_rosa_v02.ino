// Robot Móvil Rosa
// LLega a un punto indicado usando algoritmo BUG tipo 1
// https://www.arduino.cc/reference/en/language/functions/external-interrupts/attachinterrupt/

// Historial de versiones
// v0.1 Leer distancias y pulsos de encoders
// v0.2 Calcular velocidad y posición

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

//#define PI 3.1415926535897932384626433832795
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
// Se obtiene la diferencia del conteo actual respecto al conteo previo,
// con ese valor se calcula la velocidad.
int32_t contE1prev; //valor previo del contador E1
int32_t contE2prev; //valor previo del contador E2

// Tiempo
// Cuando se hace ping también se calcula la velocidad
// La diferencia (t - tPrev) es el tiempo de muestreo
unsigned long pingTimer; //momento de hacer ping
unsigned int pingSpeed = 100; //tiempo de espera entre pings (ms)
unsigned long t; //momento actual
unsigned long tPrev; //tiempo del loop anterior

// Dimensiones físicas
const double r = 3.25; //radio de las llantas (cm)
const double rr = 6.5; //diámetro de las llantas (cm)
const double b = 10.6; //distancia entre llantas (cm)
const double ppv = 40.0; //pulsos por vuelta (20 orif. en rueda de encoder)
const double pacm = PI * rr / ppv; //factor de conversión pulsos a cm
const double dospi = 2 * PI;
const double rad2deg = 180 / PI;  //factor de conversión radianes a grados

// Posición y velocidad
double x; //posición x (cm)
double y; //posición y (cm)S
double z; //orientación theta (radianes)
//double v_i; //velocidad de rueda izquierda
//double v_d; //velocidad de rueda derecha
double v; //velocidad instantánea en el centro del robot (cm/s)
double w; //velocidad angular del robot (rad/s)
double a; //posición angular en grados
double d; //lectura de distancia

// Meta
double xMeta = 100.0;
double yMeta = 100.0;

/*
El díametro de las llantas es 3.25 * 2 = 6.5 cm
El perímetro de las llantas es pi * 6.5 = 20.42 cm
Por cada pulso del encoder hay un desplazamiento 20.42 / 40 = 0.51 cm
La tolerancia de la posición puede ser +-1 cm
Para tener mejor exactitud en la posición se pueden usar llantas más pequeñas
El cálculo de la velocidad puede tener errores grandes.
*/

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

  delay(500);
  // Valores iniciales antes del primer muestreo
  x = 0;
  y = 0;
  z = 0;
  contE1 = 0;
  contE2 = 0;
  contE1prev = 0;
  contE2prev = 0;
  // guardar el tiempo actual
  tPrev = millis();
  // esperar el tiempo indicado por pingSpeed antes del primer muestreo
  pingTimer = tPrev + pingSpeed;
  // t se actualiza en cada loop, cuando es momento de hacer el muestreo
  // se obtiene la diferencia (t - tPrev) para saber cuántos ms han
  // transcurrido desde el muestro anterior
}

void loop() {
  t = millis(); //tiempo actual
  if (t >= pingTimer) {
    // Leer rápido el estado de los contadores
    int pulsosI = contE1 - contE1prev; //número de pulsos en la rueda izquierda
    int pulsosD = contE2 - contE2prev; //número de pulsos en la rueda derecha
    double delta_t = t - tPrev; //tiempo transcurrido (ms)

    // velocidad de las ruedas en pulsos / s
    double vI = pulsosI / (delta_t / 1000.0);
    double vD = pulsosD / (delta_t / 1000.0);

    // velocidad en cm / s
    vI *= pacm; //se usa la constante calculada "pulsos a cm"
    vD *= pacm;
    v = (vI + vD) / 2; // cm/s
    w = (vD - vI) / b; // rad/s (b podría llamarse l)

    // Calcular nueva posición
    x += v * cos(z) * delta_t;
    y += v * sin(z) * delta_t;
    z += w * delta_t;
    // mantener z en el intervalo [0, 2*PI]
    if (z < 0) z += dospi;
    if (z > dospi) z -= dospi;

    // Leer distancias
    int d1 = sonar1.ping_cm();
    int d2 = sonar2.ping_cm();
    int d3 = sonar3.ping_cm();
    int d4 = sonar4.ping_cm();

    // Debug
    //Serial.print(contE1); Serial.print(" ");
    //Serial.print(contE2); Serial.print(" ");
    Serial.print(pulsosI); Serial.print(" ");
    Serial.print(pulsosD); Serial.print(" ");
    Serial.print(vI); Serial.print(" ");
    Serial.print(vD); Serial.print(" ");
    
    Serial.print(d1); Serial.print(" ");
    Serial.print(d2); Serial.print(" ");
    Serial.print(d3); Serial.print(" ");
    Serial.print(d4); Serial.println();

    contE1prev += pulsosI;
    contE2prev += pulsosD;
    pingTimer += pingSpeed; //siguiente momento para muestreo
    tPrev = t; //actualizar tiempo previo
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
