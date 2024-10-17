using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    private float moveSpeed = 3.3f;
    private bool isClear;
    private bool isRRotate;
    private bool isLRotate;


    private AudioSource clearAudio;
    private AudioSource walkingAudio;
    public GameObject clearText;
    public ParticleSystem clearPtcle;
    public FixedJoystick joy;
    public GameObject gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        isClear = false;
        isRRotate = false;
        isLRotate = false;

        clearText.SetActive(false);


        clearAudio = GameObject.Find("Exit Zone").GetComponent<AudioSource>();
        walkingAudio = GetComponent<AudioSource>();
        
    }

    void FixedUpdate()
    {


        if (isClear == false && gameOverText.activeSelf == false)
        {
            float h = joy.Horizontal;
            float v = joy.Vertical;
            Vector3 move = transform.forward * v + transform.right * h;

            transform.position += move.normalized * moveSpeed * Time.deltaTime;

            if (h != 0 || v != 0)
            {
                if (walkingAudio.isPlaying == false)
                {
                    walkingAudio.loop = true;
                    walkingAudio.Play();
                }
            }
            else
            {
                if (walkingAudio.isPlaying == true)
                {
                    walkingAudio.Stop();
                }
            }

            if (isRRotate == true)
            {
                transform.Rotate(0, 90 * Time.deltaTime, 0);
            }

            if (isLRotate == true)
            {
                transform.Rotate(0, -90 * Time.deltaTime, 0);
            }

        }
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ExitZone"))
        {
            isClear = true;
            clearText.SetActive(true);
            clearPtcle.Play();
            clearAudio.Play();
            
            walkingAudio.Stop();

            //Ŭ����� ������ ��ƼŬ�� ȿ���� �÷��� ui�� Ŭ���� ǥ�� 
        }
    }
    //3ĭ�� �̵��ϰ� Ŭ���� ���� �����ؼ� ����ϴ� ����� ���������� �̵��ϰ� �̵��� �Ÿ��� �����ϴ� ��� ���� �ϳ�
    //
    //ȸ���ϴ� ������� 90���� ȸ���ϴµ� ��ư�� �ΰ��� �ؼ� 90���� ������ �������� ȸ���ϴ� ���
    //��ư 1���� 90���� ��� ȸ���ϴ� ��� 2���� �߿� �����ϰų� ���̵��� �ٸ����ؼ� �����ϱ�

    //Ŭ���� ȸ���ϴ� ���
    public void OnRightPointerDown()
    {
        isRRotate = true;
    }

    public void OnRightPointerUp()
    {
        isRRotate = false;
    }

    public void OnLeftPointerDown()
    {
        isLRotate = true;
    }

    public void OnLeftPointerUp()
    {
        isLRotate = false;
    }

}
