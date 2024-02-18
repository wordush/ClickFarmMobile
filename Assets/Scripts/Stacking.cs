using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stacking : MonoBehaviour
{
    [SerializeField] Transform player;
    float stackCount = 0;
    float objectHight = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("BAM");
        if (other.CompareTag("stacking"))
        {
            Transform coin = other.transform;
            coin.tag = "Taked";
            coin.SetParent(this.transform);
            //coin.localPosition = new Vector3(-0.01f, stackCount * objectHight, 0.3f);
            coin.DOLocalMove(new Vector3(-0.01f, 0.4f + objectHight*stackCount, 0.4f), 0.5f);
            coin.localRotation = Quaternion.Euler(0, 90, 0);
            stackCount++;
        }
    }
}
