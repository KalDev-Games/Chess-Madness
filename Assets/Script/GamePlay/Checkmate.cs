using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkmate
{
    //Wo muss auf Schach überprüft werden?
    // - offenbart verschieben der eigenen Figur Schach des eigenen Königs? --> ungültiger Zug --> FUnktion CheckForPseudoLegalMoves
    // - sitzt der gegnerische König im Schach? --> Funktion CheckForCheckmate

    //Überprüfe auf Schach:
    // - bekomme Informationen über aktuelle Bewegungsmöglichkeiten
    // - bekomme Informationen über Position des jeweiligen Königs
    // - sitzt der König in einem dieser Felder?
    // wenn nein Zug ist gültig bzw. der König sitzt nicht im Schach
    // wenn ja überprüfe auf Schachmatt bzw. Zug ist ungültig

    //Überprüfe auf Schachmatt:
    // - ist es möglich, die schachsetzende Figur zu schlagen?
    // wenn ja, kein Schachmatt
    // wenn nein, ist es möglich, eine Figur in die Bewegungsbahn der schachsetzenden Figur zu setzen?
    // wenn ja, kein Schachmatt
    // wenn nein, ist es möglich den König zu verschieben, so dass die neue Position ebenfalls kein Schach ist?
    // wenn ja, kein Schachmatt
    // wenn nein, Schachmatt! --> Spielende

    static Field kingPosition;
    static Field checkFigure;
    public static bool checkMate = false;
    public static void CheckForCheckmate(FieldStatus.occupations team)
    {
        checkMate = false;
        List<Field> fields = new List<Field>();
        FindKing(InverseTeam(team));

        for (int x = 0; x < Board.xSize; x++)
        {
            for (int y = 0; y < Board.ySize; y++)
            {
                Field field = Board.GetFieldByCoordninates(x, y);
                if (field.occupations == team)
                {
                    fields = GetMovesOfFigure(field.figure, field.pawnType);
                    Debug.Log(field.pawnType);
                    if (fields.Contains(kingPosition))
                    {
                        Debug.LogError("Schach");
                        checkFigure = field;
                        CheckForHit(InverseTeam(team), field);
                    }
                }
            }
        }
    }

    static void CheckForHit(FieldStatus.occupations team, Field fieldOfFigureToHit)
    {
        List<Field> fields = new List<Field>();

        for (int x = 0; x < Board.xSize; x++)
        {
            for (int y = 0; y < Board.ySize; y++)
            {
                Field field = Board.GetFieldByCoordninates(x,y);
                if (field.occupations == team)
                {
                    fields = GetMovesOfFigure(field.figure, field.pawnType);
                   
                    if (fields.Contains(fieldOfFigureToHit))
                    {
                        Debug.LogError("Figure can be hitted");
                        checkFigure = fieldOfFigureToHit;
                    }
                    else
                    {
                        CheckForMovingKing(InverseTeam(team));
                    }
                }
            }
        }
    }

    static void CheckForMovingKing(FieldStatus.occupations team)
    {
        List<Field> allReachableFields = new List<Field>();
        for (int x = 0; x < Board.xSize; x++)
        {
            for (int y = 0; y < Board.ySize; y++)
            {
                Field field = Board.GetFieldByCoordninates(x, y);
                if (field.occupations == team)
                {
                    List<Field> temp = GetMovesOfFigure(field.figure, field.pawnType);
                    Debug.Log(field.pawnType);

                    foreach (var item in temp)
                    {
                        allReachableFields.Add(item);
                    }
                }
            }
        }

        List<Field> kingMoves = GetMovesOfFigure(kingPosition.figure, kingPosition.pawnType);
        checkMate = true;
        foreach (var item in kingMoves)
        {
            if (!allReachableFields.Contains(item))
            {
                checkMate = false;
            }
        }

        if (checkMate)
        {
            Debug.LogError("Schachmatt");
        }
    }


    static void FindKing(FieldStatus.occupations occupations)
    {
        Field field;
        for (int x = 0; x < Board.xSize; x++)
        {
            for (int y = 0; y < Board.ySize; y++)
            {
                field = Board.GetFieldByCoordninates(x, y);
                if (field.occupations == occupations && field.pawnType == PawnType.pawnTypes.KING)
                {
                    kingPosition = field;
                    continue;
                }
            }
        }
    }

    static FieldStatus.occupations InverseTeam(FieldStatus.occupations team)
    {
        if (team == FieldStatus.occupations.BLACK)
        {
            return FieldStatus.occupations.WHITE;
        }
        else
        {
            return FieldStatus.occupations.BLACK;
        }
    }

    static List<Field> GetMovesOfFigure(GameObject figure, PawnType.pawnTypes type)
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
}
