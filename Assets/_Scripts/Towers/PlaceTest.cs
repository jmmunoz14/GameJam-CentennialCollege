using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTest : MonoBehaviour
{
    [SerializeField] private LayerMask placeable;

    [SerializeField]  private Transform rayCastOrigin;
    [SerializeField]  private Vector3 rayCastHitPosition;
    [SerializeField] private Transform buildingHandle;

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        if (mousePos == null) return;
        Ray mouseRay = Camera.current.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (Physics.Raycast(mouseRay, out hit, 100f, placeable))
        {
            rayCastHitPosition = hit.point;
            buildingHandle.position = hit.point;
        }
    }
}
