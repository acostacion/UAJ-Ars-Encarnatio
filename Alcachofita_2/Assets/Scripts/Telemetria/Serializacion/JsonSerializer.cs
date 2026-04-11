using UnityEngine;

// Serializador JSON de eventos
public class JsonSerializer : ISerializer
{
    // Transforma el objeto del evento a una cadena de texto en formato JSON
    public string Serialize(TrackerEvent trackerEvent)
    {
        // Utilidad de Unity para convertir el objeto a un string JSON

        // Solo serializa campos publicos o privados con [SerializeField]
        return JsonUtility.ToJson(trackerEvent);
    }
}
