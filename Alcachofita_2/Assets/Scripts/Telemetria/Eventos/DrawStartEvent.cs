using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

// Inicio de un trazo.
public class DrawStartEvent : TrackerEvent {
    // Coordenada X, Y del cursor respecto a la resolución de la pantalla de juego.
    public Vector2 mouse_pos;
    public DrawStartEvent(int eventId, DateTime timestamp, int sessionId, Vector2 mousepos) : base("draw_start", "Gameplay", eventId, timestamp, sessionId) {
        this.mouse_pos = mousepos;
    }
}