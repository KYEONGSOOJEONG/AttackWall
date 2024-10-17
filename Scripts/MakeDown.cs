using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDown : MonoBehaviour
{
    public GameObject swich;

    float timer;
    int waitingTime;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        waitingTime = 2;


    }

    // Update is called once per frame
    void Update()
    {
        //�ӹ����� �������� �ð��帣�� �ð��帣�� �Ŀ��� �ϰ�
        if (gameObject.activeSelf)
        {
            timer += Time.deltaTime;

            if (timer > waitingTime)
            {
                transform.position += Vector3.down * Time.deltaTime;
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            transform.position = new Vector3(transform.position.x,transform.position.y+2.5f,transform.position.z);
        }
    }

}    
