using UnityEngine;

public class BrilloComponent : MonoBehaviour
{
    public SpriteRenderer trapo;

    void OnMouseOver()
    {
        //Debug.Log("pis");
        if (trapo.color.a < 1)
        {
            trapo.color = new Color(trapo.color.r, trapo.color.g, trapo.color.b, 1);
        }
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 10;
        System.Numerics.Vector2 mPos = new System.Numerics.Vector2(mousePosition.x, mousePosition.y);
    }

    void OnMouseExit()
    {
        //Debug.Log("caca");
        if (trapo != null)
        {
            trapo.color = new Color(trapo.color.r, trapo.color.g, trapo.color.b, 0);
        }
    }

    void Start()
    {
        trapo = GetComponent<SpriteRenderer>();
        trapo.color = new Color(trapo.color.r, trapo.color.g, trapo.color.b, 0);
    }
}
