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
            _instance ??= new Tracker();
            return _instance;
        }
    }
    void Awake()
    {
        if (_instance == null)
        {
            _instance = new Tracker();
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
