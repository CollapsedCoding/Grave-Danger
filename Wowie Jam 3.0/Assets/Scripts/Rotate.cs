using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
public Rigidbody2D rb;
public float rotationSpeed;

    void Update()
    {
        rb.angularVelocity = rotationSpeed;
    }
}
