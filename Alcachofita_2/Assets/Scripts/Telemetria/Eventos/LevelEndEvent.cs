using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Finalización de un dibujo y resultado.
public class LevelEndEvent : Event {
    // Número que corresponde al dibujo en el manual.
    private byte _level_id; // TODO, hacemos clase pare rollo LevelEvent para k ambas tengan el atributo level id? LevelStartEvent y LevelEndEvent me refiero

    // True == nivel superado
    // False == nivel perdido
    private bool _result; // TODO, relacionamos esto de alguna manera con SessionEndEvent??? por el mismo atributo y taL
    public LevelEndEvent(byte levelid,  bool result) : base("level_end", "Gameplay") {
        _level_id = levelid;
        _result = result;
    }
}
