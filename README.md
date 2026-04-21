### Añadir el sistema
Para implementar el sistema de telemetría en tu juego, introduce la carpeta de "Telemetria" (disponible en el directorio raiz de este proyecto) el la carpeta de "Scripts" de tu proyecto de Unity.

La estructura de este sistema es la siguiente:
- "Eventos": Carpeta en la que están los scripts donde se declara cada evento del juego.
- "Persistencia": Carpeta en la que se implementan los sistemas de persistencia y su interfaz.
- "Serializacion": Carpeta en la que se implementan los sistemas de serializacion y su interfaz.

El sistema está implementado en el juego de Unity de ejemplo (disponible también en el directorio raiz de este proyecto).

### Añadir los eventos

En la carpeta "Eventos" se crea la clase del evento nuevo, estos eventos heredan de "TrackerEvent" y sus parámetros han de ser serializables.

```C#
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

// Registro del movimiento del ratón.
[System.Serializable]
public class MouseMovementEvent : TrackerEvent {
    public float mouse_pos_x; // Coordenada X del clic respecto a la resolución de la pantalla de juego
    public float mouse_pos_y; // Coordenada Y del clic respecto a la resolución de la pantalla de juego

    public MouseMovementEvent(int eventId, DateTime timestamp, int sessionId, float mouse_pos_x, float mouse_pos_y) : base("mouse_movement", "Gameplay", eventId, timestamp, sessionId) {
        this.mouse_pos_x = mouse_pos_x;
        this.mouse_pos_y = mouse_pos_y;
    }
}
```
En el script Tracker.cs se crea el método de registro de este evento. 
```C#
public void registerDrawStartEvent(float mouse_pos_x, float mouse_pos_y)
{
    TrackerEvent ev = new DrawStartEvent(eventID, DateTime.UtcNow, sesionID, mouse_pos_x, mouse_pos_y);
    persistor.Send(ev);
    eventID++; currEvents++;
    if (currEvents > eventsToFlush)
        flush();
}
```
En el propio motor de desarrollo se crea un objeto Singleton que lo instancie el Tracker, inicializandolo con el número de sesion. Desde distintos puntos del juego se llama al método de registro del juego cuando sea pertinente.
```C#
TrackerManager.Instance.registerUIInteractionEvent(InteractionTarget.DIBUJO, Input.mousePosition.x, Input.mousePosition.y);
```

### Ejecutar pruebas
Con el sistema ya implementado, se guardarán las trazas en una carpeta llamada "ArsEncarnatioEvents" en el directorio "Documentos". Estos ficheros tendran el nombre "session_0000000000000_events" con un número de sesión generado de manera aleatoria.

### Analizar pruebas
Una vez adquiridos los ficheros de trazas, basta con copiarlos al directorio "Analisis/data" y ejecutar las pruebas acorde a las instrucciones en su README.