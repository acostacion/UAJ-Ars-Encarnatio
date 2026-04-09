/* 
Responsable de decidir qué hacer con los eventos que llegan al sistema de tracking. 
Eventos almacenados en una cola de eventos que cada tiempo es necesario hacer un 
volcado (flush) de esta cola y persistir los datos de los eventos. 
*/
public interface IPersistence {
    void Send(TrackerEvent trackerEvent);
    void Flush();
}
