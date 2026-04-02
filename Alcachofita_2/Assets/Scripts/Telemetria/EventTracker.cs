using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderData;
using UnityEngine.SocialPlatforms;

public class EventTracker : MonoBehaviour
{
    static private EventTracker _instance;
    public static EventTracker Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
