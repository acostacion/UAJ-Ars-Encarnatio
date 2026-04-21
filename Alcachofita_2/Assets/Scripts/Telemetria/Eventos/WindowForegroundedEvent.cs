using System;

// Puesta en primer plano o maximización de la ventana.
public class WindowForegroundedEvent : TrackerEvent {
    // No tiene ningún atributo extra.
    public WindowForegroundedEvent(int eventId, DateTime timestamp, long sessionId) : base("window_foregrounded", "UI", eventId, timestamp, sessionId) { }
}
