using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

public Transform door;
public Transform button;
public bool done = false;

IEnumerator DoorOpen()
{

    door.position = new Vector2 (door.position.x, door.position.y-.75f);
    yield return new WaitForSeconds(.25f);
    door.position = new Vector2 (door.position.x, door.position.y-.75f);
      yield return new WaitForSeconds(.25f);
    door.position = new Vector2 (door.position.x, door.position.y-.75f);
      yield return new WaitForSeconds(.25f);
    door.position = new Vector2 (door.position.x, door.position.y-.75f);
    done = true;
    Destroy(door.gameObject);

}

void OnTriggerEnter2D(Collider2D other)
{
    if(!done)
    {
    button.localPosition = new Vector2(0,-0.05f);
    StartCoroutine(DoorOpen());
    }


}

}
