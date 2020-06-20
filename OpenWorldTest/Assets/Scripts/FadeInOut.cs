using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public Image imgTrans;
    public float vel;
    public bool done;
    Color blank = new Color(0, 0, 0, 0);

    void Start()
    {
        StartF(Color.black, blank);
    }

    public void StartF(Color begin, Color end)
    {
        done = false;
        StartCoroutine(Transition(begin, end));
    }

    IEnumerator Transition(Color begin, Color end)
    {
        float t = 0;
        while (true)
        {
            t = t + Time.unscaledDeltaTime * vel;
            imgTrans.color = Color.Lerp(begin, end, t);
            if (t >= 1)
            {
                break;
            }
            yield return new WaitForEndOfFrame();
        }
        done = true;
    }
}
