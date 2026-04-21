using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

/*
Gestor que actua como puente entre el motor de Unity y el sistema de telemetria (Tracker).
Mantiene una instancia unica y global (Singleton) del Tracker.
Escucha los eventos automaticos del ciclo de vida de la aplicacion en Unity (inicio, cierre,
minimizado) para notificarselos al Tracker y que este resgistre estos eventos.
 */
public class TrackerManager : MonoBehaviour
{
    static private Tracker _instance = null;
    static public Tracker Instance
    {
        get
        {
            // Si se llama al Tracker antes del Awake se inicializa aqui
            if (_instance == null)
            {
                _instance = new Tracker();
                _instance.Start(AnalyticsSessionInfo.sessionId);
            }
           return _instance;
        }
    }
    void Awake()
    {
        if (_instance == null)
        {
            _instance = new Tracker();
            // Inicializar
            _instance.Start(AnalyticsSessionInfo.sessionId);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    void OnApplicationQuit()
    {
        if (_instance != null)
        {
            _instance.End();
        }
    }
    public void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
            _instance.registerWidowForegroundedEvent();
        else
            _instance.registerWidowBackgroundedEvent();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (!pauseStatus)
            _instance.registerWidowForegroundedEvent();
        else
            _instance.registerWidowBackgroundedEvent();
    }
}
