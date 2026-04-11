using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class TrackerEvent {
    // Atributos fijos
    // Estos serán incluidos por el propio tracker en cada evento que se registre.
    [SerializeField] protected int    timestamp;  // Momento exacto en el que ocurre el evento.
    [SerializeField] protected int    player_id;  // Identificación del jugador.
    [SerializeField] protected int    session_id; // Identificación de la sesión de juego jugador.
    [SerializeField] protected int    event_id;   // Identificación única del evento, para evitar duplicados.
    [SerializeField] protected string event_name; // Nombre del evento.
    [SerializeField] protected string event_type; // Categoría del evento.
    // Nota: he mirado que int == System.Int32

    // TODO comprobar que sea asi y ver si necesitamos mas cosas
    public TrackerEvent(string name, string type) { 
        this.event_name = name;
        this.event_type = type;
    }

    // TODO seguir haciendo esto

}
