// GetFolderPath(https://learn.microsoft.com/es-es/dotnet/api/system.environment.getfolderpath?view=net-8.0)
// SpecialFolder.LocalApplicationData(https://learn.microsoft.com/es-es/dotnet/api/system.environment.specialfolder?view=net-8.0)
using System;
using System.Numerics;
using System.IO;
using System.Diagnostics;
using static System.Collections.Specialized.BitVector32;
public class Tracker {
    private IPersistence persistor;
    private ISerializer serializer;
    long sesionID;
    int eventID = 0;

    float currEvents, eventsToFlush = 30;

    /// <summary>
    /// • Centralización del punto de entrada del sistema de telemetría en un objeto accesible desde cualquier punto de nuestro juego.
    /// • Puede requerir de una inicialización y finalización explícitas.
    /// • En la inicialización se pueden enviar eventos de inicio de sesión junto con parámetros que pueden aportar especificaciones adicionales: plataforma, SO, país,
    /// información demográfica (año de nacimiento, sexo, id de alguna red social. . . ).
    /// </summary>
    
    // Ej.: JSON, CSV. XML, YAML, Binary Formats
    enum SerializationType { JSON }
    SerializationType _serializationType;

    // Ej.: Disco, Servidor, Dispositivo que se este usando
    enum PersistenceType { File }
    PersistenceType _persistenceType;

    // Cola de eventos
    // TODO  pero hacer con la clase event k he creado


    public void Start(long sesionId) {
        _persistenceType = PersistenceType.File; // por ejemplo
        _serializationType = SerializationType.JSON; // por ejemplo
        sesionID = sesionId;

        // 1. primero vemos de que formato seran los cosas
        switch (_persistenceType) {
            case PersistenceType.File:
                switch (_serializationType) {
                    case SerializationType.JSON:
                        serializer = new JsonSerializer();
                        break;
                        
                }
                // Definir ruta
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ArsEncarnatioEvents/";

                // Si la carpeta no existe, se crea
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string file = "session_" + sesionID.ToString()+ "_events.json";
                Debug.WriteLine("Data saved to: " + Path.Combine(path, file));
                persistor = new FilePersistence(serializer, Path.Combine(path, file));
                break;
        }
    }

    public void registerDrawStartEvent(float mouse_pos_x, float mouse_pos_y)
    {
        if (persistor == null) return;

        TrackerEvent ev = new DrawStartEvent(eventID, DateTime.UtcNow, sesionID, mouse_pos_x, mouse_pos_y);
        persistor.Send(ev);
        eventID++; currEvents++;
        if (currEvents > eventsToFlush)
            flush();
    }

    public void registerDrawEndEvent(float mouse_pos_x, float mouse_pos_y)
    {
        if (persistor == null) return;

        TrackerEvent ev = new DrawEndEvent(eventID, DateTime.UtcNow, sesionID, mouse_pos_x, mouse_pos_y);
        persistor.Send(ev);
        eventID++; currEvents++;
        if (currEvents > eventsToFlush)
            flush();
    }

    public void registerLevelStartEvent(byte levelID) 
    {
        if (persistor == null) return;

        TrackerEvent ev = new LevelStartEvent(eventID, DateTime.UtcNow, sesionID, levelID);
        persistor.Send(ev);
        eventID++; currEvents++;
        if (currEvents > eventsToFlush)
            flush();
    }

    public void registerLevelEndEvent(byte levelID, bool result)
    {
        if (persistor == null) return;

        TrackerEvent ev = new LevelEndEvent(eventID, DateTime.UtcNow, sesionID, levelID, result);
        persistor.Send(ev);
        eventID++;
        persistor.Flush();
    }

    public void registerMouseMovementEvent(float mouse_pos_x, float mouse_pos_y)
    {
        if (persistor == null) return;
        TrackerEvent ev = new MouseMovementEvent(eventID, DateTime.UtcNow, sesionID, mouse_pos_x, mouse_pos_y);
        persistor.Send(ev);
        eventID++; currEvents++;
        if (currEvents > eventsToFlush)
            flush();
    }

    public void registerSessionStartEvent() 
    {
        if (persistor == null) return;

        TrackerEvent ev = new SessionStartEvent(eventID, DateTime.UtcNow, sesionID);
        persistor.Send(ev);
        eventID++; currEvents++;
        if (currEvents > eventsToFlush)
            flush();
    }

    public void registerSessionEndEvent() 
    {
        if (persistor == null) return;

        TrackerEvent ev = new SessionEndEvent(eventID, DateTime.UtcNow, sesionID);
        persistor.Send(ev);
        eventID++; currEvents++;
        if (currEvents > eventsToFlush)
            flush();
    }

    public void registerUIInteractionEvent(InteractionTarget target, float mouse_pos_x, float mouse_pos_y) 
    {
        if (persistor == null) return;

        TrackerEvent ev = new UIInteractionEvent(eventID, DateTime.UtcNow, sesionID, target, mouse_pos_x, mouse_pos_y);
        persistor.Send(ev);
        eventID++; currEvents++;
        if (currEvents > eventsToFlush)
            flush();
    }

    public void registerWidowBackgroundedEvent() 
    {
        if (persistor == null) return;

        TrackerEvent ev = new WindowBackgroundedEvent(eventID, DateTime.UtcNow, sesionID);
        persistor.Send(ev);
        eventID++; currEvents++;
        if (currEvents > eventsToFlush)
            flush();
    }

    public void registerWidowForegroundedEvent() 
    {
        if (persistor == null) return;

        TrackerEvent ev = new WindowForegroundedEvent(eventID, DateTime.UtcNow, sesionID);
        persistor.Send(ev);
        eventID++; currEvents++;
        if (currEvents > eventsToFlush)
            flush();
    }

    public void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus) 
            registerWidowForegroundedEvent();
        else
            registerWidowBackgroundedEvent();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (!pauseStatus)
            registerWidowForegroundedEvent();
        else
            registerWidowBackgroundedEvent();
    }

    void OnApplicationQuit()
    {
        registerSessionEndEvent();
        persistor.Flush();
    }

    private void flush()
    {
        persistor.Flush();
        currEvents = 0;
    }

}
