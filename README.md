# robot-movil-ia
Robot móvil con IA. ¡Equipo Dinamita!

Clase SerialPort  
https://docs.microsoft.com/en-us/dotnet/api/system.io.ports.serialport?view=netframework-4.8  
obtener lista de puertos  
https://docs.microsoft.com/en-us/dotnet/api/system.io.ports.serialport.getportnames?view=netframework-4.8  
método ReadLine  
https://docs.microsoft.com/en-us/dotnet/api/system.io.ports.serialport.readline?view=netframework-4.8#System_IO_Ports_SerialPort_ReadLine  
método Write  
https://docs.microsoft.com/en-us/dotnet/api/system.io.ports.serialport.write?view=netframework-4.8#System_IO_Ports_SerialPort_Write_System_String_  
propiedad NewLine (por default es \n)  
https://docs.microsoft.com/en-us/dotnet/api/system.io.ports.serialport.newline?view=netframework-4.8#System_IO_Ports_SerialPort_NewLine  

Errores en el código. Los datos recibidos por el puerto serial se pueden mostrar en la consola, pero no se puede escribir directamente en los objetos Label. ¿Cómo lo logramos?  
https://docs.microsoft.com/es-es/dotnet/csharp/language-reference/compiler-messages/cs0120  
https://docs.microsoft.com/es-es/dotnet/api/system.threading.thread?view=netframework-4.8  
https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/classes-and-structs/instance-constructors  

Se puede usar un timer y así evitamos usar un thread con método estático. Creo que se resta un poco de eficiencia. Por ahora la importante es que funcione, se optimizará después.  
https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.timer?view=netframework-4.8  
https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/run-procedures-at-set-intervals-with-wf-timer-component  

Separar string por coma  
https://docs.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split  
https://docs.microsoft.com/en-us/dotnet/api/system.stringsplitoptions?view=netframework-4.8#System_StringSplitOptions_RemoveEmptyEntries  
