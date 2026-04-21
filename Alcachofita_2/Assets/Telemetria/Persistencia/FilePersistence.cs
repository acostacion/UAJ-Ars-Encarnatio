using System.Collections.Generic;
using System.IO;

/*
Implementacion concreta de persistencia.
Se encarga de transformar los eventos a texto usando un serializador
y guardarlos fisicamente en un archivo local del sistema.
 */
public class FilePersistence : IPersistence {

    private ISerializer _serializer;    // Herramienta para convertir el evento a texto
    private string _path;               // Ruta completa donde se ubica el archivo
    private StreamWriter _writer;       // Flujo que mantiene el archivo abierto para escribir en el
    public FilePersistence(ISerializer serializer, string path)
    {
        _serializer = serializer;
        _path = path;

        // Comprueba si la carpeta existe, si no la crea para evitar errores de ruta
        string directory = Path.GetDirectoryName(_path);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        // Abre el archivo y lo deja prepearado para recibir lineas de texto
        _writer = new StreamWriter(path);
    }
   
    // Recorre la cola de eventos, los serializa y los escribe en el archivo
    public override void Flush(List<TrackerEvent> events)
    {
        try
        {
            foreach(var e in events)
            {
                string json = _serializer.Serialize(e);
                _writer.WriteLine(json);    // Escribe el evento como una nueva linea
            }
            // Escribe los datos en el disco inmediatamente
            _writer.Flush();
        }catch(System.Exception ex)
        {
            System.Console.WriteLine("Error persistencia",ex.Message);
        }
    }

    // Cierra el flujo de datos y libera el archivo del sistema operativo
    public override void Close()
    {
        if(_writer != null)
        {
            _writer.Close();
            _writer = null;
        }
       
    }
}
