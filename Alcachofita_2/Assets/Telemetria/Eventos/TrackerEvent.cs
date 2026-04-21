using System;

[System.Serializable]
public class TrackerEvent {
    // Atributos fijos
    // Estos serán incluidos por el propio tracker en cada evento que se registre.
    public String       timestamp;  // Momento exacto en el que ocurre el evento.
    public long          session_id; // Identificación de la sesión de juego jugador.
    public int          event_id;   // Identificación única del evento, para evitar duplicados.
    public string       event_name; // Nombre del evento.
    public string       event_type; // Categoría del evento.

    public TrackerEvent(string name, string type, int eventId, DateTime timestamp, long sessionId) { 
        this.event_name = name;
        this.event_type = type;
        this.event_id = eventId;
        this.timestamp = timestamp.ToString();
        this.session_id = sessionId;
    }
}
