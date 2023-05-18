using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Vector2Int pos;
    public TextMesh info;
    public MeshRenderer cube;
    //note transform.position works as well, as the gameobjects are positioned on their grid squares

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
    void Start()
    {

    }
}