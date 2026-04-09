using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Puesta en segundo plano o minimización de la ventana.
public class WindowBackgroundedEvent : TrackerEvent {
    // No tiene ningún atributo extra.
    public WindowBackgroundedEvent() : base("window_backgrounded", "UI") { }
}
