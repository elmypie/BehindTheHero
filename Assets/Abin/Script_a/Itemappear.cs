using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Itemappear : MonoBehaviour
{
    public Vector2 inputVec;
    Rigidbody2D rigid;

    public bool isdown;
    public float Pushtime = 0;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Target")
        {
            Debug.Log("�̺�Ʈ�߻�");
            if (Input.GetKey(KeyCode.Space))
            {
                //isdown = true;
                Debug.Log("ä�� ����.");
                if (true)
                {
                    Pushtime += Time.deltaTime;
                    if (Pushtime == 5)
                    {
                        Destroy(gameObject);
                    }
                }

                else
                {
                    Pushtime = 0;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                isdown = false;
            }
        }
    }
}
