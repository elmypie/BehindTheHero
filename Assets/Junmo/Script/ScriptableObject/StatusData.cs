using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "New Status Data", menuName = "Custom/Status Data")]
public class StatusData : ScriptableObject
{
    //public List<status> statusList = new List<status>();

    [SerializeField]
    public string Name;
    [SerializeField]
    public int LEVEL;
    [SerializeField]
    public int EXP;
    [SerializeField]
    public int HP;
    [SerializeField]
    public int ATK;
    [SerializeField]
    public int DEF;
    [SerializeField]
    public int DEX;

    // �����͸� PlayerPrefs�� �����ϴ� �޼���
    public void SaveCharacterStatus()
    {
        string jsonData = JsonUtility.ToJson(this);
        PlayerPrefs.SetString("CharacterStatusData", jsonData);
        PlayerPrefs.Save();
    }

    // PlayerPrefs�κ��� �����͸� �ҷ����� �޼���
    public void LoadCharacterStatus()
    {
        if (PlayerPrefs.HasKey("CharacterStatusData"))
        {
            string jsonData = PlayerPrefs.GetString("CharacterStatusData");
            JsonUtility.FromJsonOverwrite(jsonData, this);
        }
    }
}
