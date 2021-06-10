using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FigureColorSelector : MonoBehaviour
{
    // Start is called before the first frame update

    public static FieldStatus.occupations color;
    public static PawnType.pawnTypes pawnTypes;

    private void Start()
    {
        color = FieldStatus.occupations.WHITE;
        pawnTypes = PawnType.pawnTypes.PAWN;
    }

    public void SelectColor(bool isWhite)
    {
        if (isWhite)
        {
            color = FieldStatus.occupations.WHITE;
        }
        else
        {
            color = FieldStatus.occupations.BLACK;
        }
    }

    public void SelectFigure(int index)
    {
        pawnTypes = (PawnType.pawnTypes)index;
    }
}
