using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 5f;

    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, projectileSpeed);
        if(rb.position.y > 5)
        {
            Destroy(gameObject);
        }
    }
}
