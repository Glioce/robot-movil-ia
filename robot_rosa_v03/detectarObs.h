// Implementación del estado 2: Detección de Obstáculos

void detectarObs() {
  // Girar hasque un sensor lateral esté cerca del obstáculo
  int dObs = 6; //si un sensor detecta una distancia menor, significa que está cerca de un obstáculo
  
  // Leer distancias
  //int d1 = sonar1.ping_cm(); //frontal
  int d2 = sonar2.ping_cm(); //izquierda
  int d3 = sonar3.ping_cm(); //derecha
  //int d4 = sonar4.ping_cm();

  if (lado == 1) {//izquierda
    sentidoD = -1;
    digitalWrite(PIN_MD1, 1);
    digitalWrite(PIN_MD2, 0);
    sentidoI = 1;
    digitalWrite(PIN_MI1, 0);
    digitalWrite(PIN_MI2, 1);

    if (d2 < dObs and d2 > 0) estado = 3; //navegar contorno
  }
  if (lado == 2) {//derecha
    sentidoD = 1;
    digitalWrite(PIN_MD1, 0);
    digitalWrite(PIN_MD2, 1);
    sentidoI = -1;
    digitalWrite(PIN_MI1, 1);
    digitalWrite(PIN_MI2, 0);

    if (d3 < dObs and d3 > 0) estado = 3; //navegar contorno
  }
}
