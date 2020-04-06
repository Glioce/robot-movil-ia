class Encoder
{
  public:
    int pin; //pin al que esta conectado
    byte e = 0; //estado
    byte ePrev = 0; //estado previo
    int cont = 0; //contador de pulsos
    int signo = 1; //indica el signo de la rotación (positivo o negativo, avance o reversa)

    //ctor
    Encoder (int p): pin(p) {}

    //método para detectar pulso
    byte pulso(int s) {
      if (s > 0) signo = 1; //obtener signo de rotación
      if (s < 0) signo = -1;
            
      e = digitalRead(pin); //estado actual
      byte r = (e != ePrev); //comparar con el estado previo
      
      if (r == true) //si el estado cambió
        cont += signo; //sumar o restar al contador de pulsos
      
      ePrev = e; //actualizar estado previo
      return r; //devolver resultado
    }
};
