using System;

// Fin de un trazo
public class DrawEndEvent : TrackerEvent
{
    // No tiene ningún atributo extra. TODO quizá mousepos
    public DrawEndEvent(int eventId, DateTime timestamp, int playerId, int sessionId) : base("draw_end", "Gameplay", eventId, timestamp, playerId, sessionId) { }
}
