using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public enum State
    {
        Warrior,
        Archer,
        Wizard,
        Thief
    }

    public StatusData characterStatus;
    public MaxStatusData max;
    public State state;
    private int RoleNum;

    public void Awake()
    {
        characterStatus.SaveCharacterStatus();
    }
    public void Start()
    {
        if (state == State.Warrior)
            RoleNum = 0;
        else if (state == State.Archer)
             RoleNum = 1;
        else if (state == State.Wizard)
            RoleNum = 2;
        else if (state == State.Thief)
            RoleNum = 3;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemys)
            {
                enemy.GetComponent<MonsterTest>()?.OnDamage(characterStatus.statusList[RoleNum].ATK, RoleNum);
            }

            if (characterStatus.statusList.Count > 0)
            {
                if (characterStatus.statusList[RoleNum].LEVEL < max.MaxLevel)
                {
                    if (characterStatus.statusList[RoleNum].EXP == 10)
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
        characterStatus.statusList[RoleNum].LEVEL++;
        characterStatus.statusList[RoleNum].EXP = 0;
        StatusUP();
        Debug.Log("�������߽��ϴ�. ���� LEVEL: " + characterStatus.statusList[RoleNum].LEVEL);
    }
    public void StatusUP() // StatusUP �Լ�
    {
        characterStatus.statusList[RoleNum].HP++;
        characterStatus.statusList[RoleNum].ATK++;
        characterStatus.statusList[RoleNum].DEF++;
        characterStatus.statusList[RoleNum].DEX++;
        Debug.Log("HP�� 1 �����߽��ϴ�. ���� HP: " + characterStatus.statusList[RoleNum].HP);
        Debug.Log("ATK�� 1 �����߽��ϴ�. ���� ATK: " + characterStatus.statusList[RoleNum].ATK);
        Debug.Log("DEF�� 1 �����߽��ϴ�. ���� DEF: " + characterStatus.statusList[RoleNum].DEF);
        Debug.Log("DEX�� 1 �����߽��ϴ�. ���� DEX: " + characterStatus.statusList[RoleNum].DEX);
    }
}
