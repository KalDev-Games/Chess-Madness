using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : FigureController
{
    // Start is called before the first frame update
    public void Initialize(bool team, Field field)
    {
        nameOfPawn = "QUEEN";
        canWalkBackwards = true;
        pawnType = PawnType.pawnTypes.QUEEN;
        currentField = field;
        alreadyMoved = false;
        isMoveable = true;

        
        figureValue = 90;

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
            figureValue = 90;
        }
        else
        {
            figureValue = -90;
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


        foreach (var item in Utility.MoveDiagonalRight(currentField, occupation))
        {
            target.Add(item);
        }
        foreach (var item in Utility.MoveDiagonalLeft(currentField, occupation))
        {
            target.Add(item);
        }
        foreach (var item in Utility.MoveHorizontal(currentField, occupation))
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
