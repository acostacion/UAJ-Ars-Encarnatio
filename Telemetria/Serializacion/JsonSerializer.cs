using UnityEngine;

/*
Implementacion concreta de ISerializer para serializar eventos en formato JSON.
Utiliza la utilidad nativa de Unity (JsonUtility) para realizar la conversion.
 */
public class JsonSerializer : ISerializer
{
    // Transforma el objeto del evento a una cadena de texto en formato JSON
    public string Serialize(TrackerEvent trackerEvent)
    {
        // Solo serializa campos publicos o privados con [SerializeField]
        return JsonUtility.ToJson(trackerEvent);
    }
}
