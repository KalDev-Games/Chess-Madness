using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : FigureController
{
    public void Initialize(bool team, Field field)
    {
        nameOfPawn = "KNIGHT";
        canWalkBackwards = true;
        pawnType = PawnType.pawnTypes.KNIGHT;
        currentField = field;
        alreadyMoved = false;
        isMoveable = true;
        if (team)
        {
            this.team = true;
            figure = staticLightFigures[0];
        }
        else
        {
            this.team = false;
            figure = staticDarkFigures[0];
        }


        if (team)
        {
            figureValue = 30;
        }
        else
        {
            figureValue = -30;
        }
        //GetAllMoveablePositions();
    }

    public List<Field> GetAllMoveablePositions()
    {
        target = new List<Field>();
 




        FieldStatus.occupations occupation;

        if (team)
        {
            occupation = FieldStatus.occupations.WHITE;
        }
        else
        {
            occupation = FieldStatus.occupations.BLACK;
        }
        print(0);

        target = GetNeccessaryFields(currentField.xCoord +1, currentField.yCoord - 2, target, occupation);
        target = GetNeccessaryFields(currentField.xCoord +1, currentField.yCoord + 2, target, occupation);
        target = GetNeccessaryFields(currentField.xCoord +2, currentField.yCoord - 1, target, occupation);
        target = GetNeccessaryFields(currentField.xCoord +2, currentField.yCoord + 1, target, occupation);
        target = GetNeccessaryFields(currentField.xCoord -2, currentField.yCoord - 1, target, occupation);
        target = GetNeccessaryFields(currentField.xCoord -2, currentField.yCoord + 1, target, occupation);
        target = GetNeccessaryFields(currentField.xCoord -1, currentField.yCoord - 2, target, occupation);
        target = GetNeccessaryFields(currentField.xCoord -1, currentField.yCoord + 2, target, occupation);


        return target;



    }

    List<Field> GetNeccessaryFields(int x, int y, List<Field> fields, FieldStatus.occupations occupations)
    {
        Field field = Board.GetFieldByCoordninates(x,y);

        if (field != null)
        {
            if (field.occupations != occupations)
            {
                fields.Add(field);
                
            }
            
        }
        return fields;
    }


    void OnMouseDown()
    {
        if (Player.currentPlayer == team)
        {
            if (!Player.cardIsUsed)
            {
                print(name);
                GetAllMoveablePositions();
                Player.selectedField = currentField;
                Player.currentFigure = gameObject;
                alreadyMoved = true;
            }
            else
            {
                CardAction.SelectAction();
            }
        }

    }
}
