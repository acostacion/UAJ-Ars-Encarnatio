using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inicio de cada dibujo.
[System.Serializable]
public class LevelStartEvent : TrackerEvent {
    // Número que corresponde al dibujo en el manual.
    [SerializeField] protected byte level_id;
    public LevelStartEvent(byte levelid) : base("level_start", "Gameplay") {
        this.level_id = levelid;
    }
}
