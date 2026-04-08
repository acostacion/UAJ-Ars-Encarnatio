using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inicio de un trazo.
public class DrawStartEvent : Event {
    // No tiene ningún atributo extra. TODO quizá mousepos
    public DrawStartEvent() : base("draw_start", "Gameplay") { }
}
