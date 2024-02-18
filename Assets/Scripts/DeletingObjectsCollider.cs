using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderKeywordFilter;
using UnityEditor.UIElements;
using UnityEngine;

public class DeletingObjectsCollider : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        // Проверяем столкновение с игроком
        if (other.CompareTag("Taked"))
        {
            Debug.LogWarning("Collected object was removed");
            //other.tag = "untacked";
            other.transform.DOKill();
            Destroy(other.gameObject);
            Debug.LogWarning("Array was Updated!");
        }
    }
}
