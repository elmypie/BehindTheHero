using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public enum State
    {
        Warrior,
        Healer,
        Wizard,
        Thief
    }

    public StatusData characterStatus;
    public MaxStatusData max;
    public TMP_Text DisplayStatus;
    public TMP_Text DisplayEXP;
    public State state;

    private int HP;
    private int CurrHp;
    private int ATK;
    private int DEF;
    private int DEX;

    public void Awake()
    {
        characterStatus.SaveCharacterStatus();
    }
    public void Start()
    {
        HP = characterStatus.HP;
        CurrHp = characterStatus.HP;
        ATK = characterStatus.ATK;
        DEF = characterStatus.DEF;
        DEX = characterStatus.DEX;
        if (state == State.Warrior)
        {
            characterStatus.Name = "Warrior";
            DEF += 2;
        }
        else if (state == State.Healer)
        {
            characterStatus.Name = "Healer";
            HP += 2;
            CurrHp += 2;
        }
        else if (state == State.Wizard)
        {
            characterStatus.Name = "Wizard";
            ATK += 2;
        }
        else if (state == State.Thief)
        {
            characterStatus.Name = "Thief";
            //DEX += 2;
        }
    }

    public void Update()
    {
        //ȭ�鿡 ����â
        DisplayStatus.text =
             characterStatus.Name + "\n" +
           "HP: " + CurrHp + "/" + HP + "\n" +
           "ATK: " + ATK + "\n" +
           "DEF: " + DEF + "\n" +
           "DEX: " + DEX;
        DisplayEXP.text =
            "LEVEL: " + characterStatus.LEVEL + "\n" +
            "EXP: " + characterStatus.EXP + "/" + 10;

        // ����� ���� �����͸� PlayerPrefs�� �����մϴ�.
        characterStatus.SaveCharacterStatus();
    }

    public void Attack() // Attack �Լ�
    {
        Debug.Log(characterStatus.name + " �� ����");
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemys)
        {
            enemy.GetComponent<MonsterTest>()?.OnDamage(ATK);
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


    public void LevelUP(int EXP) // LevelUP �Լ�
    {
        if (characterStatus.LEVEL < max.MaxLevel)
        {
            characterStatus.EXP += EXP;
            Debug.Log("EXP" + EXP + "�� ������ϴ�.");
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
        //characterStatus.DEX++;
        Debug.Log("HP�� 1 �����߽��ϴ�. ���� HP: " + characterStatus.HP);
        Debug.Log("ATK�� 1 �����߽��ϴ�. ���� ATK: " + characterStatus.ATK);
        Debug.Log("DEF�� 1 �����߽��ϴ�. ���� DEF: " + characterStatus.DEF);
        //Debug.Log("DEX�� 1 �����߽��ϴ�. ���� DEX: " + characterStatus.DEX);
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
