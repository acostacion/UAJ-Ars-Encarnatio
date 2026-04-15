using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms;
using static UnityEditor.ShaderData;

public class Tracker : MonoBehaviour {
    static private Tracker _instance = null;
    static public Tracker Instance { get { return _instance; } }

    private FilePersistence persistor;
    private ISerializer serializer;
    int sesionID;
    int playerID;
    int eventID = 0;

    float currEvents, eventsToFlush = 30;
    void Awake()
    {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
            return;
        }
    }

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

    // Esto esta inspirado en el repo de David
    void Start() {
        _persistenceType = PersistenceType.File; // por ejemplo
        _serializationType = SerializationType.JSON; // por ejemplo

        // 1. primero vemos de que formato seran los cosas
        switch (_persistenceType) {
            case PersistenceType.File:
                switch (_serializationType) {
                    case SerializationType.JSON:
                        serializer = new JsonSerializer();
                        break;
                        // ... TODO: aniadir otros casos si los hacemos...
                }
                persistor = new FilePersistence(serializer);
                break;
                // ... TODO: aniadir otros casos si los hacemos...
        }

        //TODO: decidir como decidimos la sesion id y el player id
        sesionID = 0;
        playerID = 0;

        registerSessionStartEvent();
    }



    public void registerDrawStartEvent() 
    {
        TrackerEvent ev = new DrawStartEvent(eventID, (int) Time.time, playerID, sesionID);
        persistor.Send(ev);
        eventID++; currEvents++;
        if (currEvents > eventsToFlush)
            flush();
    }

    public void registerDrawEndEvent() 
    {
        TrackerEvent ev = new DrawEndEvent(eventID, (int)Time.time, playerID, sesionID);
        persistor.Send(ev);
        eventID++; currEvents++;
        if (currEvents > eventsToFlush)
            flush();
    }

    public void registerLevelStartEvent(byte levelID) 
    {
        TrackerEvent ev = new LevelStartEvent(eventID, (int)Time.time, playerID, sesionID, levelID);
        persistor.Send(ev);
        eventID++; currEvents++;
        if (currEvents > eventsToFlush)
            flush();
    }

    public void registerLevelEndEvent(byte levelID, bool result)
    {
        TrackerEvent ev = new LevelEndEvent(eventID, (int)Time.time, playerID, sesionID, levelID, result);
        persistor.Send(ev);
        eventID++;
        persistor.Flush();
    }

    public void registerMouseMovementEvent(Vector2 mouse_pos) 
    {
        TrackerEvent ev = new MouseMovementEvent(eventID, (int)Time.time, playerID, sesionID, mouse_pos);
        persistor.Send(ev);
        eventID++; currEvents++;
        if (currEvents > eventsToFlush)
            flush();
    }

    public void registerSessionStartEvent() 
    {
        TrackerEvent ev = new SessionStartEvent(eventID, (int)Time.time, playerID, sesionID);
        persistor.Send(ev);
        eventID++; currEvents++;
        if (currEvents > eventsToFlush)
            flush();
    }

    public void registerSessionEndEvent() 
    {
        TrackerEvent ev = new SessionEndEvent(eventID, (int)Time.time, playerID, sesionID);
        persistor.Send(ev);
        eventID++; currEvents++;
        if (currEvents > eventsToFlush)
            flush();
    }

    public void registerUIInteractionEvent(InteractionTarget target) 
    {
        TrackerEvent ev = new UIInteractionEvent(eventID, (int)Time.time, playerID, sesionID, target);
        persistor.Send(ev);
        eventID++; currEvents++;
        if (currEvents > eventsToFlush)
            flush();
    }

    public void registerWidowBacKgroundedEvent() 
    {
        TrackerEvent ev = new WindowBackgroundedEvent(eventID, (int)Time.time, playerID, sesionID);
        persistor.Send(ev);
        eventID++; currEvents++;
        if (currEvents > eventsToFlush)
            flush();
    }

    public void registerWidowForegroundedEvent() 
    {
        TrackerEvent ev = new WindowForegroundedEvent(eventID, (int)Time.time, playerID, sesionID);
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
            registerWidowBacKgroundedEvent();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (!pauseStatus)
            registerWidowForegroundedEvent();
        else
            registerWidowBacKgroundedEvent();
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
