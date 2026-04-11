using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Finalización de un dibujo y resultado.
[System.Serializable]
public class LevelEndEvent : TrackerEvent {
    // Número que corresponde al dibujo en el manual.
    [SerializeField]protected byte level_id; // TODO, hacemos clase pare rollo LevelEvent para que ambas tengan el atributo level id? LevelStartEvent y LevelEndEvent me refiero

    // True == nivel superado
    // False == nivel perdido
    [SerializeField] protected bool result; // TODO, relacionamos esto de alguna manera con SessionEndEvent??? por el mismo atributo y taL
    public LevelEndEvent(byte levelid,  bool result) : base("level_end", "Gameplay") {
        this.level_id = levelid;
        this.result = result;
    }
}
