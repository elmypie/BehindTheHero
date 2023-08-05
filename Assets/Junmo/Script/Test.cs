using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TMP_Text DisplayStatus;
    public TMP_Text DisplayEXP;
    public State state;
    private int RoleNum;

    private int CurrHp;

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

        CurrHp = characterStatus.statusList[RoleNum].HP;
    }

    public void Update()
    {
        DisplayStatus.text =
             characterStatus.statusList[RoleNum].Name + "\n" +
           "HP: " + CurrHp + "/" + characterStatus.statusList[RoleNum].HP + "\n" +
           "ATK: " + characterStatus.statusList[RoleNum].ATK + "\n" +
           "DEF: " + characterStatus.statusList[RoleNum].DEF + "\n" +
           "DEX: " + characterStatus.statusList[RoleNum].DEX;
        DisplayEXP.text =
            "LEVEL: " + characterStatus.statusList[RoleNum].LEVEL + "\n" +
            "EXP: " + characterStatus.statusList[RoleNum].EXP + "/" + 10;

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            LevelUP();

            // ����� ���� �����͸� PlayerPrefs�� �����մϴ�.
            characterStatus.SaveCharacterStatus();
        }
    }

    public void Attack() // Attack �Լ�
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemys)
        {
            enemy.GetComponent<MonsterTest>()?.OnDamage(characterStatus.statusList[RoleNum].ATK, RoleNum);
        }
    }


    public void LevelUP() // LevelUP �Լ�
    {
        if (characterStatus.statusList[RoleNum].LEVEL < max.MaxLevel)
        {
            if (characterStatus.statusList[RoleNum].EXP == 10)
            {
                characterStatus.statusList[RoleNum].LEVEL++;
                characterStatus.statusList[RoleNum].EXP = 0;
                StatusUP();
                Debug.Log("�������߽��ϴ�. ���� LEVEL: " + characterStatus.statusList[RoleNum].LEVEL);
            }
        }
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
