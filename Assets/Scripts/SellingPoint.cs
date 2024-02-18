using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SellingPoint : MonoBehaviour
{
    public GameObject playerScript;
    public GameObject SellPosition;
    public Transform TransformSellPosition;

    public Vector3 targetPosition;
    private float jumpPower = 2;
    private int numJumps = 1;
    private float duration = 2;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Получаем компонент Character на объекте Player
            Character characterScript = other.GetComponent<Character>();

            foreach (GameObject obj in characterScript.takedCoins)
            {
                obj.transform.DOJump(targetPosition, jumpPower, numJumps, duration); //анимация
            }
        }
    }

    private void Start()
    {
        targetPosition = TransformSellPosition.position;
    }
}
