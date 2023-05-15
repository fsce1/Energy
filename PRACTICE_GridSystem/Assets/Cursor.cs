using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    #region SINGLETON
    public static Cursor C;
    private void Awake()
    {
        if (C != null && C != this) Destroy(this);
        else C = this;
    }
    #endregion
    public Cell selectedCell;
    public void Update()
    {
        Ray ray;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.CompareTag("Interact"))
        {

            Vector2Int pos = GridTools.Vector3ToVector2Int(hit.collider.gameObject.transform.position);
            selectedCell = GridTools.GetCell(pos);

            transform.position = new(pos.x, 0.1f, pos.y);

        }
    }

}