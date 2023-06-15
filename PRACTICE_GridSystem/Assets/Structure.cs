using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public Mesh mesh;
    public Cell cell;
    public float cost;
    [Header("Lists")]
    public List<Structure> structures = new();
    public List<Wire> wires = new();
    public List<Generator> generators = new();
    public List<Transformer> transformers = new();

    // FixedUpdate is Structure state updates, normal Update is structure-specific things
    void FixedUpdate()
    {

    }
    public void Start()
    {
        StructureUpdate(this);
    }
    public List<Vector2Int> SearchPos()
    {
        return new List<Vector2Int>
        {
            new(cell.pos.x + 1, cell.pos.y),
            new(cell.pos.x, cell.pos.y + 1),
            new(cell.pos.x, cell.pos.y - 1),
            new(cell.pos.x - 1, cell.pos.y)
        };
    }
    public void StructureUpdate(Structure origin) //TODO
    {
        structures.Clear();
        wires.Clear();
        generators.Clear();
        transformers.Clear();

        foreach (Vector2Int v in SearchPos())
        {
            Cell c = GridTools.GetCell(v);
            Structure s = c.GetComponentInChildren<Structure>();
            if (s != null) structures.Add(s);
        }

        foreach (Structure s in structures)
        {
            //Update Adjacent structures
            if (s != origin) s.StructureUpdate(this);


            if (s is Wire w)
            {
                wires.Add(w);
                Debug.Log("Adding to wires");
            }

            else if (s is Generator g) generators.Add(g);
            else if (s is Transformer t) transformers.Add(t);
        }
    }


}
