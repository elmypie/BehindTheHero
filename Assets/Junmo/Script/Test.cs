using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public StatusData characterStatus;
    public MaxStatusData max;

    public void Awake()
    {
        characterStatus.SaveCharacterStatus();
    }
    public void Start()
    {
        tag = characterStatus.statusList[0].Name;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (characterStatus.statusList.Count > 0)
            {
                if (characterStatus.statusList[0].LEVEL < max.MaxLevel)
                {
                    characterStatus.statusList[0].EXP++;
                    Debug.Log("���� EXP: " + characterStatus.statusList[0].EXP);
                    if (characterStatus.statusList[0].EXP == 10)
                    {
                        LevelUP();
                    }
                }
            }
            else
            {
                Debug.Log("ĳ���� �����Ͱ� �����ϴ�.");
            }
            // ����� ���� �����͸� PlayerPrefs�� �����մϴ�.
            characterStatus.SaveCharacterStatus();
        }
    }

    public void LevelUP() // LevelUP �Լ�
    {
        characterStatus.statusList[0].LEVEL++;
        characterStatus.statusList[0].EXP = 0;
        StatusUP();
        Debug.Log("�������߽��ϴ�. ���� LEVEL: " + characterStatus.statusList[0].LEVEL);
    }
    public void StatusUP() // StatusUP �Լ�
    {
        characterStatus.statusList[0].HP++;
        characterStatus.statusList[0].ATK++;
        characterStatus.statusList[0].DEF++;
        characterStatus.statusList[0].DEX++;
        Debug.Log("HP�� 1 �����߽��ϴ�. ���� HP: " + characterStatus.statusList[0].HP);
        Debug.Log("ATK�� 1 �����߽��ϴ�. ���� ATK: " + characterStatus.statusList[0].ATK);
        Debug.Log("DEF�� 1 �����߽��ϴ�. ���� DEF: " + characterStatus.statusList[0].DEF);
        Debug.Log("DEX�� 1 �����߽��ϴ�. ���� DEX: " + characterStatus.statusList[0].DEX);
    }
}
