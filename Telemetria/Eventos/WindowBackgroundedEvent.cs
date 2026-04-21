using System;

// Puesta en segundo plano o minimización de la ventana.
public class WindowBackgroundedEvent : TrackerEvent {
    // No tiene ningún atributo extra.
    public WindowBackgroundedEvent(int eventId, DateTime timestamp, long sessionId) : base("window_backgrounded", "UI", eventId, timestamp, sessionId) { }
}
