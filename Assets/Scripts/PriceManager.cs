using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceManager : MonoBehaviour
{
    // ���������� ��� �������� ���
    public int carrotPrice;
    public int lilyPrice;
    public int ricePrice;
    public int lilyJamPrice;
    public int mushroomsPrice;
    public int snailsPrice;
    // ������ ���������� ���

    // ����������� ��������� ������ ��� ������� �� ������ ��������
    public static PriceManager instance;

    private void Awake()
    {
        instance = this;
    }
}
