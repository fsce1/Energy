using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    [Header("References")]
    public List<Cell> cellList = new();
    public TMP_Text moneyText;
    [Header("Player")]
    public float money = 1000;
    
    public void ChangeMoney(float change)
    {
        money += change;
        moneyText.text = '$' + money.ToString();
    }
    //public enum InfoType
    //{
    //    hidden,
    //    wind,
    //    cost,
    //    daylight
    //}
    //public void ChangeInfo(InfoType i)
    //{
    //    switch (i)
    //    {
    //        case InfoType.hidden:
    //            break;
    //    }

    //    foreach (Cell c in cellList)
    //    {
    //        c.ChangeInfoOverlay(c.wind);
    //    }
    //}



    public void HideInfo()
    {
        foreach (Cell c in cellList)
        {
            c.HideInfoOverlay();
        }
    }
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
        GridInitialiser grid = new(15, 15, new GameObject().transform, new GameObject().transform, 0.25f);
        moneyText.text = '$' + money.ToString();
    }
    //public IEnumerable tick()
    //{

    //}
}
