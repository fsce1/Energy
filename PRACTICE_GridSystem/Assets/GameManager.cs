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
    public TMP_Text totalPowerText;
    [Header("Player")]
    public float money = 100000;
    public float totalPower = 0;

    public void AddMoney(float change)
    {
        money += change;
        moneyText.text = '$' + money.ToString();
    }
    public void AddTotalPower(float change)
    {
        totalPower += change;
        totalPowerText.text = "Total Power Generated:" + totalPower.ToString();
    }
    public enum InfoType
    {
        None,
        Wind,
        Cost,
        Daylight,
        Power
    }
    public InfoType curInfo;

    public void HideInfo()
    {
        curInfo = InfoType.None;
        foreach (Cell c in cellList)
        {
            c.HideInfoOverlay();
        }
    }
    public void ShowWind()
    {
        curInfo = InfoType.Wind;
        foreach (Cell c in cellList)
        {
            c.ChangeInfoOverlay(Mathf.Round(c.wind));
        }
    }
    public void ShowCost()
    {
        curInfo = InfoType.Cost;
        foreach (Cell c in cellList)
        {
            c.ChangeInfoOverlay(Mathf.Round(c.buildCost));
        }
    }
    public void ShowDaylight()
    {
        curInfo = InfoType.Daylight;
        foreach (Cell c in cellList)
        {
            c.ChangeInfoOverlay(Mathf.Round(c.daylight));
        }
    }
    public void ShowPower()
    {
        curInfo = InfoType.Power;
        foreach (Cell c in cellList)
        {
            float info = 0;
            if (c.structure != null)
            {

                switch (c.structure)
                {
                    case Generator s:
                        info = s.outputPower;
                        break;
                    case Wire s:
                        info = s.heldPower;
                        break;
                    case Transformer t:
                        info = t.inflow;
                        break;
                }
            }
            info = Mathf.RoundToInt(info);
            c.ChangeInfoOverlay(info);
        }
    }
    void UpdateInfo()
    {
        if (curInfo == InfoType.Power)
        {
            ShowPower();
        }
    }
    private void Start()
    {
        GridInitialiser grid = new(15, 15, new GameObject().transform, new GameObject().transform, 0.25f);
        moneyText.text = '$' + money.ToString();

        InvokeRepeating("Tick", 0, 1);

    }
    void Tick()
    {
        UpdateInfo();
        foreach (Cell c in cellList)
        {
            if (c.structure != null)
            {
                c.structure.Tick();
            }
        }
    }
    //public IEnumerable tick()
    //{

    //}
}
