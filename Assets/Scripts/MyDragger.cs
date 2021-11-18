using UnityEngine;
using System.Collections;

public class MyDragger : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 positionMinMouse;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        positionMinMouse = (Vector2)transform.position - MousePosInWorld();
    }

    private void OnMouseDrag()
    {
        rb.MovePosition(positionMinMouse + MousePosInWorld());
    }

    private Vector2 MousePosInWorld()
    {
        Vector2 mouseOnScreen = Input.mousePosition;
        Vector2 mouseOnWorld = Camera.main.ScreenToWorldPoint(mouseOnScreen);
        return mouseOnWorld;
    }
}
