using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldTest : MonoBehaviour
{
    public GoldData GoldData;

    public void Awake()
    {
        //GoldData.LoadGold(); // ��� ������ �ʱ�ȭ��
    }
    void Start()
    {
        GoldData.Money = 20;
        Debug.Log("��: "+ GoldData.Money);
        Debug.Log("����: " + GoldData.Mineral);
        Debug.Log("����: " + GoldData.Wood);
        GoldData.SaveGold();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
