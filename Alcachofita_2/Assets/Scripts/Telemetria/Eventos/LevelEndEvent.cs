using System;
[System.Serializable]
public class LevelEndEvent : TrackerEvent {
    // Número que corresponde al dibujo en el manual.
    public byte level_id;
    // True == nivel superado
    // False == nivel perdido
    public bool result;
    public LevelEndEvent(int eventId, DateTime timestamp, long sessionId, byte levelid,  bool result) : base("level_end", "Gameplay", eventId, timestamp, sessionId) {
        this.level_id = levelid;
        this.result = result;
    }
}
