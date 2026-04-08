using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Fin de la sesión de juego, indicando el resultado global de la partida.
public class SessionEndEvent : Event {
    // True == partida ganada 
    // False == partida perdida
    private bool _result; 
    public SessionEndEvent(bool result) : base("session_end", "Generic") {
        _result = result;
    }
}
