using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessAI : MonoBehaviour
{
    // Start is called before the first frame update
    public static int depth = 5;
    public static bool team;
    private int enemyScore = 0;
    private int ownScore = 0;
    List<Field> possibleMoves = new List<Field>();

    public void AIMove()
    {
        //Get all moves
        GetAllMovesOfTeam();
        //determine where the best position is
    }

    void GetAllMovesOfTeam()
    {
        Field field;
        List<Field> fields = new List<Field>();


        for (int x = 0; x < Board.xSize; x++)
        {
            for (int y = 0; y < Board.ySize; y++)
            {
                field = Board.board[x, y];


                 if (Board.level[x, y] > 0 && Board.level[x, y] < 6)
                    {
                        if (field.pawnType != PawnType.pawnTypes.NONE)
                        {

                        if (team)
                        {
                            fields = CheckForMoves(field.pawnType, field.figure);

                            foreach (var possibleField in fields)
                            {
                                possibleMoves.Add(possibleField);
                            }
                            ownScore += field.figure.GetComponent<FigureController>().figureValue;
                        }
                        else
                        {
                            enemyScore += field.figure.GetComponent<FigureController>().figureValue;
                        }
                            
                        }
                 }

                if (Board.level[x, y] < 0 && Board.level[x, y] > -6)
                    {
                    if (field.pawnType != PawnType.pawnTypes.NONE)
                    {

                        if (team)
                        {
                            fields = CheckForMoves(field.pawnType, field.figure);

                            foreach (var possibleField in fields)
                            {
                                possibleMoves.Add(possibleField);
                            }
                            ownScore += field.figure.GetComponent<FigureController>().figureValue;
                        }
                        else
                        {
                            enemyScore += field.figure.GetComponent<FigureController>().figureValue;
                        }

                    }
                }
                
            }
        }
        print(enemyScore + ":" + ownScore);
    }

    static List<Field> CheckForMoves(PawnType.pawnTypes types, GameObject figure)
    {
        List<Field> moves = new List<Field>();

        switch (types)
        {
            case PawnType.pawnTypes.PAWN:
                Pawn pawnMover = figure.GetComponent<Pawn>();
                pawnMover.GetAllMoveablePositions();
                moves = pawnMover.target;
                break;

            case PawnType.pawnTypes.KNIGHT:
                break;

            case PawnType.pawnTypes.BISHOP:
                Bishop bishopMover = figure.GetComponent<Bishop>();
                bishopMover.GetAllMoveablePositions();
                moves = bishopMover.target;
                break;


            case PawnType.pawnTypes.ROOK:
                Rook rookMover = figure.GetComponent<Rook>();
                rookMover.GetAllMoveablePositions();
                moves = rookMover.target;
                break;

            case PawnType.pawnTypes.QUEEN:
                Queen queenMover = figure.GetComponent<Queen>();
                queenMover.GetAllMoveablePositions();
                moves = queenMover.target;
                break;

            case PawnType.pawnTypes.KING:
                King kingMover = figure.GetComponent<King>();
                kingMover.GetAllMoveablePositions();
                moves = kingMover.target;
                break;
        }

        return moves;
    }
}

