using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inicio de cada dibujo.
public class LevelStartEvent : Event {
    // Número que corresponde al dibujo en el manual.
    private byte _level_id;
    public LevelStartEvent(byte levelid) : base("level_start", "Gameplay") {
        _level_id = levelid;
    }
}
