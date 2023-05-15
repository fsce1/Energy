using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridInitialiser
{
    private int[,] gridArray;


    public GridInitialiser(int width, int height)
    {
        gridArray = new int[width, height];

        AddLineRenderers(gridArray);

        //Cycle through a multi-dimensional array, counting up
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {

            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                GameObject obj = new();
                obj.transform.position = new(x, 0, y);
                obj.name = x + ", " + y;
                obj.tag = "Interact";

                BoxCollider col = obj.AddComponent<BoxCollider>();
                col.center = new(0.5f, 0, 0.5f);
                col.size = new(1, 0.1f, 1);

                Cell c = obj.AddComponent<Cell>();
                c.pos = new(x, y);

                GameManager.GM.cellList.Add(c);

            }
        }
        
    }
    #region LINE RENDERER
    public LineRenderer AddLineRenderer(Vector3[] positions)
    {
        GameObject g = new();
        g.name = "LineRenderer" + positions[0].x + ", " + positions[0].z;
        LineRenderer l = g.AddComponent<LineRenderer>();
        l.startWidth = 0.05f;
        l.endWidth = 0.05f;
        l.positionCount = 2;
        l.SetPositions(positions);

        l.material = gridMat;
        return l;
    }
    Material gridMat;
    private object obj;

    public void AddLineRenderers(int[,] gridArray)
    {
        gridMat = new Material(Shader.Find("Unlit/Color"));
        gridMat.color = new Color32(128, 255, 128,255);
        int xLength = gridArray.GetLength(0);
        int yLength = gridArray.GetLength(1);
        Vector3[] pos = new Vector3[2];
        for (int x = 0; x < yLength; x++)
        {
            pos[0] = new(0, 0, x);
            pos[1] = new(xLength, 0, x);
            AddLineRenderer(pos);
        }
        for (int y = 0; y < xLength; y++)
        {
            pos[0] = new(y, 0, 0);
            pos[1] = new(y, 0, yLength);
            AddLineRenderer(pos);
        }
        //Complete outside Square
        pos[0] = new(0, 0, yLength);
        pos[1] = new(xLength, 0, yLength);
        AddLineRenderer(pos);
        pos[0] = new(xLength, 0, 0);
        pos[1] = new(xLength, 0, yLength);
        AddLineRenderer(pos);
        return;
    }
#endregion
}
