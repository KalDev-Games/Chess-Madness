using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public float factor = 0.625f;
    void Start()
    {
        factor = 0.625f;
        if (LevelSelector.xSize > LevelSelector.ySize)
        {
            
            transform.Translate(0,0,-Offset(LevelSelector.xSize),Space.World);
        }
        else
        {
            transform.Translate(0, 0, -Offset(LevelSelector.ySize),Space.World);
        }
    }

    float Offset(int size)
    {
        print(Utility.CalculateOffset(size) * 2 * factor);
        return (-16.5f + Utility.CalculateOffset(size) * factor);
    }
    // Update is called once per frame
    
}
