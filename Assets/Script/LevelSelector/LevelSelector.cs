using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public static int xSize = 8;
    public static int ySize = 8;

    public static int arenaIndex = 0;

    public Sprite[] arenaPics;
    public string[] arenaNames;

    public Image arenaViewDisplay;


    public Toggle toggleBaseLayout;

    public Text arenaDisplay;
    public Text xSizeDisplay;
    public Text ySizeDisplay;

    private int offset = 3;

    void Start()
    {
        arenaIndex = 0;
        xSize = 8;
        ySize = 8;
        UpdateUI();
    }

    // Update is called once per frame

    public void IncreaseXSize()
    {
        if (xSize <= 15)
        {
            xSize++;
        }
    }

    public void DecreaseXSize()
    {
        if (xSize >= 3)
        {
            xSize--;
        }
    }

    public void IncreaseYSize()
    {
        if (ySize <= 15)
        {
            ySize++;
        }
    }

    public void DecreaseYSize()
    {
        if (ySize >= 3)
        {
            ySize--;
        }
    }

    public void IncreaseLevel()
    {
        if (arenaIndex < arenaNames.Length - 1)
        {
            arenaIndex++;
        }
    }

    public void DecreaseLevel()
    {
        if (arenaIndex >= 1)
        {
            arenaIndex--;
        }
    }

    public void StartLevel()
    {
        if (toggleBaseLayout.isOn)
        {
            Board.level = new int[8, 8] {
                { -4, -3, -3, -6, -5, -3, -3, -4 },
                { -1, -1, -1, -1, -1, -1, -1, -1 },
                {  0,  0,  0,  0,  0,  0,  0,  0 },
                {  0,  0,  0,  0,  0,  0,  0,  0 },
                {  0,  0,  0,  0,  0,  0,  0,  0 },
                {  0,  0,  0,  0,  0,  0,  0,  0 },
                {  1,  1,  1,  1,  1,  1,  1,  1 },
                {  4,  3,  3,  6,  5,  3,  3,  4 },
            };

            Board.structure = new int[8, 8] {
                {  1,  1,  1,  1,  1,  1,  1,  1 },
                {  1,  1,  1,  1,  1,  1,  1,  1 },
                {  1,  1,  1,  1,  1,  1,  1,  1 },
                {  1,  1,  1,  1,  1,  1,  1,  1 },
                {  1,  1,  1,  1,  1,  1,  1,  1 },
                {  1,  1,  1,  1,  1,  1,  1,  1 },
                {  1,  1,  1,  1,  1,  1,  1,  1 },
                {  1,  1,  1,  1,  1,  1,  1,  1 },
            };

            SceneManager.LoadScene(arenaIndex + offset);
        }
        else
        {
            arenaIndex += offset;
            SceneManager.LoadScene("CreateLevel");
        }
       
    }

    public void mainMenu()
    {
       
            SceneManager.LoadScene("MainMenu");
        
    }

    public void UpdateUI()
    {
        arenaDisplay.text = arenaNames[arenaIndex];
        arenaViewDisplay.sprite = arenaPics[arenaIndex];

        xSizeDisplay.text = xSize.ToString();
        ySizeDisplay.text = ySize.ToString();

        if (xSize == 8 && ySize == 8)
        {
            
            toggleBaseLayout.interactable = true;
        }
        else
        {
            toggleBaseLayout.isOn = false;
            toggleBaseLayout.interactable = false;
        }
    }
}
