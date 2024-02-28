using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Task = System.Threading.Tasks.Task;

public class SellingPoint : MonoBehaviour
{
    public Stacking Stacking;
    public Character Character;
    public GameObject playerScript;
    public Transform TransformSellPosition;
    public Vector3 targetPosition;
    public float jumpPower = 1f;
    public int numJumps = 1;
    public float duration = 2f;
    public float yBoxAxes = 0.0f;
    public float boxDelay;
    public Transform BoxParentPos;

    public void OnTriggerEnter(Collider other)
    {
         ColliderEvent(other);
    }

    void Start()
    {
        Character = Character.GetComponent<Character>();
        Stacking = Stacking.GetComponent<Stacking>();
    }

    public async void ColliderEvent(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Stacking.isBlocked = false;
            var boxesLocalCopy = Stacking.takedBoxes;
            Stacking.takedBoxes.Clear();
            for (var index = boxesLocalCopy.Count - 1; index >= 0; index--)
            {
                await Task.Delay(300);
                boxesLocalCopy[index].DOJump(new Vector3(TransformSellPosition.position.x, yBoxAxes, TransformSellPosition.position.z), jumpPower, numJumps, duration)
                    .SetDelay(boxDelay).SetEase(Ease.Flash);
                boxesLocalCopy.ElementAt(index).parent = TransformSellPosition;
                yBoxAxes += 0.2f;
                boxDelay += 0.02f;

            }
            
        }
    }
    public void IsBoxParentEmpty()
    {
        if(BoxParentPos.childCount == 0)
        {
            Stacking.isListEmpty = true;
        }
    }
}