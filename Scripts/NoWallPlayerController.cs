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


    //버튼을 누를떄마다 순서대로 저장된 벡터값만큼 이동
    void moveAction()
    {
        transform.Translate(moveDirections[currentIndex]);
        currentIndex = (currentIndex + 1) % moveDirections.Length;



        actionButton.gameObject.SetActive(false);
        wayMoveBut.gameObject.SetActive(true);
    }
    //움직일때 파워 비활성화

    //파워 업이 닿으면 버튼 활성화 
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

            
            //클리어시 나오는 파티클과 효과음 플레이 ui로 클리어 표시 
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
