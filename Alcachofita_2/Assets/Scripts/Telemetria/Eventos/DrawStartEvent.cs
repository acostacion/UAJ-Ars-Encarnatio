using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inicio de un trazo.
public class DrawStartEvent : TrackerEvent {
    // No tiene ningún atributo extra. TODO quizá mousepos
    public DrawStartEvent(int eventId, int timestamp, int playerId, int sessionId) : base("draw_start", "Gameplay", eventId, timestamp, playerId, sessionId) { }
}
