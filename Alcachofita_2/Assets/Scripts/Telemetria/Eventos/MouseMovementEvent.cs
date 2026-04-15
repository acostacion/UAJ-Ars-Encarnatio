using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

// Registro del movimiento del ratón con una frecuencia limitada.
[System.Serializable]
public class MouseMovementEvent : TrackerEvent {
    // Coordenada X, Y del cursor respecto a la resolución de la pantalla de juego.
    public Vector2 mouse_pos;
    public MouseMovementEvent(int eventId, DateTime timestamp, int playerId, int sessionId, Vector2 mousepos) : base("mouse_movement", "Gameplay", eventId, timestamp, playerId, sessionId) {
        this.mouse_pos = mousepos; // TODO no se si la mousepos se ha de coger asi o en cada momento :(
    }
}
