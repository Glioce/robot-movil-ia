class Sharp {
  public:
    int pin; //pin al que está conectado
    //float d; //distancia en cm

    //ctor
    Sharp (int p): pin(p) {}

    //método para leer distancia
    //toma n muestras y obtiene el promedio
    //después usa una función exponencial para calcular la distancia en cm
    float distancia(int n)
    {
      long suma = 0;
      for (int i = 0; i < n; i++)
      {
        suma = suma + analogRead(pin);
      }
      float adc = suma / n;
      float distancia_cm = 17569.7 * pow(adc, -1.2062);
      return (distancia_cm);
    }
};
