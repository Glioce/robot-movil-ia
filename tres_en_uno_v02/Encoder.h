class Encoder
{
  public:
    int pin; //pin al que esta conectado
    byte e = 0; //estado
    byte ePrev = 0; //estado previo
    int cont = 0; //contador de pulsos

    //ctor
    Encoder (int p): pin(p) {}

    //método para detectar pulso
    byte pulso() {
      e = digitalRead(pin); //estado actual
      byte r = (e != ePrev); //comparar con el estado previo
      if (r == true) cont ++; //incrementar contador de pulsos
      ePrev = e; //actualizar estado previo
      return r; //devolver resultado
    }
};
