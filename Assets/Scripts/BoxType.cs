using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BoxTypeList
{
    Carrot,
    LilyFlower,
    Rice,
    LilyJam,
    Mushrooms,
    Snails,
}

public class BoxType : MonoBehaviour
{
    public BoxTypeList boxTypeList;


    public BoxTypeList GetBoxType()
    {
        return boxTypeList;
    }

    public int GetPrice()
    {
        switch (boxTypeList)
        {
            case BoxTypeList.Carrot:
                return PriceManager.instance.carrotPrice;

            case BoxTypeList.LilyFlower:
                return PriceManager.instance.lilyPrice;

            case BoxTypeList.Rice:
                return PriceManager.instance.ricePrice;

            case BoxTypeList.LilyJam:
                return PriceManager.instance.lilyJamPrice;

            case BoxTypeList.Mushrooms:
                return PriceManager.instance.mushroomsPrice;

            case BoxTypeList.Snails:
                return PriceManager.instance.snailsPrice;

            default:
                return 0;
        }
    }
}