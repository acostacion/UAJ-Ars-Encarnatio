using System;
using System.Numerics;

// Fin de un trazo
public class DrawEndEvent : TrackerEvent
{
    // Coordenada X, Y del cursor respecto a la resolución de la pantalla de juego.
    public Vector2 mouse_pos;
    public DrawEndEvent(int eventId, DateTime timestamp, int sessionId, Vector2 mousepos) : base("draw_end", "Gameplay", eventId, timestamp, sessionId)
    {
        this.mouse_pos = mousepos;
    }
}
