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
            _puertoSerial = new SerialPort();
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
        ~Arduino()
        {
            if (_puertoSerial.IsOpen) _puertoSerial.Close();
        }
        //--------------------------------------------------------------
        public void Escribir(string c)
        {
            _puertoSerial.DiscardOutBuffer();
            _puertoSerial.Write(c);
        }
        //------------------------------------------------------------------
        public int LeerInt()
        {
            string valorString = "";
            int valorInt = 0;
            try
            {
                valorString = _puertoSerial.ReadLine();
                _puertoSerial.DiscardInBuffer();
                valorInt = Convert.ToInt16(valorString);
            }
            catch
            {
                valorInt = 0;
            }

            return valorInt;
        }
        //----------------------------------------------------------------
        public string LeerLinea()
        {
            string lin;
            try
            {
                lin = _puertoSerial.ReadLine();
                lin = _puertoSerial.ReadLine();
                _puertoSerial.DiscardInBuffer();
            }
            catch
            {
                lin = "";
            }
            return lin;
        }
        //----------------------------------------------------------------
    }
}
