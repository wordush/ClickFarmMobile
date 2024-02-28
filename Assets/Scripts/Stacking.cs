using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SocialPlatforms;
using System.Threading.Tasks;
using System.Linq;

public class Stacking : MonoBehaviour
{
    public Character CharacterScript;
    public GameObject PlayerScript;
    public SavedResources SaveManager;

    public Transform player;
    public Transform boxParentPos;

    public List<Transform> takedBoxes = new List<Transform>();

    public bool isTaked;
    public bool isListEmpty;
    public int stackCount;
    public float objectHight = 0.185f;
    public float duration = 2f;

    private bool isBlocked = false;
    



    void Update()
    {
        if (stackCount > SaveManager.EventMaxBoxesLoad())
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
        
        if(other.CompareTag("Stacking"))
        {
            Transform takedBox = other.transform;
            takedBox.tag = ("Taked");
            takedBox.SetParent(boxParentPos);
            TakedBoxesAdd(takedBox);
            takedBox.transform.DOLocalMove(new Vector3(0.1f, 0.6f + objectHight * stackCount, 0.4f), 0.5f);
            takedBox.localRotation = Quaternion.Euler(0, 0, 0);
            Debug.Log(stackCount);
        }
    }


    public void TakedBoxesAdd(Transform takedBox)
    {
        takedBoxes.Add(takedBox);
        stackCount++;
        IsEmptyStack();
    }


    public async void TakedBoxesReduce(Transform takedBox)
    {
        if (stackCount > 0) 
        {
            await Task.Delay(300);
            takedBox.gameObject.SetActive(false);
            stackCount--; 
            IsEmptyStack(); 
        }
    }

    public void IsEmptyStack()
    {
        if (stackCount == 0)
        {
            //takedBoxes.Clear();
            CharacterScript.IsRunningEmpty(true);
        }
        else
        {
            CharacterScript.IsRunningEmpty(false);
        }
    }
}