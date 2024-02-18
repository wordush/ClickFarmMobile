using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : MonoBehaviour
{
    public GameObject[] takedCoins;
    public float speed;
    public bool isRunningEmpty;
    [SerializeField] public FloatingJoystick joystick;
    [SerializeField] public Rigidbody rb;
    [SerializeField] public Animator animator;

    void FixedUpdate()
    {
        Moving();
        CheckingForAnims();
        GetTakedList();
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

    public void GetTakedList()
    {
        takedCoins = GameObject.FindGameObjectsWithTag("Taked");
    }

    public void RemoveTakedFromList(GameObject obj)
    {
        for (int i = 0; i <= takedCoins.Length; i++)
        {
            Destroy(takedCoins[i]);
        }
    }

    void CheckingForAnims()
    {
        if (takedCoins.Length > 0) { isRunningEmpty = false; animator.SetBool("isRunningEmpty", false); } else { isRunningEmpty = true; animator.SetBool("isRunningEmpty", true); }

    }
}