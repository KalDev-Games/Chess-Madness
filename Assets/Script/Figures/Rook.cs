using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : FigureController
{
    public void Initialize(bool team, Field field)
    {
        nameOfPawn = "ROOK";
        canWalkBackwards = true;
        pawnType = PawnType.pawnTypes.ROOK;
        currentField = field;
        alreadyMoved = false;
        isMoveable = true;
        if (team)
        {
            this.team = true;
            figure = FigureController.staticLightFigures[0];
        }
        else
        {
            this.team = false;
            figure = FigureController.staticDarkFigures[0];
        }


        if (team)
        {
            figureValue = 50;
        }
        else
        {
            figureValue = -50;
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
        } else
        {
            occupation = FieldStatus.occupations.BLACK;
        }

        foreach (var item in Utility.MoveHorizontal(currentField,occupation))
        {
            target.Add(item);
        }
        foreach (var item in Utility.MoveVertical(currentField, occupation))
        {
            target.Add(item);
        }


        
        return target;



    }

    private void GetNeccessaryFields()
    {

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
