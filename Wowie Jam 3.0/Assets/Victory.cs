using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{

    public Rigidbody2D rb;
    bool WinningSon;
    public float windPower = 35f;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            rb.velocity = new Vector2(rb.velocity.x , windPower);
        }
    }

}
