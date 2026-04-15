using System.Collections.Generic;
using System.IO;

public class FilePersistence : IPersistence {

    private ISerializer _serializer;
    private string _path;
    private StreamWriter _writer;
    public FilePersistence(ISerializer serializer, string path)
    {
        _serializer = serializer;
        _path = path;

        string directory = Path.GetDirectoryName(_path);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        _writer = new StreamWriter(directory);
    }
   
    public override void Flush(List<TrackerEvent> events)
    {
        try
        {
            foreach(var e in events)
            {
                string json = _serializer.Serialize(e);
                _writer.WriteLine(json);
            }
            _writer.Flush();
        }catch(System.Exception ex)
        {
            System.Console.WriteLine("Error persistencia",ex.Message);
        }
    }
    public void Close()
    {
        _writer?.Close();
    }
}
