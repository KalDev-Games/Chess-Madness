using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layouts
{
    //-6 King
    //-5 Queen
    //-4 Rook
    //-3 Bishop
    //-2 Knight
    //-1 Pawn
    // 0 none
    // 1 Pawn
    // 2 Knight
    // 3 Bishop
    // 4 Rook
    // 5 Queen
    // 6 King
    public static List<int[,]> levels = new List<int[,]>();
    public static List<int[,]> fieldStructure = new List<int[,]>();
    
    public static int[,] normalLayout = new int[8,8] {
        { -4, -2, -3, -6, -5, -3, -2, -4 },
        { -1, -1, -1, -1, -1, -1, -1, -1 },
        {  0,  0,  0,  0,  0,  0,  0,  0 },
        {  0,  0,  0,  0,  0,  0,  0,  0 },
        {  0,  0,  0,  0,  0,  0,  0,  0 },
        {  0,  0,  0,  0,  0,  0,  0,  0 },
        {  0,  0,  0,  0,  0,  0,  0,  0 },
        {  4,  2,  3,  6,  5,  3,  2,  4 },
    };

    public static int[,] normalLayoutStructure = new int[8, 8] {
        {  1,  1,  1,  1,  1,  1,  1,  1 },
        {  1,  1,  1,  1,  1,  1,  1,  1 },
        {  1,  1,  1,  1,  1,  1,  1,  1 },
        {  1,  1,  1,  1,  1,  1,  1,  1 },
        {  1,  1,  1,  1,  1,  1,  1,  1 },
        {  1,  1,  1,  1,  1,  1,  1,  1 },
        {  1,  1,  1,  1,  1,  1,  1,  1 },
        {  1,  1,  1,  1,  1,  1,  1,  1 },
    };


    public static void InitializeLevel()
    {
        levels.Add(normalLayout);

        fieldStructure.Add(normalLayoutStructure);
    }

}
