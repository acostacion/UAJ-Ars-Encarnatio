using System.Collections;
using System.Collections.Generic;

/*
Sin implementar pero para demostrar que se puede incorporar nuevos medios de persistencia 
basados en la clase abstracta IPersistence
 */
public class ServerPersistence : IPersistence {
    public void Send(TrackerEvent trackerEvent) {
        
    }
    public override void Flush(List<TrackerEvent> events)
    {
        
    }
}
