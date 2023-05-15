using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region SINGLETON
    public static GameManager GM;
    private void Awake()
    {
        if (GM != null && GM != this) Destroy(this);
        else GM = this;
    }
    #endregion
    public List<Cell> cellList = new();
    private void Start()
    {
        
        GridInitialiser grid = new(10, 10);
    }
}
