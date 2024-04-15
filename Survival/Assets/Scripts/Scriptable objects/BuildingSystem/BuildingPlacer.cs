using GameInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    [SerializeField]
    private float _maxBuildingDistance = 3f;

    [SerializeField]
    private ConstructionLayer _constructionLayer;

    [SerializeField] 
    private PreviewLayer _previewLayer;

    [SerializeField]
    private MouseUser _mouseUser;

    private void Update()
    {
        Item item = InventoryManager.instance.GetSelectedItem(false);

        if (!IsMouseWithinBuildableRange() || _constructionLayer == null || item == null)
        {
            _previewLayer.ClearPreview();
            return;
        }

        var mousePos = _mouseUser.MouseInWorldPosition;

        if (_mouseUser.IsMouseButtonPressed(MouseButton.Right))
        {
            _constructionLayer.Destroy(mousePos);
        }

        if (item == null) return;

        _previewLayer.ShowPreview(item, mousePos, _constructionLayer.IsEmpty(mousePos));

        if(_mouseUser.IsMouseButtonPressed(MouseButton.Left) &&
            item != null &&
            item.action == Item.ActionType.build &&
            _constructionLayer.IsEmpty(mousePos))
        {
            InventoryManager.instance.GetSelectedItem(true);
            _constructionLayer.Build(mousePos, item);
        }
    }

    private bool IsMouseWithinBuildableRange()
    {
        return Vector3.Distance(_mouseUser.MouseInWorldPosition, transform.position) <= _maxBuildingDistance;
    }
}
