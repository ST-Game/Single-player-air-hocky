using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowOnGoal: MonoBehaviour
{
    [SerializeField] private string triggeringTag;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag)
        {
            rb.drag += 10;   
        }
    }
}
