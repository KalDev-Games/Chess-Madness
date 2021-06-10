using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static bool team;
    public static PawnType.pawnTypes selectedPawn;
    public static List<Field> possibleFields = new List<Field>();
    public static Field selectedField;
    public static bool currentPlayer;
    public static GameObject currentFigure;
    public static bool cardIsUsed;
    public static CardTypes.cardAction[] cards = { CardTypes.cardAction.None, CardTypes.cardAction.None };
    public static bool AI = true;
    private ChessAI chessAI;
    private GameObject computer = new GameObject();
    // Start is called before the first frame update

    private void Start()
    {
        chessAI = computer.AddComponent<ChessAI>();
        chessAI.AIMove();
        team = true;
    }
}
