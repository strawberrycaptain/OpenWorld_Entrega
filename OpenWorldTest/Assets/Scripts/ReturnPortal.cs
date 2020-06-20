using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnPortal : MonoBehaviour
{

    Color blank = new Color(0, 0, 0, 0);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(MyLoadScene());
        }
    }
    IEnumerator MyLoadScene()
    {
        FadeInOut fade = FindObjectOfType<FadeInOut>();
        fade.StartF(Color.black, blank);
        yield return new WaitUntil(() => fade.done);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainGame");
    }
}
