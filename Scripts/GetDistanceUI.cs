using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetDistanceUI : MonoBehaviour
{
    public float distanceLimit;

    private Vector3 lastPosition;
    private float totalDistance = 0f;
    private bool isGameOver = false;

    public TextMeshProUGUI distanceText;
    public GameObject gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isGameOver)
        {
            //거리추가로직
            totalDistance += Vector3.Distance(transform.position, lastPosition);
            lastPosition = transform.position;
            //text거리계산
            distanceText.text = "이동거리 : " + Mathf.RoundToInt(totalDistance).ToString();
        }

        if (totalDistance > distanceLimit)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverText.SetActive(true);
        
    }
}
