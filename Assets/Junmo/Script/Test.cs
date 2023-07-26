using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public StatusData characterStatus;

    public void Awake()
    {
        characterStatus.SaveCharacterStatus();
    }
    public void Start()
    {
        // PlayerPrefs���� �����͸� �ҷ��ɴϴ�.
        characterStatus.LoadCharacterStatus();

        if (characterStatus.statusList.Count > 0)
        {
            // ù ��° ĳ������ HP�� 1 ������ŵ�ϴ�.
            characterStatus.statusList[0].HP++;
            characterStatus.statusList[0].LEVEL++;
            Debug.Log("�������߽��ϴ�. ���� LEVEL: " + characterStatus.statusList[0].LEVEL);
            Debug.Log("HP�� 1 �����߽��ϴ�. ���� HP: " + characterStatus.statusList[0].HP);

            // ����� ���� �����͸� PlayerPrefs�� �����մϴ�.
            characterStatus.SaveCharacterStatus();
        }
        else
        {
            Debug.Log("ĳ���� �����Ͱ� �����ϴ�. �������� �����߽��ϴ�.");
        }
    }

    private const int MaxCharacterLevel = 100;

    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("TestScene1");
        }
    }
}