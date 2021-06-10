using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject blackField;
    public GameObject whiteField;
    public GameObject voidField;

    public static Field[,] board;

    public FigureController controller;
    public static int[,] level;
    public static int[,] structure;
    public static int xSize;
    public static int ySize;

    void Start()
    {
        Layouts.InitializeLevel();
        level = new int[8, 8] {
                { -4, -2, -3, -5, -6, -3, -2, -4 },
                { -1, -1, -1,  0, -1, -1, -1, -1 },
                {  0,  0,  0,  0,  0,  0,  0,  0 },
                {  0,  0,  0,  0,  0,  0,  0,  0 },
                {  0,  0, -1,  0,  0,  0,  0,  0 },
                {  0,  0,  0,  0,  0, -1,  0,  0 },
                {  1,  1,  1,  0,  1,  1,  1,  1 },
                {  4,  2,  3,  6,  5,  3,  2,  4 },
            };

        structure = new int[8, 8] {
                {  1,  1,  1,  1,  1,  1,  1,  1 },
                {  1,  1,  1,  1,  1,  1,  1,  1 },
                {  1,  1,  1,  1,  1,  1,  1,  1 },
                {  1,  1,  1,  1,  1,  1,  1,  1 },
                {  1,  1,  1,  1,  1,  1,  1,  1 },
                {  1,  1,  1,  1,  1,  1,  1,  1 },
                {  1,  1,  1,  1,  1,  1,  1,  1 },
                {  1,  1,  1,  1,  1,  1,  1,  1 },
            };
        controller.Initialize();
        CreateNewBoard();
    }


    void CreateNewBoard()
    {
        
        board = new Field[level.GetLength(0), level.GetLength(1)];

        xSize = level.GetLength(0);
        ySize = level.GetLength(1);

        int fieldID = 1;
        var correctX = 0;
        var correctY = 0;

        for (int x = 0; x < level.GetLength(0); x++)
        {
            for (int y = 0; y < level.GetLength(1); y++)
            {
                correctX = x;
                correctY = y;

                if (structure[x, y] == 1)
                {
                    if (correctX % 2 != 0)
                    {
                        if (correctY % 2 == 0)
                        {
                            board[correctX, correctY] = GenerateField(blackField, fieldID, correctX, correctY, level[correctX, correctY], FieldStatus.fieldTypes.BLACK);
                        }
                        else
                        {
                            board[correctX, correctY] = GenerateField(whiteField, fieldID, correctX, correctY, level[correctX, correctY], FieldStatus.fieldTypes.WHITE);
                        }
                    }
                    else
                    {
                        if (correctY % 2 != 0)
                        {
                            board[correctX, correctY] = GenerateField(blackField, fieldID, correctX, correctY, level[correctX, correctY], FieldStatus.fieldTypes.BLACK);
                        }
                        else
                        {
                            board[correctX, correctY] = GenerateField(whiteField, fieldID, correctX, correctY, level[correctX, correctY], FieldStatus.fieldTypes.WHITE);
                        }
                    }
                }
                else
                {
                    board[correctX, correctY] = GenerateField(voidField, fieldID, correctX, correctY, level[correctX, correctY], FieldStatus.fieldTypes.VOID);
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
                var interaction = tile.AddComponent<FieldInteraction>();
                interaction.field = board[x, y];
                tile.SetActive(true);
                SpawnFigure(fieldSegment.occupations, fieldSegment.pawnType, tile.transform, fieldSegment.xCoord + Utility.CalculateOffset(LevelSelector.xSize), fieldSegment.yCoord + Utility.CalculateOffset(LevelSelector.ySize), board[x, y]);
            }
        }
    }




    void SpawnFigure(FieldStatus.occupations team, PawnType.pawnTypes type, Transform tile, int x, int y, Field field)
    {


        if (type != PawnType.pawnTypes.NONE)
        {
            GameObject figure = new GameObject();
            if (team == FieldStatus.occupations.BLACK)
            {
                figure = Instantiate(FigureController.staticDarkFigures[(int)type - 1], new Vector3(x, .5f, y), Quaternion.identity);
                AddFigureScript(false, type, figure, field);
            }
            else if (team == FieldStatus.occupations.WHITE)
            {
                figure = Instantiate(FigureController.staticLightFigures[(int)type - 1], new Vector3(x, .5f, y), Quaternion.identity);
                AddFigureScript(true, type, figure, field);
            }

            field.figure = figure;
        }

        
    }
        

    void AddFigureScript(bool team, PawnType.pawnTypes type, GameObject figure, Field field)
    {
        


        switch (type)
        {
            case PawnType.pawnTypes.PAWN:
                Pawn pawnMover = figure.AddComponent<Pawn>();
                pawnMover.Initialize(team, field);
                break;

            case PawnType.pawnTypes.KNIGHT:
                Knight knightMover = figure.AddComponent<Knight>();
                knightMover.Initialize(team,field);
                break;

            case PawnType.pawnTypes.BISHOP:
                Bishop bishopMover = figure.AddComponent<Bishop>();
                bishopMover.Initialize(team, field);
                break;


            case PawnType.pawnTypes.ROOK:
                Rook rookMover = figure.AddComponent<Rook>();
                rookMover.Initialize(team, field);
                break;

            case PawnType.pawnTypes.QUEEN:
                Queen queenMover = figure.AddComponent<Queen>();
                queenMover.Initialize(team, field);
                break;

            case PawnType.pawnTypes.KING:
                King kingMover = figure.AddComponent<King>();
                kingMover.Initialize(team,field);
                break;

            default:
                break;
        }
    }

    Field GenerateField(GameObject tile, int id, int x, int y, int side, FieldStatus.fieldTypes status)
    {
        Field field = new Field();

        field.fieldID = id;
        field.xCoord = x;
        field.yCoord = y;
        field.status = status;
        field.field = tile;

        if (side < 0)
        {
            field.occupations = FieldStatus.occupations.WHITE;
        }
        else if (side > 0)
        {
            field.occupations = FieldStatus.occupations.BLACK;
        } else
        {
            field.occupations = FieldStatus.occupations.NONE;
        }
       
        field.pawnType = SetType(side);
        return field;
    }


    PawnType.pawnTypes SetType(int figure)
    {
        switch (Mathf.Abs(figure))
        {
            case 1:
                return PawnType.pawnTypes.PAWN;
            case 2:
                return PawnType.pawnTypes.KNIGHT;
            case 3:
                return PawnType.pawnTypes.BISHOP;
            case 4:
                return PawnType.pawnTypes.ROOK;
            case 5:
                return PawnType.pawnTypes.QUEEN;
            case 6:
                return PawnType.pawnTypes.KING;
            default:
                return PawnType.pawnTypes.NONE;
        }
    }
    

    public static Field GetFieldByCoordninates(int x, int y)
    {
        try
        {
            return board[x, y];
        }
        catch (System.Exception)
        {
            return null;
            throw;
        }
                
    }

        
 

    public static (int,int) GetCoordinatesByField(Field field)
    {
        return (field.xCoord, field.yCoord);
    }

    public Field GetFieldByID(int id)
    {
        Field field;
        for (int x = 0; x < level.GetLength(0); x++)
        {
            for (int y = 0; y < level.GetLength(0); y++)
            {
                field = board[x, y];
                if (field.fieldID == id)
                {
                    return field;
                }
            }
        }
        return null;
    }
}
