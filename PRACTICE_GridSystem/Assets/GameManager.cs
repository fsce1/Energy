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
    public enum OverlayType
    {
        Wind,
        Daylight,
        BuildCost
    }

    [Header("Settings")]
    public OverlayType curOverlay;
    [Header("Variables")]
    public Color startCol;
    public Color endCol;
    public List<Cell> cellList = new();
    private void Start()
    {
        
        GridInitialiser grid = new(20, 20, new GameObject().transform, new GameObject().transform);
    }
}
