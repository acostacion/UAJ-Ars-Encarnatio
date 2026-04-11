using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Registro del movimiento del ratón con una frecuencia limitada.
[System.Serializable]
public class MouseMovementEvent : TrackerEvent {
    // Coordenada X, Y del cursor respecto a la resolución de la pantalla de juego.
    [SerializeField] protected Vector2 mouse_pos;
    public MouseMovementEvent(Vector2 mousepos) : base("mouse_movement", "Gameplay") {
        this.mouse_pos = mousepos; // TODO no se si la mousepos se ha de coger asi o en cada momento :(
    }
}
