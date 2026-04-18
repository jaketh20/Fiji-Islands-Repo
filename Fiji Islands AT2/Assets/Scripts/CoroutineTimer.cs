using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CoroutineTimer : MonoBehaviour
{
    public float countDownTime;
    private Coroutine coroutine;
    public TextMeshPro text;
    InputAction action;

    private void Start()
    {
        action = InputSystem.actions.FindAction("Jump");
    }
    // Update is called once per frame
    void Update()
    {
        if (action.IsPressed() && coroutine == null)
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
