using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveToDifficulty : MonoBehaviour
{

    public GameObject exitPanel;
    public Button exitButton;
    // Start is called before the first frame update
    void Start()
    {
        exitButton.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                exitPanel.SetActive(true);
            }
        }
    }

    public void GotoClassicnormal()
    {
        SceneManager.LoadScene("Classic_normal");
    }

    public void GoClassicEasy()
    {
        SceneManager.LoadScene("Classic_easy");
    }

    public void GoClassicHard()
    {
        SceneManager.LoadScene("Classic_Hard");
    }

    public void GoInvisibleEasy()
    {
        SceneManager.LoadScene("Invisible_easy");
    }

    public void GoInvisibleNormal()
    {
        SceneManager.LoadScene("Invisible_normal");
    }
    public void GoInvisibleHard()
    {
        SceneManager.LoadScene("Invisible_Hard");
    }

    public void GoNoWallEasy()
    {
        SceneManager.LoadScene("NoWall_easy");
    }

    public void GoNoWallNormal()
    {
        SceneManager.LoadScene("NoWall_Normal");
    }
    public void GoNoWallHard()
    {
        SceneManager.LoadScene("NoWall_Hard");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
