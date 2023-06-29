using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : Structure
{
    public float heldPower = 0;

    public override void Tick()
    {
        float generatorPower = 0;
        foreach (Generator g in generators)
        {
            if(g.multiplierType == GameManager.InfoType.Wind)
            {
                generatorPower += g.outputPower * g.cell.wind;
            }
            else if(g.multiplierType == GameManager.InfoType.Daylight)
            {
                generatorPower += g.outputPower * g.cell.daylight;
            }

        }
        float wirePower = 0;
        foreach (Wire w in wires)
        {
            wirePower = w.heldPower / 2;
        }
        heldPower = generatorPower + wirePower;
        if (heldPower <= 0) heldPower = 0;
    }
    //public override void StructureUpdate(Structure origin)
    //{
    //    base.StructureUpdate(this);
    //    Debug.Log("changing power");
    //}
}
