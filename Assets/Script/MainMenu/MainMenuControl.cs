using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    // Start is called before the first frame update
    public void CreateLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
