using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GridTools
{
    public static Vector2Int Vector3ToVector2Int(Vector3 input)
    {
        return Vector2Int.FloorToInt(new Vector2(input.x, input.z));
    }
    public static Vector3 Vector2IntToVector3(Vector2Int input, bool isCentered)
    {
        if (isCentered)
        {
            return new Vector3(input.x + 0.5f, 0, input.y + 0.5f);
        }
        return new Vector3(input.x, 0, input.y);

    }
    public static Cell GetCell(Vector2Int pos)
    {
        return GameManager.GM.cellList.Select(thing => thing).Where(cell => cell.pos.x == pos.x && cell.pos.y == pos.y).FirstOrDefault();
    }
}
