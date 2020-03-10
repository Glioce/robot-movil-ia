class Encoder
{
  public:

  int pin;//pin al que esta conectado
  byte e=0;//estado
  byte ePrev=0;//estado previo
   //ctor 

   Encoder (int p): pin(p){
   }
   byte pulso(){
    e=digitalRead(pin);
    byte r=(e!=ePrev); 
    ePrev=e;
    return r; 
   }
};
