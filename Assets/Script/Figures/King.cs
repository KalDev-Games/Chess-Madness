using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : FigureController
{
    // Start is called before the first frame update
    public void Initialize(bool team, Field field)
    {
        nameOfPawn = "KING";
        canWalkBackwards = true;
        pawnType = PawnType.pawnTypes.KING;
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
            figureValue = 900;
        }
        else
        {
            figureValue = -900;
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

        for (int x = -1; x < 2; x++)
        {
            for (int y = -1; y < 2; y++)
            {
                Field field = Board.GetFieldByCoordninates(currentField.xCoord + x, currentField.yCoord + y);
                if (field != null)
                {
                    if (field.occupations == FieldStatus.occupations.NONE || field.occupations != occupation)
                    {
                        target.Add(field);
                    }
                }
                

                
            }
        }
       

        


        foreach (var item in target)
        {
            print(item.xCoord + "/" + item.yCoord);
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
