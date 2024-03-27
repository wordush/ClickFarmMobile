using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceManager : MonoBehaviour
{
    // Переменные для хранения цен
    public int carrotPrice;
    public int lilyPrice;
    public int ricePrice;
    public int lilyJamPrice;
    public int mushroomsPrice;
    public int snailsPrice;
    // Другие переменные цен

    // Статический экземпляр класса для доступа из других скриптов
    public static PriceManager instance;

    private void Awake()
    {
        instance = this;
    }
}
