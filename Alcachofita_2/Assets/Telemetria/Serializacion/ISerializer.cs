/*
Interfaz que permite la serializacion de eventos de telemetria.
Permite implementar distintos formatos (JSON, CSV...)
de forma independiente al sistema de persistencia.
 */
public interface ISerializer 
{
    // Transforma un objeto de evento de telemetria a una cadena de texto
    public string Serialize(TrackerEvent trackerEvent);
}
