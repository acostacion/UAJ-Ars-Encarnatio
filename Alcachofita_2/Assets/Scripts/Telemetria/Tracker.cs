using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms;
using static UnityEditor.ShaderData;

public class Tracker : MonoBehaviour {
    static private Tracker _instance = null;
    static public Tracker Instance { get { return _instance; } }

    private Queue<TrackerEvent> events = new Queue<TrackerEvent>();
    private FilePersistence persistor;
    private ISerializer serializer;
    int sesionID;
    int playerID;
    int eventID = 0;
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

        

        

        registerSessionStartEvent();
    }


    public void registerDrawStartEvent() 
    {
        TrackerEvent ev = new DrawStartEvent(eventID, (int) Time.time, playerID, sesionID);
        events.Enqueue(ev);
        eventID++;
    }

    public void registerDrawEndEvent() 
    {
        TrackerEvent ev = new DrawEndEvent(eventID, (int)Time.time, playerID, sesionID);
        events.Enqueue(ev);
        eventID++;
    }

    public void registerLevelStartEvent(byte levelID) 
    {
        TrackerEvent ev = new LevelStartEvent(eventID, (int)Time.time, playerID, sesionID, levelID);
        events.Enqueue(ev);
        eventID++;
    }

    public void registerLevelEndEvent(byte levelID, bool result)
    {
        TrackerEvent ev = new LevelEndEvent(eventID, (int)Time.time, playerID, sesionID, levelID, result);
        events.Enqueue(ev);
        eventID++;
    }

    public void registerMouseMovementEvent(Vector2 mouse_pos) 
    {
        TrackerEvent ev = new MouseMovementEvent(eventID, (int)Time.time, playerID, sesionID, mouse_pos);
        events.Enqueue(ev);
        eventID++;
    }

    public void registerSessionStartEvent() 
    {
        TrackerEvent ev = new SessionStartEvent(eventID, (int)Time.time, playerID, sesionID);
        events.Enqueue(ev);
        eventID++;
    }

    public void registerSessionEndEvent() 
    {
        TrackerEvent ev = new SessionEndEvent(eventID, (int)Time.time, playerID, sesionID);
        events.Enqueue(ev);
        eventID++;
    }

    public void registerUIInteractionEvent(InteractionTarget target) 
    {
        TrackerEvent ev = new UIInteractionEvent(eventID, (int)Time.time, playerID, sesionID, target);
        events.Enqueue(ev);
        eventID++;
    }

    public void registerWidowBacKgroundedEvent() 
    {
        TrackerEvent ev = new WindowBackgroundedEvent(eventID, (int)Time.time, playerID, sesionID);
        events.Enqueue(ev);
        eventID++;
    }

    public void registerWidowForegroundedEvent() 
    {
        TrackerEvent ev = new WindowForegroundedEvent(eventID, (int)Time.time, playerID, sesionID);
        events.Enqueue(ev);
        eventID++;
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
    }

}
