using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    bool isPaused = false;

    public GameObject gamePanel;
    public GameObject pausePanel;

    public PostProcessVolume renderVolume;
    DepthOfField depth;

    void Start()
    {
        renderVolume.profile.TryGetSettings(out depth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (!isPaused)
            {
                isPaused = true;
                StartPauseMenu();
            }
            else
            {
                isPaused = false;
                EndPauseMenu();
            }
        }
    }

    void StartPauseMenu()
    {
        pausePanel.SetActive(true);
        gamePanel.SetActive(false);
        depth.active = true;
    }

    public void EndPauseMenu()
    {
        pausePanel.SetActive(false);
        gamePanel.SetActive(true);
        depth.active = false;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
