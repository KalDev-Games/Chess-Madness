using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class old_FieldInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    public Field field;
    private FieldStatus.occupations type;
    private bool figureIsSelected;
    void Start()
    {
        
    }

    // Update is called once per frame
    
    FieldStatus.occupations GetTeam()
    {
        if (Player.currentPlayer)
        {
            return FieldStatus.occupations.BLACK;
        }
        else
        {
            return FieldStatus.occupations.WHITE;
        }
    }
    private void OnMouseDown()
    {
        type = GetTeam();
        GetPossibleMoves(field.pawnType, field.figure);


        if (Player.possibleFields.Contains(field))
        {
            if (field.occupations != type )
            {
                if (field.pawnType == PawnType.pawnTypes.NONE)
                {
                    //Move Pawn
                    field.pawnType = Player.selectedPawn;
                    Player.selectedField.pawnType = PawnType.pawnTypes.NONE;
                    Player.selectedField.occupations = FieldStatus.occupations.NONE;
                    field.occupations = type;
                    //FigureController.Move(Player.currentFigure,field);
                    Player.currentFigure.GetComponent<FigureController>().currentField = field;
                }
            } else if (field.occupations == type && field.occupations != FieldStatus.occupations.NONE)
            {
                field.pawnType = Player.selectedPawn;
                Destroy(field.figure);
                field.occupations = type;
                Player.selectedField.occupations = FieldStatus.occupations.NONE;
                Player.selectedField.pawnType = PawnType.pawnTypes.NONE;
                //FigureController.Move(Player.currentFigure, field);
                Player.currentFigure.GetComponent<FigureController>().currentField = field;
            }

            Player.currentPlayer = !Player.currentPlayer;
        }
    }

    void GetPossibleMoves(PawnType.pawnTypes type, GameObject figure)
    {
        switch (type)
        {
            case PawnType.pawnTypes.PAWN:
                Pawn pawnMover = figure.GetComponent<Pawn>();
                pawnMover.GetAllMoveablePositions();
                break;

            case PawnType.pawnTypes.KNIGHT:
                break;

            case PawnType.pawnTypes.BISHOP:
                Bishop bishopMover = figure.GetComponent<Bishop>();
                bishopMover.GetAllMoveablePositions();
                break;

            case PawnType.pawnTypes.ROOK:
                Rook rookMover = figure.GetComponent<Rook>();
                rookMover.GetAllMoveablePositions();
                break;

            case PawnType.pawnTypes.QUEEN:
                Queen queenMover = figure.GetComponent<Queen>();
                queenMover.GetAllMoveablePositions();
                break;

            case PawnType.pawnTypes.KING:
                break;

            default:
                break;
        }
    }
}
