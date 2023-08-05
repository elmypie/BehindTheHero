using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
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

        CurrHp = characterStatus.HP;
    }

    public void Update()
    {
        DisplayStatus.text =
             characterStatus.Name + "\n" +
           "HP: " + CurrHp + "/" + characterStatus.HP + "\n" +
           "ATK: " + characterStatus.ATK + "\n" +
           "DEF: " + characterStatus.DEF + "\n" +
           "DEX: " + characterStatus.DEX;
        DisplayEXP.text =
            "LEVEL: " + characterStatus.LEVEL + "\n" +
            "EXP: " + characterStatus.EXP + "/" + 10;

        if (Input.GetMouseButtonDown(0))
        {
            //Attack();
        }
        // ����� ���� �����͸� PlayerPrefs�� �����մϴ�.
        characterStatus.SaveCharacterStatus();
    }

    public void Attack() // Attack �Լ�
    {
        Debug.Log(characterStatus.name + " �� ����");
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemys)
        {
            enemy.GetComponent<MonsterTest>()?.OnDamage(characterStatus.ATK, RoleNum);
            LevelUP();
        }
    }

    public void OnDamage(int ATK)
    {
        CurrHp = CurrHp - ATK;
        Debug.Log(ATK + "��ŭ�� ���ظ� �Ծ���");
        if (CurrHp <= 0)
        {
            Debug.Log(characterStatus.name + "�� ���������ϴ�");
            CurrHp = 0;
            Invoke("Die", 0.2f);
        }
    }


    public void LevelUP() // LevelUP �Լ�
    {
        if (characterStatus.LEVEL < max.MaxLevel)
        {
            if (characterStatus.EXP == 10)
            {
                characterStatus.LEVEL++;
                characterStatus.EXP = 0;
                StatusUP();
                Debug.Log("�������߽��ϴ�. ���� LEVEL: " + characterStatus.LEVEL);
            }
        }
    }
    public void StatusUP() // StatusUP �Լ�
    {
        characterStatus.HP++;
        characterStatus.ATK++;
        characterStatus.DEF++;
        characterStatus.DEX++;
        Debug.Log("HP�� 1 �����߽��ϴ�. ���� HP: " + characterStatus.HP);
        Debug.Log("ATK�� 1 �����߽��ϴ�. ���� ATK: " + characterStatus.ATK);
        Debug.Log("DEF�� 1 �����߽��ϴ�. ���� DEF: " + characterStatus.DEF);
        Debug.Log("DEX�� 1 �����߽��ϴ�. ���� DEX: " + characterStatus.DEX);
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
