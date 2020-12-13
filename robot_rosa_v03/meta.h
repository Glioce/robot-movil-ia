// Estado 4: Meta

void meta() {
  //apagar motores
  digitalWrite(PIN_MD1, 0);
  digitalWrite(PIN_MD2, 0);
  digitalWrite(PIN_MI1, 0);
  digitalWrite(PIN_MI2, 0);
}

void checarDistancia() {
  double dx = xMeta - x; //componente x
  double dy = yMeta - y; //componente y
  double d = sqrt((dx*dx) + (dy*dy));
  double tol = 5.0; //tolerancia (cm)

  if (d <= tol){
    estado = 4; //el robot ha llegado a la meta
    digitalWrite(PIN_MD1, 0);
    digitalWrite(PIN_MD2, 0);
    digitalWrite(PIN_MI1, 0);
    digitalWrite(PIN_MI2, 0);
  }
}
