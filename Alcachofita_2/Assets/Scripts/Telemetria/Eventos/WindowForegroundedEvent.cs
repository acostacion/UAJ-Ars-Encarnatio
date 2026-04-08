using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Puesta en primer plano o maximización de la ventana.
public class WindowForegroundedEvent : Event {
    // No tiene ningún atributo extra.
    public WindowForegroundedEvent() : base("window_foregrounded", "UI") { }
}
