using UnityEngine;


// Opcional: Serializador CSV de eventos
public class CSVSerializer : ISerializer
{
    // Transforma el objeto del evento a una cadena de texto en formato JSON
    public string Serialize(TrackerEvent trackerEvent)
    {
        // logica para convertir el evento a formato separado por comas
        return "";
            //trackerEvent.ToCSV();
    }
}
