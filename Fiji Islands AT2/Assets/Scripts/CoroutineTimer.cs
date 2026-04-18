using System.Collections;
using TMPro;
using UnityEngine;

public class CoroutineTimer : MonoBehaviour
{
    public float countDownTime;
    private Coroutine coroutine;
    public TextMeshPro text;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && coroutine == null)
        {
            Debug.Log("start countdown");
            coroutine = StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        text.text = "timer started";
        yield return new WaitForSeconds(countDownTime);

        gameObject.SetActive(false);

        coroutine = null;
    }
}
