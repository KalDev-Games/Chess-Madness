using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFieldAttributes : MonoBehaviour
{
    // Start is called before the first frame update
    public Field field;

    private void OnMouseDown()
    {
        switch (FieldEditor.mode)
        {
            case FieldEditor.EditModes.Tile:
                ChangeTile();
                break;
            case FieldEditor.EditModes.Color:
                ChangeColor();
                break;
            case FieldEditor.EditModes.Figure:
                ChangeFigure();
                break;
            default:
                ChangeTile();
                break;
        }
        UpdateInfo();
    }

    void ChangeTile()
    {
        print(field.status);
        var transforms = field.field.transform;
        var tile = field.field;

        if (field.status == FieldStatus.fieldTypes.BLACK || field.status == FieldStatus.fieldTypes.WHITE)
        {
            GetComponent<MeshRenderer>().material = GenerateFieldEditor.staticVoidMaterial;
            field.status = FieldStatus.fieldTypes.VOID;
            
            
        } else
        {
            if (field.xCoord % 2 != 0)
            {
                if (field.yCoord % 2 == 0)
                {
                    field.status = FieldStatus.fieldTypes.BLACK;
                    GetComponent<MeshRenderer>().material = GenerateFieldEditor.staticBlackMaterial;
                    
                }
                else
                {
                    field.status = FieldStatus.fieldTypes.WHITE;
                    GetComponent<MeshRenderer>().material = GenerateFieldEditor.staticWhiteMaterial;
                }
            }
            else
            {
                if (field.yCoord % 2 != 0)
                {
                    field.status = FieldStatus.fieldTypes.BLACK;
                    GetComponent<MeshRenderer>().material = GenerateFieldEditor.staticBlackMaterial;
                }
                else
                {
                    GetComponent<MeshRenderer>().material = GenerateFieldEditor.staticWhiteMaterial;
                    field.status = FieldStatus.fieldTypes.WHITE;
                }
            }
        }
    }

    void ChangeColor()
    {
        if (field.occupations == FieldStatus.occupations.NONE)
        {
            field.occupations = FieldStatus.occupations.WHITE;
        }
        else if (field.occupations == FieldStatus.occupations.WHITE)
        {
            field.occupations = FieldStatus.occupations.BLACK;
        }
        else
        {
            field.occupations = FieldStatus.occupations.NONE;
        }
        ChangeFigureColor();
    }

    void ChangeFigureColor()
    {
        if (field.figure)
        {
            if (field.occupations == FieldStatus.occupations.WHITE)
            {
                field.figure.GetComponent<MeshRenderer>().material = GenerateFieldEditor.staticWhiteMaterial;
            }
            else if (field.occupations == FieldStatus.occupations.BLACK)
            {
                field.figure.GetComponent<MeshRenderer>().material = GenerateFieldEditor.staticBlackMaterial;
            }
        }
    }


    void ChangeFigure()
    {
        if (field.status != FieldStatus.fieldTypes.VOID)
        {
            SpawnFigure(FigureColorSelector.color, FigureColorSelector.pawnTypes, field.xCoord, field.yCoord, field.figure);
        }
        
    }

    void SpawnFigure(FieldStatus.occupations team, PawnType.pawnTypes type, int x, int y, GameObject oldFigure)
    {
        if (oldFigure)
        {
            Destroy(oldFigure);
        }


        if (type != PawnType.pawnTypes.NONE)
        {
            GameObject figure = new GameObject();
            if (team == FieldStatus.occupations.BLACK)
            {
                figure = Instantiate(FigureController.staticDarkFigures[(int)type - 1], new Vector3(x + Utility.CalculateOffset(LevelSelector.xSize), .5f, y + Utility.CalculateOffset(LevelSelector.ySize)), Quaternion.Euler(0,180,0));
                field.occupations = FieldStatus.occupations.BLACK;
                GenerateFieldEditor.level[x, y] = -(int)type;
                
            }
            else
            {
                figure = Instantiate(FigureController.staticLightFigures[(int)type - 1], new Vector3(x + Utility.CalculateOffset(LevelSelector.xSize), .5f, y + Utility.CalculateOffset(LevelSelector.ySize)), Quaternion.Euler(0, 180, 0));
                field.occupations = FieldStatus.occupations.WHITE;
                GenerateFieldEditor.level[x, y] = (int)type;
               
            }

            field.figure = figure;

            if (figure.GetComponent<BoxCollider>())
            {
                Destroy(figure.GetComponent<BoxCollider>());
            }
        }

        print(field.occupations);
    }

    void UpdateInfo()
    {
        Field tempField;
        for (int x = 0; x < LevelSelector.xSize; x++)
        {
            for (int y = 0; y < LevelSelector.ySize; y++)
            {
                tempField = GenerateFieldEditor.board[x, y];
                if (tempField.status == FieldStatus.fieldTypes.VOID)
                {
                    GenerateFieldEditor.structure[x,y] = 0;
                }
                else
                {
                    GenerateFieldEditor.structure[x,y] = 1;
                }
            }
        }
        //Update Structure


        /*for (int x = 0; x < GenerateFieldEditor.size; x++)
        {
            for (int y = 0; y < GenerateFieldEditor.size; y++)
            {
                tempField = GenerateFieldEditor.board[x, y];
                if (tempField.occupations != FieldStatus.occupations.NONE)
                {
                    if (tempField.occupations == FieldStatus.occupations.WHITE)
                    {
                        GenerateFieldEditor.level[x,y] = (int)field.pawnType;
                    }
                    else
                    {
                        GenerateFieldEditor.level[x,y] = -((int)field.pawnType);
                    }
                }
            }
        }*/

        //Update Figures
        
    }
}
