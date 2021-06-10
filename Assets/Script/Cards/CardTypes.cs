using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTypes : MonoBehaviour
{
    public enum cardLevel
    {
        COMMON,
        RARE,
        SPECIAL,
    }

    public enum cardAction
    {
        None,
        AddTile,
        RemoveTile,
        BlockEnemy,
        SwapPersonalFigure,
        SwapEnemyFigure,
        SwapOwnAndEnemyFigure,
        MoveTwice
    }
}
