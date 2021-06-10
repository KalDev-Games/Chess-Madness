using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldInteraction : MonoBehaviour
{
    public Field field;


    public static bool fieldHasBeenSelected;
    public static PawnType.pawnTypes types;
    public static FieldStatus.occupations team;
    public static List<Field> possibleFields = new List<Field>();
    public static Field lastSelectedField = null;


    
    //Wurde schoin ein Feld ausgewählt?

    //Ja: Versuche ob Figur verschoben werden kann
    //Überprüfung auf eigenes Schach
    //wenn ja, Zug ungültig --> pseudolegal Moves
    //wenn nein, Zug gültig
    //Sitzt dort eine gegnerische Figur?
    //wenn ja, schlage Figur des Gegners
    //wenn nein, setze eigene Figur dort hin
    //aktualisiere Feldinformationen


    //Nein: Bekomme alle Informationen über die Figur die auf diesem Feld sitzt
    //welches Team?
    //welche Figur?
    //wo kann die Figur hin?

    //wechsle Team
    

    private void OnMouseDown()
    {
        team = GetTeam();
        

        if (fieldHasBeenSelected && possibleFields.Contains(field))
        {
            fieldHasBeenSelected = false;
            print("Die Figur " + types + " wurde versetzt");



            lastSelectedField.figure.GetComponent<FigureController>().Move(lastSelectedField.figure, field);
            if (field.occupations != FieldStatus.occupations.NONE && field.occupations != team)
            {
                Destroy(field.figure);
            }

            UpdateFields();
            ResetOldFields();

            Checkmate.CheckForCheckmate(team);


            Player.currentPlayer = !Player.currentPlayer;

        }
        //else if(fieldHasBeenSelected && !possibleFields.Contains(field) && field.pawnType != PawnType.pawnTypes.NONE && field.occupations == team)
        //{
        //    fieldHasBeenSelected = true;
        //    print("Neues Feld ausgewählt");
        //    lastSelectedField = field;
        //}
        else if (field.occupations == team)
        {
            fieldHasBeenSelected = true;
            print("Eigenes Feld wurde ausgewählt");
            possibleFields = GetPossibleMoves(field.pawnType, field.figure);
            print(field.pawnType + " entdeckt");
            lastSelectedField = field;
            types = field.pawnType;

        }

    }
    FieldStatus.occupations GetTeam()
    {
        if (Player.currentPlayer)
        {
            print("Black's turn");
            return FieldStatus.occupations.BLACK;
        }
        else
        {
            print("White's turn");
            return FieldStatus.occupations.WHITE;
        }
    }

    List<Field> GetPossibleMoves(PawnType.pawnTypes type, GameObject figure)
    {
        switch (type)
        {
            case PawnType.pawnTypes.PAWN:
                Pawn pawnMover = figure.GetComponent<Pawn>();
                return pawnMover.GetAllMoveablePositions();


            case PawnType.pawnTypes.KNIGHT:
                Knight knightMover = figure.GetComponent<Knight>();
                return knightMover.GetAllMoveablePositions();
               

            case PawnType.pawnTypes.BISHOP:
                Bishop bishopMover = figure.GetComponent<Bishop>();
                return bishopMover.GetAllMoveablePositions();


            case PawnType.pawnTypes.ROOK:
                Rook rookMover = figure.GetComponent<Rook>();
                return rookMover.GetAllMoveablePositions();


            case PawnType.pawnTypes.QUEEN:
                Queen queenMover = figure.GetComponent<Queen>();
                return queenMover.GetAllMoveablePositions();

            case PawnType.pawnTypes.KING:
                King kingMover = figure.GetComponent<King>();
                return kingMover.GetAllMoveablePositions();

            default:
                return null;
        }
    }

    void UpdateFields()
    {
        field.pawnType = types;
        field.occupations = team;
        field.figure = lastSelectedField.figure;
        lastSelectedField.figure.GetComponent<FigureController>().currentField = field;
        lastSelectedField.figure.GetComponent<FigureController>().alreadyMoved = true;
    }

    void ResetOldFields()
    {
        lastSelectedField.pawnType = PawnType.pawnTypes.NONE;
        lastSelectedField.occupations = FieldStatus.occupations.NONE;
        lastSelectedField.figure = null;
    }
}
