using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [TELEMETRIA] para cuando se haga clic en arania, ojo o bichillo.
public class ClickOnInutilComponent : MonoBehaviour {
    private void OnMouseDown() {
        InteractionTarget target = InteractionTarget.NULL; // NULL por defecto (nunca va a salir esto).
        switch (gameObject.tag) {
            case "Spider": target = InteractionTarget.ARANIA; break;
            case "Bichillo": target = InteractionTarget.BICHILLO;  break;
            case "Eye": target = InteractionTarget.OJO; break; // TODO a este hay k hacerle bien el collider
        }
        Tracker.Instance.registerUIInteractionEvent(target, 
            new System.Numerics.Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }
}
