// Implementación del estado 3: Navegar contorno

void navegar() {
  double dx = xMeta - x; // componente x
  double dy = yMeta - y; //componente y
  double phi = atan2(dy, dx); //angulo del vector que va del robot a la meta en el sistema de referencia
  double tol = 0.2; //tolerancia de ángulo hacia la meta
  double dif = phi - z;
  if (dif < -PI) dif += dospi;
  if (dif > PI) dif -= dospi;

  int dObs = 5; //distacia ideal al obstáculo
  sentidoD = 1; //siempre hacia adelante en el estado navegar
  sentidoI = 1;

  // Leer distancias
  //int d1 = sonar1.ping_cm(); //frontal
  int d2 = sonar2.ping_cm(); //izquierda
  int d3 = sonar3.ping_cm(); //derecha
  //int d4 = sonar4.ping_cm();

  if (abs(dif) <= tol) {
    estado = 1; //avanzar en línea recta hacia la meta
  }
  else if (lado == 1) {// Seguir con el sensor izquierdo
    if (d2 < dObs and d2 > 0) {
      //detener motor derecho
      digitalWrite(PIN_MD1, 0);
      digitalWrite(PIN_MD2, 0);
      //solo avanza motor izquierdo
      digitalWrite(PIN_MI1, 0);
      digitalWrite(PIN_MI2, 1);
    }
    else if (d2 > dObs and d2 > 0) {
      //solo avanza motor derecho
      digitalWrite(PIN_MD1, 0);
      digitalWrite(PIN_MD2, 1);
      //detener motor izquierdo
      digitalWrite(PIN_MI1, 0);
      digitalWrite(PIN_MI2, 0);
    }
    else {
      //avanzar en línea recta
      digitalWrite(PIN_MD1, 0);
      digitalWrite(PIN_MD2, 1);
      digitalWrite(PIN_MI1, 0);
      digitalWrite(PIN_MI2, 1);
    }
  }

  else if (lado == 2) {// Seguir con el sensor derecho
    if (d3 < dObs and d3 > 0) {
      //solo avanza el motor derecho
      digitalWrite(PIN_MD1, 0);
      digitalWrite(PIN_MD2, 1);
      //detener motor izquierdo
      digitalWrite(PIN_MI1, 0);
      digitalWrite(PIN_MI2, 0);
    }
    else if (d3 > dObs and d3 > 0) {
      //detener motor derecho
      digitalWrite(PIN_MD1, 0);
      digitalWrite(PIN_MD2, 0);
      //solo avanza con motor izquierdo
      digitalWrite(PIN_MI1, 0);
      digitalWrite(PIN_MI2, 1);
    }
    else {
      //avanzar en línea recta
      digitalWrite(PIN_MD1, 0);
      digitalWrite(PIN_MD2, 1);
      digitalWrite(PIN_MI1, 0);
      digitalWrite(PIN_MI2, 1);
    }
  }
}
