// Inicio de cada dibujo.
using System;

[System.Serializable]
public class LevelStartEvent : TrackerEvent {
    // Número que corresponde al dibujo en el manual.
    public byte level_id;
    public LevelStartEvent(int eventId, DateTime timestamp, int sessionId, byte levelid) : base("level_start", "Gameplay", eventId, timestamp, sessionId) {
        this.level_id = levelid;
    }
}
