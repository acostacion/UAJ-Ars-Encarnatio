using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

// Registro del movimiento del ratón con una frecuencia limitada.
[System.Serializable]
public class MouseMovementEvent : TrackerEvent {
    public float mouse_pos_x; // Coordenada X del clic respecto a la resolución de la pantalla de juego
    public float mouse_pos_y; // Coordenada Y del clic respecto a la resolución de la pantalla de juego

    public MouseMovementEvent(int eventId, DateTime timestamp, int sessionId, float mouse_pos_x, float mouse_pos_y) : base("mouse_movement", "Gameplay", eventId, timestamp, sessionId) {
        this.mouse_pos_x = mouse_pos_x;
        this.mouse_pos_y = mouse_pos_y;
    }
}
