using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Fin de la sesión de juego, indicando el resultado global de la partida.
[System.Serializable]
public class SessionEndEvent : TrackerEvent {
    // True == partida ganada 
    // False == partida perdida
    [SerializeField] protected bool result; 
    public SessionEndEvent(bool result) : base("session_end", "Generic") {
        this.result = result;
    }
}
