using System.Collections;
using System.Collections.Generic;
/* 
Clase base responsable de decidir qué hacer con los eventos que llegan al sistema de tracking. 
Los eventos se almacenan en una cola de eventos que cada tiempo es necesario hacer un 
volcado (flush) de esta cola y persistir los datos de los eventos. 
*/
public abstract class IPersistence {
    // Cola temporal donde se acumulan los eventos antes de guardarlos
    protected List<TrackerEvent> _events = new List<TrackerEvent>();

    // Recibe un evento desde el Tracker y lo encola en la lista de espera
    public virtual void Send(TrackerEvent trackerEvent)
    {
        _events.Add(trackerEvent);
    }

    // Metodo que las clases hijas deben implementar para definir donde se guarda (archivo,servidor...)
    public abstract void Flush(List<TrackerEvent> events);

    // Ejecuta el guardado de los eventos acumulados y limpia la cola para no duplicar datos
    public void Flush()
    {
        Flush(_events);
        _events.Clear();
    }

    // Metodo virtual para cerrar recursos
    public virtual void Close() { }
}
