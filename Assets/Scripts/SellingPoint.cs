using DG.Tweening;
using System.Linq;
using UnityEngine;
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
            var boxesLocalCopy = new Transform[Stacking.takedBoxes.Count];
            Stacking.takedBoxes.CopyTo(boxesLocalCopy);
            Stacking.takedBoxes.Clear();
            Stacking.stackCount = 0;
            
            for (var index = boxesLocalCopy.Length - 1; index >= 0; index--)
            {
                await Task.Delay(300);
                boxesLocalCopy[index].DOJump(new Vector3(TransformSellPosition.position.x, yBoxAxes, TransformSellPosition.position.z), jumpPower, numJumps, duration)
                    .SetDelay(boxDelay).SetEase(Ease.Flash);
                boxesLocalCopy[index].parent = TransformSellPosition;
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