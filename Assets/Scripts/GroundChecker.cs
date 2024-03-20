using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool IsOnGround
    {
        get
        {
            return colliders.Count > 0;
        }
    }

    private List<Collider2D> colliders = new List<Collider2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        colliders.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        colliders.Remove(collision);
    }
}
