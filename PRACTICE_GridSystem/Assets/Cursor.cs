using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

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
    public Structure heldStructure;
    public MeshFilter heldVisual;
    public bool isOnUI = false;
    public void Update()
    {
        Ray ray;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        isOnUI = EventSystem.current.IsPointerOverGameObject();
        if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.CompareTag("Interact"))
        {
            //isOnUI = hit.collider.CompareTag("UI"); // TODO

            Vector2Int pos = GridTools.Vector3ToVector2Int(hit.collider.gameObject.transform.position);
            selectedCell = GridTools.GetCell(pos);
            transform.position = new(pos.x, 0.1f, pos.y);
        }
        if (Input.GetMouseButtonDown(0) && !isOnUI)
        {
            PlaceItem();
        }
    }
    public void PickupItem(Structure structure)
    {
        heldStructure = structure;
        heldVisual.mesh = structure.mesh;
    }
    public void PlaceItem()
    { 
        if (heldStructure == null) return;
        if (heldStructure.cost >= GameManager.GM.money) return;
        if (selectedCell.structure != null)
        {
            //refund half of structure cost
            GameManager.GM.AddMoney(selectedCell.structure.cost / 2);
            selectedCell.structure.StructureUpdate(heldStructure);
            Destroy(selectedCell.structure.gameObject);
        }
        if (heldStructure is Bulldoser)
        {
            selectedCell.structure = null;
            return;
        }

        GameObject obj = Instantiate(heldStructure.gameObject, selectedCell.transform);
        Structure structure = obj.GetComponent<Structure>();

        structure.cell = selectedCell;
        selectedCell.structure = structure;
        GameManager.GM.AddMoney(-structure.cost);
    }
}