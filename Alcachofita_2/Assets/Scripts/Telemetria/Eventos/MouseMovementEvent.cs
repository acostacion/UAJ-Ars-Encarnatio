using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Registro del movimiento del ratón con una frecuencia limitada.
public class MouseMovementEvent : TrackerEvent {
    // Coordenada X, Y del cursor respecto a la resolución de la pantalla de juego.
    private Vector2 _mouse_pos;
    public MouseMovementEvent(Vector2 mousepos) : base("mouse_movement", "Gameplay") {
        _mouse_pos = mousepos; // TODO no se si la mousepos se ha de coger asi o en cada momento :(
    }
}
