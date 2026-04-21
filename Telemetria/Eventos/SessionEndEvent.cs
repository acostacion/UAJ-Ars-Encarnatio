using System;

// Fin de la sesión de juego, indicando el resultado global de la partida.
[System.Serializable]
public class SessionEndEvent : TrackerEvent {
    public SessionEndEvent(int eventId, DateTime timestamp, long sessionId) : base("session_end", "Generic", eventId, timestamp, sessionId) {
    }
}
