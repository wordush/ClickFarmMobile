using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wardrobe : MonoBehaviour
{
    public GameObject WardrobeEnterButton;
    public GameObject WardrobePanel;
    // Start is called before the first frame update
    void Start()
    {
        WardrobeEnterButton.SetActive(false);
        WardrobePanel.SetActive(false);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WardrobeEnterButton.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        WardrobeEnterButton.SetActive(false);
    }
}
