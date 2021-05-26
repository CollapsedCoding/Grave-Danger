using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryActual : MonoBehaviour
{
    public Animator anim;
    public string Level;

void OnTriggerEnter2D(Collider2D player)
{
    StartCoroutine(LoadScene());
}

IEnumerator LoadScene()
{
    anim.SetTrigger("End");
    yield return new WaitForSeconds(.8f);
    SceneManager.LoadScene(Level);
}

}
