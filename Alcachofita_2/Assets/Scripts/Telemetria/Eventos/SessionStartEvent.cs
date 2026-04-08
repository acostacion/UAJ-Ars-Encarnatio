using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inicio de la sesión de juego.
public class SessionStartEvent : Event {
    // No tiene ningún atributo extra.
    public SessionStartEvent() : base("session_start", "Generic") { }
}
