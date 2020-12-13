// Iplementación del estado 1: Avance en línea recta

void recta() {
  double dx = xMeta - x; // componente x
  double dy = yMeta - y; //componente y
  double phi = atan2(dy, dx); //angulo del vector que va del robot a la meta en el sistema de referencia
  double tol = 0.4; //tolerancia de ángulo (radianes)
  int dObs = 6; //si un sensor detecta una distancia menor, significa que está cerca de un obstáculo
  double dif = phi - z;
  if (dif < -PI) dif += dospi; //mantener valor en el intervalo [-pi, pi]
  if (dif > PI) dif -= dospi;

  // Leer distancias
  int d1 = sonar1.ping_cm();
  int d2 = sonar2.ping_cm();
  int d3 = sonar3.ping_cm();
  //int d4 = sonar4.ping_cm();

  if (dif < -tol or dif > tol) {
    digitalWrite(PIN_MD1, 0);
    digitalWrite(PIN_MD2, 0);
    digitalWrite(PIN_MI1, 0);
    digitalWrite(PIN_MI2, 0);
    // regresar al estado 0: girar
    estado = 0;
  }
  else if(d2 < dObs and d2 > 0) {
    lado = 1; //izquierda
    estado = 3; //navegar contorno del obstáculo
  }
  else if(d3 < dObs and d3 > 0) {
    lado = 2; //derecha
    estado = 3; //navegar contorno del obstáculo
  }
  else if(d1 < dObs and d1 > 0)  {
    lado = random(1, 3); //elegir lado al azar
    estado = 2;
    digitalWrite(PIN_MD1, 0);
    digitalWrite(PIN_MD2, 0);
    digitalWrite(PIN_MI1, 0);
    digitalWrite(PIN_MI2, 0);
  }
  else { //sigue avanzando en línea recta
    sentidoD = 1;
    digitalWrite(PIN_MD1, 0);
    digitalWrite(PIN_MD2, 1);
    sentidoI = 1;
    digitalWrite(PIN_MI1, 0);
    digitalWrite(PIN_MI2, 1);
  }
}
