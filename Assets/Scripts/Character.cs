using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{

    public float speed;
    public bool isRunningEmpty;
    [SerializeField] public FloatingJoystick joystick;
    [SerializeField] public Rigidbody rb;
    [SerializeField] public Animator animator;

    private void Start()
    {
        isRunningEmpty = true;
    }

    void FixedUpdate()
    {
        Moving();
        CheckingForAnims();
    }

    void Moving()
    {
        rb.velocity = new Vector3(joystick.Horizontal * speed, rb.velocity.y, joystick.Vertical * speed);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            animator.SetBool("isRunning", true);
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        } else { animator.SetBool("isRunning", false); }
    }


    public void CheckingForAnims()
    {
        if (isRunningEmpty == false)
        {
            isRunningEmpty = false;
            animator.SetBool("isRunningEmpty", false);
        }
        else
        {
            isRunningEmpty = true;
            animator.SetBool("isRunningEmpty", true);
        }

    }

    public void IsRunningEmpty(bool isTaked)
    {
        isRunningEmpty = isTaked;
    }
}