using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<int> MonsterList = new List<int>(); // DEX ���� ������ List�� �����մϴ�.
    public List<GameObject> EnemyList = new List<GameObject>(); // DEX�� ���� ���� Enemy�� ������ List�� �����մϴ�.

    public void Start()
    {
        // Enemy �±׸� ���� ��� ������Ʈ�� ã���ϴ�.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // ã�� �� ������Ʈ���� StatusData ��ũ��Ʈ���� DEX ���� �����ͼ� List�� �߰��մϴ�.
        foreach (GameObject enemy in enemies)
        {
            int status = enemy.GetComponent<MonsterTest>().Status.DEX;
            MonsterList.Add(status);
        }

        // List�� ������������ �����մϴ�.
        MonsterList.Sort();
        MonsterList.Reverse();

        // ���ĵ� ������� EnemyList�� �߰��մϴ�.
        foreach (int dexValue in MonsterList)
        {
            GameObject enemy = FindEnemyByDEX(dexValue);
            if (enemy != null)
            {
                EnemyList.Add(enemy);
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

    private GameObject FindHeroByDEX(int dexValue, int RoleNum)
    {
        GameObject[] heroes = GameObject.FindGameObjectsWithTag("Hero");
        foreach (GameObject hero in heroes)
        {
            int status = hero.GetComponent<Test>().characterStatus.statusList[RoleNum].DEX;
            if (status == dexValue)
            {
                return hero;
            }
        }
        return null;
    }
}
