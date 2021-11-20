using UnityEngine;
using System.Collections;

public class DragAndRelease : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpringJoint2D sj;
    private DistanceJoint2D dj;

    private Vector2 positionMinMouse;
    private Vector2 initPosition;

    private bool isMousePressed = false;

    [SerializeField] float releaseTime = .15f;
    [SerializeField] float maxDragDistance = 2f;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sj = GetComponent<SpringJoint2D>();
        dj = GetComponent<DistanceJoint2D>();
        initPosition = transform.position;
    }

    private void Update()
    {
        if (isMousePressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(mousePos, initPosition) > maxDragDistance)
                rb.position = initPosition + (mousePos - initPosition).normalized * maxDragDistance;
            else
                rb.position = mousePos;
        }
    }

    private void OnMouseDown()
    {
        positionMinMouse = (Vector2)transform.position - MousePosInWorld();
        isMousePressed = true;
    }

    private void OnMouseDrag()
    {
        rb.MovePosition(positionMinMouse + MousePosInWorld());
    }

    private void OnMouseUp()
    {
        isMousePressed = false;
        StartCoroutine(ReleaseBall());
    }

    IEnumerator ReleaseBall()
    {
        // Wait a short time, to let the physics engine operate the spring and give some initial speed to the ball.
        yield return new WaitForSeconds(releaseTime);
        sj.enabled = false;
        dj.enabled = false;
    }


    private Vector2 MousePosInWorld()
    {
        Vector2 mouseOnScreen = Input.mousePosition;
        Vector2 mouseOnWorld = Camera.main.ScreenToWorldPoint(mouseOnScreen);
        return mouseOnWorld;
    }
}