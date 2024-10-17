using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button resetButton;

    public GameObject randomMoveBut;

    public GameObject clearText;
    public GameObject gomainButton;

    void Awake()
    {
        Application.targetFrameRate = 60;

    }
    // Start is called before the first frame update
    void Start()
    {
        resetButton.onClick.AddListener(ResetNowScene);

        randomMoveBut.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        }

        if(clearText.activeSelf == true)
        {
            gomainButton.SetActive(true);
        }
    }


    public void ResetNowScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMain()
    {
        SceneManager.LoadScene(0);
    }
}
