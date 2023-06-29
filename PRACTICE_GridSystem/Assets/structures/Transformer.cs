using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformer : Structure
{
    public bool goesToMoney=false;
    public float inflow;
    public override void Tick()
    {
        inflow=0;
        foreach(Wire w in wires)
        {
            inflow += w.heldPower;
            w.heldPower = 0;
        }

        if (goesToMoney)
        {
            GameManager.GM.AddMoney(Mathf.RoundToInt(inflow / 10));
        }
        else
        {
            GameManager.GM.AddTotalPower(inflow);
        }

    }
}
