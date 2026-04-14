using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Registro de cada clic realizado en la pantalla, indicando su posición exacta en la interfaz.
public enum InteractionTarget { TRAPO, CONFIRMAR, DIBUJO, ARANIA, OJO, NULL};
[System.Serializable]
public class UIInteractionEvent : TrackerEvent {
    [SerializeField] protected InteractionTarget target_id;
   // [SerializeField] protected Vector2 clic_pos;
    // TODO a la espera de GUILLE: clic_pos (Vector2) Coordenada X, Y del clic respecto a la resolución de la pantalla de juego
    public UIInteractionEvent(int eventId, int timestamp, int playerId, int sessionId, InteractionTarget target/*, Vector2 clickPosition*/) : base("ui_interaction", "UI", eventId, timestamp, playerId, sessionId) { 
        this.target_id = target;
       // this.clic_pos = clickPosition;
    }
}
