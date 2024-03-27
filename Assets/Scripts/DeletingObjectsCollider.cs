using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderKeywordFilter;
using UnityEditor.UIElements;
using UnityEngine;

public class DeletingObjectsCollider : MonoBehaviour
{
    public SavedResources SaveManager;
    public AudioSource boxSellingSound;

    void OnTriggerEnter(Collider other)
    {
        // Проверяем столкновение с игроком
        if (other.CompareTag("Taked"))
        {
            BoxType boxType = other.gameObject.GetComponent<BoxType>();
            BoxTypeList type = boxType.GetBoxType();
            var price = boxType.GetPrice();
            SaveManager.EventMoneyAdd(price);
            Debug.LogWarning(type.ToString() + " for " + price.ToString() +"$");
            other.tag = "untacked";
            other.transform.DOKill();
            boxSellingSound.pitch = Random.Range(0.9f, 1.2f);
            boxSellingSound.Play();
            Destroy(other.gameObject);
        }
    }
}
