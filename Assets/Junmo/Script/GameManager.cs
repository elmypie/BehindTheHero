using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<int> DexList = new List<int>(); // DEX ���� ������ List�� �����մϴ�.
    private List<GameObject> StatusList = new List<GameObject>(); // DEX�� ���� ���� Enemy�� ������ List�� �����մϴ�.
    public List<GameObject> List = new List<GameObject>();

    public void Start()
    {
        TurnSpeed();
        Debug.Log(turn + "��");
    }

    public void TurnSpeed()
    {
        // Enemy �±׸� ���� ��� ������Ʈ�� ã���ϴ�.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] heores = GameObject.FindGameObjectsWithTag("Hero");

        // ã�� �� ������Ʈ���� StatusData ��ũ��Ʈ���� DEX ���� �����ͼ� List�� �߰��մϴ�.
        foreach (GameObject enemy in enemies)
        {
            int M_status = enemy.GetComponent<MonsterTest>().Status.DEX;
            DexList.Add(M_status);
        }
        foreach (GameObject hero in heores)
        {
            int H_status = hero.GetComponent<Test>().characterStatus.DEX;
            DexList.Add(H_status);
        }

        // List�� ������������ �����մϴ�.
        DexList.Sort();
        DexList.Reverse();

        // ���ĵ� ������� EnemyList�� �߰��մϴ�.
        foreach (int dexValue in DexList)
        {
            GameObject enemy = FindEnemyByDEX(dexValue);
            GameObject hero = FindHeroByDEX(dexValue);
            StatusList.Add(hero);
            StatusList.Add(enemy);
        }
        foreach (GameObject w in StatusList)
        {
            if (w != null)
            {
                List.Add(w);
            }
        }
    }

    // DEX ���� ������� �ش� enemy�� ã�� �޼���
    private GameObject FindEnemyByDEX(int dexValue)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            int status = enemy.GetComponent<MonsterTest>().Status.DEX;
            if (status == dexValue)
            {
                return enemy;
            }
        }
        return null;
    }

    private GameObject FindHeroByDEX(int dexValue)
    {
        GameObject[] heroes = GameObject.FindGameObjectsWithTag("Hero");
        foreach (GameObject hero in heroes)
        {
            int status = hero.GetComponent<Test>().characterStatus.DEX;
            if (status == dexValue)
            {
                return hero;
            }
        }
        return null;
    }

    int num;
    int turn = 1;
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (num < List.Count)
            {
                if (List[num].gameObject.tag == "Enemy")
                {
                    if (List[num].gameObject.activeSelf == true)
                    {
                        List[num].GetComponent<MonsterTest>().TurnStart();
                    }
                    else if (List[num].gameObject.activeSelf == false)
                    {
                        Debug.Log(List[num].gameObject.GetComponent<MonsterTest>().Status.name + "��/�� ������ �� ����");
                    }
                }
                else if (List[num].gameObject.tag == "Hero")
                {
                    if (List[num].gameObject.activeSelf == true)
                    {
                        List[num].GetComponent<Test>().TurnStart();
                    }
                    else if (List[num].gameObject.activeSelf == false)
                    {
                        Debug.Log(List[num].gameObject.GetComponent<Test>().characterStatus.name + "��/�� ������ �� ����");
                    }
                }
                num++;
            }
            else
            {
                turn++;
                num = 0;
                DexList.Clear();
                StatusList.Clear();
                List.Clear();
                TurnSpeed();
                Debug.Log(turn + "��");
            }
        }
    }
}
