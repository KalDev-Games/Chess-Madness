using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field
{
    public Board board;
    public int fieldID;
    public int xCoord;
    public int yCoord;
    public bool team;
    
    public Field[] neighbors = new Field[8];
    private bool teamFigure;
    public GameObject field;

    public FieldStatus.fieldTypes status;
    public PawnType.pawnTypes pawnType;
    public FieldStatus.occupations occupations;
    public GameObject figure;

    public void SpawnFigure()
    {
        switch (pawnType)
        {
            case PawnType.pawnTypes.PAWN:
                break;
            case PawnType.pawnTypes.KNIGHT:
                break;
            case PawnType.pawnTypes.BISHOP:
                break;
            case PawnType.pawnTypes.ROOK:
                break;
            case PawnType.pawnTypes.QUEEN:
                break;
            case PawnType.pawnTypes.KING:
                break;
            default:
                break;
        }
    }

    public void GetAllNeighbors()
    {
        // -1/1     1/0     1/1
        // -1/0     0/0     1/0
        // -1/-1    -1/0    -1/1


        neighbors[0] = Board.GetFieldByCoordninates(xCoord, yCoord + 1);
        neighbors[1] = Board.GetFieldByCoordninates(xCoord + 1, yCoord + 1); 
        neighbors[2] = Board.GetFieldByCoordninates(xCoord + 1 , yCoord); 
        neighbors[3] = Board.GetFieldByCoordninates(xCoord + 1, yCoord - 1); 
        neighbors[4] = Board.GetFieldByCoordninates(xCoord, yCoord - 1); 
        neighbors[5] = Board.GetFieldByCoordninates(xCoord - 1, yCoord + 1); 
        neighbors[6] = Board.GetFieldByCoordninates(xCoord, yCoord + 1); 
        neighbors[7] = Board.GetFieldByCoordninates(xCoord, yCoord + 1); 

    }

    

    
}
