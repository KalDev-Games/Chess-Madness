using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureController : MonoBehaviour
{
    // Start is called before the first frame update
    public string nameOfPawn;

    public List<Field> target = new List<Field>();
    public List<Field> neccessaryFields = new List<Field>();
    public List<Field> hitTargets = new List<Field>();
    public Field currentField;

    public bool canWalkBackwards;
    public bool team;
    public bool isMoveable;

    public GameObject figure;
    public int figureValue;

    public PawnType.pawnTypes pawnType;
    public bool alreadyMoved;
    public float height;


    public GameObject[] lightFigures = new GameObject[6];
    public GameObject[] darkFigures = new GameObject[6];
    public static GameObject[] staticLightFigures;
    public static GameObject[] staticDarkFigures;

    void Start()
    {
        staticLightFigures = lightFigures;
        staticDarkFigures = darkFigures;
    }

    

    public void Initialize(){
        staticLightFigures = lightFigures;
        staticDarkFigures = darkFigures;
    }
    // Update is called once per frame

    public void GetAllPositions()
    {

    }

    public void Move(GameObject figure, Field field)
    {
        float xOffset = Utility.CalculateOffset(Board.xSize);
        float yOffset = Utility.CalculateOffset(Board.ySize);
        alreadyMoved = true;
        Debug.LogWarning(figure.GetComponent<FigureController>().alreadyMoved);
        figure.transform.position = new Vector3(field.xCoord + xOffset,0.5f, field.yCoord + yOffset);
    }

    static Vector3 CalculateDifference(Field field)
    {
        var differenceX = field.xCoord - FieldInteraction.lastSelectedField.xCoord;
        var differenceY = field.yCoord - FieldInteraction.lastSelectedField.yCoord;

        return new Vector3(differenceX, 0, differenceY);
        
    }
}
