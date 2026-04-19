using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTracker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Instanciar serializador
        ISerializer serializer = new JsonSerializer();

        // Crear un eveto de prueba
        LevelEndEvent testEvent = new LevelEndEvent(0, System.DateTime.MinValue, 0, 0, 1, true);
        
        // Pasar el evento por el serializador para obtener el texto JSON
        string resultJson1 = serializer.Serialize(testEvent);
        string resultJson2 = serializer.Serialize(test2Event);

        // Imprimir en la consola de Unity
        Debug.Log("Test de Serializaci�n exitoso: \n" + resultJson1);
        Debug.Log("Test de Serializaci�n exitoso 2: \n" + resultJson2);

        string finalJson = resultJson1 + "\n" + resultJson2;
        Debug.Log("Archivo final: \n" + finalJson);
    }
}
