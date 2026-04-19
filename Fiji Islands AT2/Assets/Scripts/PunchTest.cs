using UnityEngine;
using UnityEngine.InputSystem;

public class PunchTest : MonoBehaviour
{
    Animator animator;
    InputAction action;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        action = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        if (action.IsPressed())
        {
            animator.SetBool("Space down", true);
        }
        else
        {
            animator.SetBool("Space down", false);
        }
    }
}
