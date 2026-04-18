using TMPro;
using UnityEngine;

public class FloatTimer : MonoBehaviour
{
    float timer;
    public TextMeshPro text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        text.text = "Timer: " + timer.ToString();
        if (timer > 10.0f)
        {
            gameObject.SetActive(false);
        }
    }
}
