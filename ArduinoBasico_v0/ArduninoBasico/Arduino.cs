using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
namespace ArduninoBasico
{
    class Arduino
    {   //atriabutos
        SerialPort _puertoSerial;
         
        // Cosntructor  ----------------------------------------
        public Arduino(string nombrePuerto)
        {
            _puertoSerial =  new SerialPort();
            _puertoSerial.ReadTimeout = 1000;
            _puertoSerial.BaudRate = 9600;
            try
            {
                _puertoSerial.PortName = nombrePuerto;
                if (!_puertoSerial.IsOpen) _puertoSerial.Open();
            }
            catch
            {
                MessageBox.Show("No se pudo abrir el puerto");
            }
            
           
       }
        //------------------------------------------------------------
        ~ Arduino()
        {
           if(_puertoSerial.IsOpen) _puertoSerial.Close();
        }
        //--------------------------------------------------------------
        public void Escribir(string c)
        {
         _puertoSerial.DiscardOutBuffer();
         _puertoSerial.Write(c);
        }
        //------------------------------------------------------------------
    }
}
