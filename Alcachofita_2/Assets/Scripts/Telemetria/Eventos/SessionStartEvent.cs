using System;

// Inicio de la sesión de juego.
public class SessionStartEvent : TrackerEvent {
    // No tiene ningún atributo extra.
    public SessionStartEvent(int eventId, DateTime timestamp, int playerId, int sessionId) : base("session_start", "Generic", eventId, timestamp, playerId, sessionId) { }
}
