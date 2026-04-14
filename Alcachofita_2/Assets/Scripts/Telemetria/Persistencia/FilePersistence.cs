using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FilePersistence : IPersistence {

    private ISerializer _serializer;
    private string _path;
    private List<TrackerEvent> _events = new List<TrackerEvent> ();
    
    public FilePersistence(ISerializer serializer)
    {
        _serializer = serializer;
        _path = Application.persistentDataPath + "/events.json";
    }
    public void Send(TrackerEvent trackerEvent) {
        _events.Add(trackerEvent);
    }
    
    
    public void Flush(List<TrackerEvent> events)
    {
        try
        {
            foreach(var e in events)
            {
                string json = _serializer.Serialize(e);
                File.AppendAllText(_path, json + "\n");
            }
        }catch(System.Exception ex)
        {
            Debug.Log("Error en persistencia: " + ex.Message);
        }
    }
    public void Flush() {
        Flush(_events);
        _events.Clear();
    }
}
