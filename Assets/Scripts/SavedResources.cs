using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SavedResources : MonoBehaviour
{
    public int money;
    public int maxBoxesToTake;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI maxBoxesToTakeText;
    public Button AddMoney;
    public Button AddBoxes;
    
    // Start is called before the first frame update
    void Start()
    {
        StartValuesLoad();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public void MaxBoxesAdd(int count)
    {
        maxBoxesToTake += count;
        PlayerPrefs.SetInt("maxBoxesToTake", maxBoxesToTake);
        PlayerPrefs.Save();
        maxBoxesToTakeText.text = "" + maxBoxesToTake;
    }

    public void MaxBoxesRemove(int count)
    {
        maxBoxesToTake -= count;
        PlayerPrefs.SetInt("maxBoxesToTake", maxBoxesToTake);
        PlayerPrefs.Save();
        maxBoxesToTakeText.text = "" + maxBoxesToTake;
    }

    public void EventMoneyAdd(int count)
    {
        money += count;
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.Save();
        moneyText.text = "" + money;
    }

    public void EventMoneyReduce(int count)
    {
        money -= count;
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.Save();
        moneyText.text = "" + money;
    }

    public void StartValuesLoad()
    {
        money = PlayerPrefs.GetInt("money");
        moneyText.text = "" + money;
        EventMaxBoxesLoad();
    }

    public int EventMaxBoxesLoad()
    {
        maxBoxesToTake = PlayerPrefs.GetInt("maxBoxesToTake");
        maxBoxesToTakeText.text = "" + maxBoxesToTake;
        return maxBoxesToTake;
    }

    public void ___TESTBOXES()
    {
        MaxBoxesAdd(2);
    }
    public void ___TESTBOXESMINUS()
    {
        MaxBoxesRemove(2);
    }
    public void ___TESTMONEY()
    {
        EventMoneyAdd(110);
    }

}
