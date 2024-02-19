using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stacking : MonoBehaviour
{
    public Character characterScript;
    public GameObject playerScript;
    [SerializeField] Transform player;
    float stackCount = 0;
    float objectHight = 0.185f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Picked Up!");
        if (other.CompareTag("stacking"))
        {
            Transform Collectable_Object = other.transform;
            Collectable_Object.tag = "Taked";
            Collectable_Object.SetParent(this.transform);
            Collectable_Object.DOLocalMove(new Vector3(0.1f, 0.6f + objectHight*stackCount, 0.4f), 0.5f);
            Collectable_Object.localRotation = Quaternion.Euler(0, 0, 0);
            stackCount++;
            characterScript.GetTakedList();
        }
    }
    private void Start()
    {
        characterScript = playerScript.GetComponent<Character>();
    }
}
