using System;
[System.Serializable]
public class LevelEndEvent : TrackerEvent {
    // Número que corresponde al dibujo en el manual.
    public byte level_id; // TODO, hacemos clase pare rollo LevelEvent para que ambas tengan el atributo level id? LevelStartEvent y LevelEndEvent me refiero

    // True == nivel superado
    // False == nivel perdido
    public bool result; // TODO, relacionamos esto de alguna manera con SessionEndEvent??? por el mismo atributo y taL
    public LevelEndEvent(int eventId, DateTime timestamp, int playerId, int sessionId, byte levelid,  bool result) : base("level_end", "Gameplay", eventId, timestamp, playerId, sessionId) {
        this.level_id = levelid;
        this.result = result;
    }
}
