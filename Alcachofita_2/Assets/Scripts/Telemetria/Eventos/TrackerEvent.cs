using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TrackerEvent {
    // Atributos fijos
    // Estos serán incluidos por el propio tracker en cada evento que se registre.
    protected int    _timestamp;  // Momento exacto en el que ocurre el evento.
    protected int    _player_id;  // Identificación del jugador.
    protected int    _session_id; // Identificación de la sesión de juego jugador.
    protected int    _event_id;   // Identificación única del evento, para evitar duplicados.
    protected string _event_name; // Nombre del evento.
    protected string _event_type; // Categoría del evento.
    // Nota: he mirado que int == System.Int32

    // TODO comprobar que sea asi y ver si necesitamos mas cosas
    public TrackerEvent(string name, string type) { 
        _event_name = name;
        _event_type = type;
    }

    // TODO seguir haciendo esto
}
