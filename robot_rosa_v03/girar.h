// Implementación del estado 0: Girar

void girar() {
  double dx = xMeta - x; // componente x
  double dy = yMeta - y; //componente y
  double phi = atan2(dy, dx); //angulo del vector que va del robot a la meta en el sistema de referencia
  double tol = 0.1;

  double dif = phi - z;
  if (dif < -PI) dif += dospi;
  if (dif > PI) dif -= dospi;

  if (dif > tol) {
    sentidoD = 1;
    digitalWrite(PIN_MD1, 0);
    digitalWrite(PIN_MD2, 1);
    sentidoI = -1;
    digitalWrite(PIN_MI1, 1);
    digitalWrite(PIN_MI2, 0);
  }
  else if (dif < -tol) {
    sentidoD = -1;
    digitalWrite(PIN_MD1, 1);
    digitalWrite(PIN_MD2, 0);
    sentidoI = 1;
    digitalWrite(PIN_MI1, 0);
    digitalWrite(PIN_MI2, 1);
  }
  else {
    //sentidoD = 0;
    digitalWrite(PIN_MD1, 0);
    digitalWrite(PIN_MD2, 0);
    digitalWrite(PIN_MI1, 0);
    digitalWrite(PIN_MI2, 0);
    // cambiar a estado movimiento en línea recta
    estado = 1;
  }

  // Calcular cinemática directa
}
