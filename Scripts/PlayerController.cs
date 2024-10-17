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

            //클리어시 나오는 파티클과 효과음 플레이 ui로 클리어 표시 
        }
    }
    //3칸씩 이동하고 클릭한 양을 측정해서 기록하는 방법과 지속적으로 이동하고 이동한 거리를 측정하는 방법 둘중 하나
    //
    //회전하는 방법에서 90도씩 회전하는데 버튼을 두개로 해서 90도씩 오른쪽 왼쪽으로 회전하는 방법
    //버튼 1개로 90도씩 계속 회전하는 방법 2가지 중에 선택하거나 난이도를 다르게해서 설정하기

    //클릭시 회전하는 기능
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
