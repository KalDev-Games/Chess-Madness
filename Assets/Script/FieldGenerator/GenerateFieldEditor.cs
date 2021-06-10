using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFieldEditor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject blackField;
    public GameObject whiteField;
    public GameObject voidField;

    public static Material staticBlackMaterial;
    public static Material staticWhiteMaterial;
    public static Material staticVoidMaterial;

    public Material blackMaterial;
    public Material whiteMaterial;
    public Material voidMaterial;

    public static Field[,] board;



    public static int[,] level;
    public static int[,] structure;


    void Start()
    {
        EqualizeFields();
        Layouts.InitializeLevel();
        level = GenerateBlankLevel(0);
        structure = GenerateBlankLevel(1);
        CreateNewBoard();
    }

    
    void EqualizeFields()
    {
        staticBlackMaterial = blackMaterial;
        staticWhiteMaterial = whiteMaterial;
        staticVoidMaterial = voidMaterial;
    }

    void CreateNewBoard()
    {

        board = new Field[level.GetLength(0), level.GetLength(1)];

        


        int fieldID = 1;
        var correctX = 0;
        var correctY = 0;

        for (int x = 0; x < level.GetLength(0); x++)
        {
            for (int y = 0; y < level.GetLength(1); y++)
            {
                correctX = x;
                correctY = y;

                if (correctX % 2 != 0)
                {
                    if (correctY % 2 == 0)
                    {
                        board[correctX, correctY] = GenerateEditableField(blackField, fieldID, correctX, correctY, FieldStatus.fieldTypes.BLACK);
                    }
                    else
                    {
                        board[correctX, correctY] = GenerateEditableField(whiteField, fieldID, correctX, correctY, FieldStatus.fieldTypes.WHITE);
                    }
                }
                else
                {
                    if (correctY % 2 != 0)
                    {
                        board[correctX, correctY] = GenerateEditableField(blackField, fieldID, correctX, correctY, FieldStatus.fieldTypes.BLACK);
                    }
                    else
                    {
                        board[correctX, correctY] = GenerateEditableField(whiteField, fieldID, correctX, correctY, FieldStatus.fieldTypes.WHITE);
                    }
                }

                fieldID++;
            }
        }

        for (int x = 0; x < board.GetLength(0); x++)
        {
            for (int y = 0; y < board.GetLength(1); y++)
            {
                var fieldSegment = board[x, y];
                var tile = Instantiate(fieldSegment.field, new Vector3(fieldSegment.xCoord + Utility.CalculateOffset(LevelSelector.xSize), 0, fieldSegment.yCoord + Utility.CalculateOffset(LevelSelector.ySize)), Quaternion.identity, transform);
                var interaction = tile.AddComponent<ChangeFieldAttributes>();
                tile.SetActive(true);
                interaction.field = board[x, y];

                
            }
        }
    }

    
    

    Field GenerateEditableField(GameObject tile, int id, int x, int y, FieldStatus.fieldTypes status)
    {
        Field field = new Field();

        field.fieldID = id;
        field.xCoord = x;
        field.yCoord = y;
        field.status = status;
        field.field = tile;
        field.occupations = FieldStatus.occupations.NONE;


        return field;
    }

    int[,] GenerateBlankLevel(int value)
    {
        int[,] blank = new int[LevelSelector.xSize, LevelSelector.ySize];
        for (int x = 0; x < LevelSelector.xSize; x++)
        {
            for (int y = 0; y < LevelSelector.ySize; y++)
            {
                blank[x, y] = value;
            }
        }

        return blank;
    }
    


    
}
