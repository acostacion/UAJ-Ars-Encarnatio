using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Fin de un trazo
public class DrawEndEvent : TrackerEvent
{
    // No tiene ningún atributo extra. TODO quizá mousepos
    public DrawEndEvent() : base("draw_end", "Gameplay") { }
}
