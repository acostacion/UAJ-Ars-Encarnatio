using System;

[System.Serializable]
public class TrackerEvent {
    // Atributos fijos
    // Estos serán incluidos por el propio tracker en cada evento que se registre.
    public DateTime     timestamp;  // Momento exacto en el que ocurre el evento.
    public int          session_id; // Identificación de la sesión de juego jugador.
    public int          event_id;   // Identificación única del evento, para evitar duplicados.
    public string       event_name; // Nombre del evento.
    public string       event_type; // Categoría del evento.
    // Nota: he mirado que int == System.Int32

    // TODO comprobar que sea asi y ver si necesitamos mas cosas
    public TrackerEvent(string name, string type, int eventId, DateTime timestamp, int sessionId) { 
        this.event_name = name;
        this.event_type = type;
        this.event_id = eventId;
        this.timestamp = timestamp;
        this.session_id = sessionId;
    }

    // TODO seguir haciendo esto

}
