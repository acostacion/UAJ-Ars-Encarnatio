using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

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
                _instance ??= new Tracker();
                _instance.Start();
            }
           return _instance; ;
        }
    }
    void Awake()
    {
        if (_instance == null)
        {
            _instance = new Tracker();
            // Inicializar
            _instance.Start();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        _instance.Start(AnalyticsSessionInfo.sessionId);
    }
}
