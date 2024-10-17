using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NoWallPlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3[] moveDirections;
    public Button actionButton;
    public GameObject clearText;
    public ParticleSystem clearPtcle;

    public GameObject wayMoveBut;
    private AudioSource clearAudio;


    private bool isClear;
    private int currentIndex = 0;
    public float moivinglength = 1.5f;

    void Start()
    {
        actionButton.onClick.AddListener(moveAction);

        clearAudio = GameObject.Find("Exit Zone").GetComponent<AudioSource>();
        clearText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isClear)
        {
            actionButton.gameObject.SetActive(false);
            wayMoveBut.gameObject.SetActive(false); 
        }
    }


    //��ư�� ���������� ������� ����� ���Ͱ���ŭ �̵�
    void moveAction()
    {
        transform.Translate(moveDirections[currentIndex]);
        currentIndex = (currentIndex + 1) % moveDirections.Length;



        actionButton.gameObject.SetActive(false);
        wayMoveBut.gameObject.SetActive(true);
    }
    //�����϶� �Ŀ� ��Ȱ��ȭ

    //�Ŀ� ���� ������ ��ư Ȱ��ȭ 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerOn"))
        {

            actionButton.gameObject.SetActive(true);
        }

        if (other.gameObject.CompareTag("ExitZone"))
        {
            isClear = true;
            clearText.SetActive(true);
            clearPtcle.Play();
            clearAudio.Play();

            
            //Ŭ����� ������ ��ƼŬ�� ȿ���� �÷��� ui�� Ŭ���� ǥ�� 
        }
    }



    public void GoRight()
    {
        transform.Translate(Vector3.right * moivinglength);
        wayMoveBut.gameObject.SetActive(false);
    }

    public void GoLeft()
    {
        transform.Translate(Vector3.left *moivinglength);
        wayMoveBut.gameObject.SetActive(false);
    }

    public void GoForward()
    {
        transform.Translate(Vector3.forward * moivinglength);
        wayMoveBut.gameObject.SetActive(false);
    }

    public void GoBack()
    {
        transform.Translate(Vector3.back * moivinglength);
        wayMoveBut.gameObject.SetActive(false);
    }
}
