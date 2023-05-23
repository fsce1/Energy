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
    public enum StructureType
    {
        WindTurbine,
        SolarPanel
    }

    [Header("Settings")]
    public OverlayType curOverlay;
    [Header("Variables")]
    public List<Cell> cellList = new();
    public void ShowWind()
    {
        foreach (Cell c in cellList)
        {
            c.ChangeInfoOverlay(c.wind);
        }
    }
    public void ShowCost()
    {
        foreach (Cell c in cellList)
        {
            c.ChangeInfoOverlay(c.buildCost);
        }
    }
    public void ShowDaylight()
    {
        foreach (Cell c in cellList)
        {
            c.ChangeInfoOverlay(c.daylight);
        }
    }
    private void Start()
    {

        GridInitialiser grid = new(10, 10, new GameObject().transform, new GameObject().transform);
    }
}
