using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShrinePortal : MonoBehaviour
{
    public string levelToLoad;

    Color blank = new Color(0, 0, 0, 0);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CommonValues.ShrinePlayerPosition = other.transform.position - other.transform.forward * 3;

            StartCoroutine(MyLoadScene());
        }
    }

    IEnumerator MyLoadScene()
    {
        yield return new WaitForSeconds(2);
        FadeInOut fade = FindObjectOfType<FadeInOut>();
        fade.StartF(blank, Color.black);
        yield return new WaitUntil(() => fade.done);
        SceneManager.LoadScene(levelToLoad);
    }
}
