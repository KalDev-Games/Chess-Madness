
using System.Collections.Generic;

public class Pawn : FigureController
{
    // ! = weiß
    // 2 = schwarz

    public void Initialize(bool team, Field field)
    {
        nameOfPawn = "PAWN";
        canWalkBackwards = false;
        pawnType = PawnType.pawnTypes.PAWN;
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
            figureValue = 10;
        }
        else
        {
            figureValue = -10;
        }
        //GetAllMoveablePositions();
    }

    public List<Field> GetAllMoveablePositions()
    {
        if (team)
        {
            GetBaseMovement(1);
        }
        else
        {
            GetBaseMovement(-1);
        }

        Field leftHit;
        Field rightHit;
        if (team)
        {
            leftHit = Board.GetFieldByCoordninates(currentField.xCoord + 1, currentField.yCoord + 1);
            if (leftHit != null && (leftHit.occupations != FieldStatus.occupations.NONE && leftHit.occupations != FieldStatus.occupations.WHITE))
            {
                target.Add(leftHit);
            }

            rightHit = Board.GetFieldByCoordninates(currentField.xCoord + 1, currentField.yCoord - 1);
            if (rightHit != null && (rightHit.occupations != FieldStatus.occupations.NONE && rightHit.occupations != FieldStatus.occupations.WHITE))
            {
                target.Add(rightHit);
            }
        }
        else
        {
            leftHit = Board.GetFieldByCoordninates(currentField.xCoord - 1, currentField.yCoord + 1);
            if (leftHit != null && (leftHit.occupations != FieldStatus.occupations.NONE && leftHit.occupations != FieldStatus.occupations.WHITE))
            {
                target.Add(leftHit);
            }

            rightHit = Board.GetFieldByCoordninates(currentField.xCoord - 1, currentField.yCoord - 1);
            if (rightHit != null && (rightHit.occupations != FieldStatus.occupations.NONE && rightHit.occupations != FieldStatus.occupations.WHITE))
            {
                target.Add(rightHit);
            }
        }
        
       return target;

    }

    public void GetBaseMovement(int direction)
    {
        
        if (!alreadyMoved)
        {
            target.Add(CheckOccupation(Board.GetFieldByCoordninates(currentField.xCoord + 1 * direction, currentField.yCoord)));
            target.Add(CheckOccupation(Board.GetFieldByCoordninates(currentField.xCoord + 2 * direction, currentField.yCoord)));

        }
        else
        {
            target.Add(CheckOccupation(Board.GetFieldByCoordninates(currentField.xCoord + 1 * direction, currentField.yCoord)));
        }
    }

    private Field CheckOccupation(Field field)
    {
        
        if (field.pawnType == PawnType.pawnTypes.NONE)
        {
            print("Feld wurde entdeckt");
            return field;
        }
        print("Feld wurde nicht entdeckt");
        return null;
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
