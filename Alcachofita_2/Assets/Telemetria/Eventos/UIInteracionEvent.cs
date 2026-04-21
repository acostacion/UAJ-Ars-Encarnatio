// Registro de cada clic realizado en la pantalla, indicando su posición exacta en la interfaz.
using System;
using System.Numerics;

public enum InteractionTarget { TRAPO, CONFIRMAR, DIBUJO, NULL};
[System.Serializable]
public class UIInteractionEvent : TrackerEvent {
    public InteractionTarget target_id;
    public float clic_pos_x; // Coordenada X del clic respecto a la resolución de la pantalla de juego
    public float clic_pos_y; // Coordenada Y del clic respecto a la resolución de la pantalla de juego

    public UIInteractionEvent(int eventId, DateTime timestamp, long sessionId, InteractionTarget target, float clicPosX, float clicPosY) : base("ui_interaction", "UI", eventId, timestamp, sessionId) { 
        this.target_id = target;
        this.clic_pos_x = clicPosX;
        this.clic_pos_y = clicPosY;
    }
}
