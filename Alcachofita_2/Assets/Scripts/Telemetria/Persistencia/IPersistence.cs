using System.Collections;
using System.Collections.Generic;
/* 
Responsable de decidir qué hacer con los eventos que llegan al sistema de tracking. 
Eventos almacenados en una cola de eventos que cada tiempo es necesario hacer un 
volcado (flush) de esta cola y persistir los datos de los eventos. 
*/
public abstract class IPersistence {
    protected List<TrackerEvent> _events = new List<TrackerEvent>();
    public virtual void Send(TrackerEvent trackerEvent)
    {
        _events.Add(trackerEvent);
    }
    public abstract void Flush(List<TrackerEvent> events);
    public void Flush()
    {
        Flush(_events);
        _events.Clear();
    }
}
