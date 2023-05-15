using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Vector2Int pos;
    //note transform.position works as well, as the gameobjects are positioned on their grid squares
    public GameObject structure;
    public GameObject wire;
    void Start()
    {
        
    }
}