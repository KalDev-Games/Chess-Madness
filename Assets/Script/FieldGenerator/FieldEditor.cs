using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FieldEditor : MonoBehaviour
{
    public enum EditModes
    {
        Tile,
        Color,
        Figure
    }


    public static EditModes mode;
    

    public void SwapMode(int modeSelect)
    {
        switch (modeSelect)
        {
            case 1:
                mode = EditModes.Color;
                break;
            case 2:
                mode = EditModes.Figure;
                break;
            default:
                mode = EditModes.Tile;
                break;
        }

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("LevelSelector");
    }
    public void StartGame()
    {
        Board.level = GenerateFieldEditor.level;
        Board.structure = GenerateFieldEditor.structure;

        bool blackKing = false;
        bool whiteKing = false;

        for (int x = 0; x < Board.level.GetLength(0); x++)
        {
            for (int y = 0; y < Board.level.GetLength(1); y++)
            {
                if (Board.level[x, y] == 6 && whiteKing)
                {
                    continue;
                }
                if (Board.level[x, y] == -6 && blackKing)
                {
                    continue;
                }


                if (Board.level[x,y] == 6)
                {
                    whiteKing = true;
                    print("found white king at [" +x + "|" + y + "]" );
                }
                if (Board.level[x,y] == -6)
                {
                    blackKing = true;
                    print("found black king at [" + x + "|" + y + "]");
                }


            }
        }

        if (whiteKing && blackKing)
        {
            
            SceneManager.LoadScene(LevelSelector.arenaIndex);
        }
        
    }



}
