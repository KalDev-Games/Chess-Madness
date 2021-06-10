using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public static List<Field> MoveHorizontal(Field currentField, FieldStatus.occupations occupation)
    {
        List<Field> possibility = new List<Field>();

        if (currentField.xCoord < Board.xSize)
        {
            for (int i = currentField.xCoord; i < Board.xSize; i++)
            {

                if (Board.GetFieldByCoordninates(i, currentField.yCoord) != null)
                {
                    if (Board.GetFieldByCoordninates(i, currentField.yCoord).occupations == FieldStatus.occupations.NONE || Board.GetFieldByCoordninates(i, currentField.yCoord).occupations != occupation)
                    {
                        Field field = Board.GetFieldByCoordninates(i, currentField.yCoord);
                        possibility.Add(field);
                    }
                    else
                    {
                        continue;
                    }
                }

            }
        }

        if (currentField.xCoord > 0)
        {
            for (int i = currentField.xCoord; i >= 0; i--)
            {

                if (Board.GetFieldByCoordninates(i, currentField.yCoord) != null)
                {
                    if (Board.GetFieldByCoordninates(i, currentField.yCoord).occupations == FieldStatus.occupations.NONE || Board.GetFieldByCoordninates(i, currentField.yCoord).occupations != occupation)
                    {
                        Field field = Board.GetFieldByCoordninates(i, currentField.yCoord);
                        possibility.Add(field);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        
        }

        return possibility;
    }

    public static List<Field> MoveVertical(Field currentField, FieldStatus.occupations occupation)
    {
        List<Field> possibility = new List<Field>();
        if (currentField.yCoord < Board.ySize)
        {
            for (int i = currentField.yCoord; i < Board.xSize; i++)
            {
                if (Board.GetFieldByCoordninates(i, currentField.yCoord) != null)
                {
                    if (Board.GetFieldByCoordninates(currentField.xCoord, i).occupations == FieldStatus.occupations.NONE || Board.GetFieldByCoordninates(currentField.xCoord, i).occupations != occupation)
                    {
                        Field field = Board.GetFieldByCoordninates(currentField.xCoord, i);
                        possibility.Add(field);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        if (currentField.yCoord > 0)
        {
            for (int i = currentField.yCoord; i >= 0; i--)
            {
                if (Board.GetFieldByCoordninates(i, currentField.yCoord) != null)
                {
                    if (Board.GetFieldByCoordninates(currentField.xCoord, i).occupations == FieldStatus.occupations.NONE || Board.GetFieldByCoordninates(currentField.xCoord, i).occupations != occupation)
                    {
                        Field field = Board.GetFieldByCoordninates(currentField.xCoord, i);
                        possibility.Add(field);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
        

        return possibility;
    }

    public static List<Field> MoveDiagonalRight(Field currentField, FieldStatus.occupations occupation)
    {
        List<Field> possibility = new List<Field>();
        int x = currentField.xCoord;
        int y = currentField.yCoord;

        Field temp;
        while (x < Board.xSize && y < Board.ySize)
        {
            x++;
            y++;
            temp = Board.GetFieldByCoordninates(x,y);
            if (temp != null)
            {
                if (temp.occupations == FieldStatus.occupations.NONE || temp.occupations != occupation)
                {
                    
                    possibility.Add(temp);
                }
                else
                {
                    continue;
                }
            }
            
            
        }

        x = currentField.xCoord;
        y = currentField.yCoord;
        while (x < Board.xSize && y > 0)
        {
            x++;
            y--;
            temp = Board.GetFieldByCoordninates(x, y);

            if (temp != null)
            {
                if (temp.occupations == FieldStatus.occupations.NONE || temp.occupations != occupation)
                {
                    
                    possibility.Add(temp);
                }
                else
                {
                    continue;
                }
            }
        }


        return possibility;
    }

    static public int CalculateOffset(int size)
    {
        return (16 - size) / 2;
    }


    public static List<Field> MoveDiagonalLeft( Field currentField, FieldStatus.occupations occupation)
    {
        List<Field> possibility = new List<Field>();
        int x = currentField.xCoord;
        int y = currentField.yCoord;

        Field temp;
        while (x > 0 && y > 0)
        {
            x--;
            y--;
            temp = Board.GetFieldByCoordninates(x, y);

            if (temp != null)
            {
                if (temp.occupations == FieldStatus.occupations.NONE || temp.occupations != occupation)
                {
                    
                    possibility.Add(temp);
                }
                else
                {
                    continue;
                }
            }


        }

        x = currentField.xCoord;
        y = currentField.yCoord;
        while (x > 0 && y < Board.ySize)
        {
            x--;
            y++;
            temp = Board.GetFieldByCoordninates(x, y);
            if (temp != null)
            {
                if (temp.occupations == FieldStatus.occupations.NONE || temp.occupations != occupation)
                {
                    
                    possibility.Add(temp);
                }
                else
                {
                    continue;
                }
            }
        }


        return possibility;
    }

}
