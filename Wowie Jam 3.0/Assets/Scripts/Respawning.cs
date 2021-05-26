using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawning : MonoBehaviour
{

public Transform[] respawnPoints;
public GameObject player;
public GameObject grave;
public GameObject graveEffect;
int i = 0;

public void Start()
{
    Mathf.Clamp(i, 0, respawnPoints.Length);
}

public void Die()
{
    player.SetActive(false);
    Instantiate(grave,player.transform.position,Quaternion.identity);
    Instantiate(graveEffect,player.transform.position,Quaternion.identity);
    transform.position = respawnPoints[i].position;
    i += 1;
    player.transform.position = transform.position;
    player.SetActive(true);
}
}
