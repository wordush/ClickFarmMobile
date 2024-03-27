using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stacking : MonoBehaviour
{
    public Character CharacterScript;
    public GameObject PlayerScript;
    public SavedResources SaveManager;

    public Transform player;
    public Transform boxParentPos;
    public AudioSource boxTakedSound;

    public List<Transform> takedBoxes = new List<Transform>();

    public bool isTaked;
    public bool isListEmpty;
    public int stackCount;
    public float objectHight = 0.185f;
    public float duration = 2f;

    public bool isBlocked = false;



    void Update()
    {
        IsEmptyStack();

        if (stackCount >= SaveManager.EventMaxBoxesLoad())
        {
            isBlocked = true;
        }
    }

    void Start()
    {
        CharacterScript = PlayerScript.GetComponent<Character>();
        SaveManager = SaveManager.GetComponent<SavedResources>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isBlocked)
        {
            return;
        }

        if (other.CompareTag("Stacking"))
        {
            boxTakedSound.pitch = Random.Range(0.5f,1.5f);
            boxTakedSound.Play();

            Transform takedBox = other.transform;
            takedBox.tag = ("Taked");
            takedBox.SetParent(boxParentPos);
            TakedBoxesAdd(takedBox);
            takedBox.transform.DOLocalMove(new Vector3(0.1f, 0.6f + objectHight * stackCount, 0.4f), 0.5f);
            takedBox.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }


    public void TakedBoxesAdd(Transform takedBox)
    {
        takedBoxes.Add(takedBox);
        stackCount++;
    }


    public void IsEmptyStack()
    {
        if (boxParentPos.childCount == 0)
        {
            CharacterScript.IsRunningEmpty(true);
        }
        else
        {
            CharacterScript.IsRunningEmpty(false);
        }
    }

}