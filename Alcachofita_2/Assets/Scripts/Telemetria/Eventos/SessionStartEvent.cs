using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inicio de la sesión de juego.
public class SessionStartEvent : TrackerEvent {
    // No tiene ningún atributo extra.
    public SessionStartEvent(int eventId, int timestamp, int playerId, int sessionId) : base("session_start", "Generic", eventId, timestamp, playerId, sessionId) { }
}
