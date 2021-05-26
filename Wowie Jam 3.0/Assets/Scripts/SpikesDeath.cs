using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesDeath : MonoBehaviour
{

    private Respawning respawn;
    public GameObject respawnObject;

    void Update()
    {
        respawn = respawnObject.GetComponent<Respawning>();
    }

void OnTriggerEnter2D(Collider2D other)
{
    if (other.tag == "Player"){
    respawn.Die();
    }
}

}
