using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Rigidbody2D rigid;
    public GoldData collect;

    public string item;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Target")
        {

            switch (item)
            {
                case "Wood":
                    Debug.Log("���� 1�� ȹ��");
                    collect.Wood++;
                    Debug.Log("����:"+collect.Wood);
                    Destroy(gameObject);
                    break;

                case "gold":
                    Debug.Log("��� 1�� ȹ��");
                    collect.Money++;
                    Debug.Log("��:" + collect.Money);
                    Destroy(gameObject);
                    break;

                case "mineral":
                    Debug.Log("���� 1�� ȹ��");
                    collect.Mineral++;
                    Debug.Log("����:" + collect.Mineral);
                    Destroy(gameObject);
                    break;
            }

        }
    }
}
