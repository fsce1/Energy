using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Vector2Int pos;
    public TextMesh text;
    //note transform.position works as well, as the gameobjects are positioned on their grid squares

    public float wind;
    public float daylight;
    public float buildCost;





    public GameObject structure;
    public GameObject wire;


    public void ChangeCellText(string text)
    {
        this.text.text = text;
        this.text.color = Color.Lerp(GameManager.GM.startCol, GameManager.GM.endCol, float.Parse(text));
        this.text.fontStyle = FontStyle.Bold;
    }
    void Start()
    {
        
    }
}