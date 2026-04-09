using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Registro de cada clic realizado en la pantalla, indicando su posición exacta en la interfaz.
public enum InteractionTarget { TRAPO, CONFIRMAR, DIBUJO, ARANIA, OJO, NULL};
public class UIInteractionEvent : TrackerEvent {
    private InteractionTarget _target_id;
    // TODO a la espera de GUILLE: clic_pos (Vector2) Coordenada X, Y del clic respecto a la resolución de la pantalla de juego
    public UIInteractionEvent(InteractionTarget target) : base("ui_interaction", "UI") { 
        _target_id = target;
    }
}
