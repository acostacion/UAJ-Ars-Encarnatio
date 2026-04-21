// Registro de cada clic realizado en la pantalla, indicando su posición exacta en la interfaz.
using System;
using System.Numerics;

public enum InteractionTarget { TRAPO, CONFIRMAR, DIBUJO, NULL};
[System.Serializable]
public class UIInteractionEvent : TrackerEvent {
    public InteractionTarget target_id;
    public Vector2 clic_pos; // (Vector2) Coordenada X, Y del clic respecto a la resolución de la pantalla de juego
    public UIInteractionEvent(int eventId, DateTime timestamp, int sessionId, InteractionTarget target, Vector2 clickPosition) : base("ui_interaction", "UI", eventId, timestamp, sessionId) { 
        this.target_id = target;
        this.clic_pos = clickPosition;
    }
}
