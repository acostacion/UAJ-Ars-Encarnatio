using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

// Inicio de un trazo.
public class DrawStartEvent : TrackerEvent {
    public float clic_pos_x; // Coordenada X del clic respecto a la resolución de la pantalla de juego
    public float clic_pos_y; // Coordenada Y del clic respecto a la resolución de la pantalla de juego

    public DrawStartEvent(int eventId, DateTime timestamp, long sessionId, float mouse_pos_x, float mouse_pos_y) : base("draw_start", "Gameplay", eventId, timestamp, sessionId) {
        this.clic_pos_x = mouse_pos_x;
        this.clic_pos_y = mouse_pos_y;
    }
}