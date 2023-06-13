using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTurbine : Structure
{
    [Header("Specific")]
    public float outputPower = 200f;

    public List<Wire> GetSurroundingWire()
    {
        var list = new List<Wire>();
        foreach (Cell c in cell.adjacentCells)
        {
            Wire w = c.GetComponentInChildren<Wire>();
            if (w != null) list.Add(w);
        }
        return list;
    }
    void Update()
    {
        var wire = GetSurroundingWire();

        foreach(Wire w in wire)
        {
            w.heldPower = outputPower / wire.Count;
        }

    }
}
