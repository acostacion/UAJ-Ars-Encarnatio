using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Puesta en segundo plano o minimización de la ventana.
public class WindowBackgroundedEvent : Event {
    // No tiene ningún atributo extra.
    public WindowBackgroundedEvent() : base("window_backgrounded", "UI") { }
}
