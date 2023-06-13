using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Vector2Int pos;//transform.position works as well, as the gameobjects are positioned on their grid squares
    public TextMesh info;
    public MeshRenderer cube;
    public List<Cell> adjacentCells = new();
    public float wind;
    public float daylight;
    public float buildCost;

    public Structure structure;


    public void ChangeInfoOverlay(float info)
    {
        this.info.text = info.ToString().Substring(0, 3);
        this.info.color = Color.white;
        this.info.fontStyle = FontStyle.Bold;

        Color32 start = new(0, 255, 0, 255);
        Color32 end = new(255, 0, 0, 255);
        cube.material.color = Color.Lerp(start, end, info);
    }
    public void HideInfoOverlay()
    {
        this.info.text = null;
        cube.material.color = Color.white;
    }

    public List<Vector2Int> SearchPos(){
        return new List<Vector2Int>
        {
            new(pos.x + 1, pos.y),
            new(pos.x, pos.y + 1),
            new(pos.x, pos.y - 1),
            new(pos.x - 1, pos.y)
        };
    } 
    public void UpdateNeighbours()
    {


    }
    void Start()
    {
        foreach (Vector2Int v in SearchPos())
        {
            Cell c = GridTools.GetCell(v);
            if (c != null) adjacentCells.Add(c);
        }
    }
}