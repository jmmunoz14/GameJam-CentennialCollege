using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnplacedGameObject : MonoBehaviour
{
    // The Prefab that appears when the placement of the item is complete
    [SerializeField] private GameObject prefabOnPlace;
    
    [Header("Collision and Placement")]
    [SerializeField] private LayerMask placeLayer;
    [SerializeField] private LayerMask collisionLayer;
    [SerializeField] private Vector3 detectionCubeSize;
    [SerializeField] private Vector3 detectionCubeOffset;
    [SerializeField] private Transform followTarget;

    [Header("Material")]
    [SerializeField] private Material validMaterial;
    [SerializeField] private Material invalidMaterial;

    private MeshRenderer[] meshs;
    private RaycastHit hit;
    private bool canPlace;
    private Vector3 boxCastPosition;

    private void Awake()
    {
        meshs = GetAllMeshesInPrefab();

        boxCastPosition = new Vector3(transform.position.x + detectionCubeOffset.x,
            transform.position.y + detectionCubeOffset.y + detectionCubeSize.y / 2,
            transform.position.z + detectionCubeOffset.y);        
    }

    private void Start()
    {
        //GameEvents.current.OnPlaceBuilding += PlaceDownBuilding;
        //GameEvents.current.OnCancelBuilding += CancelUnplacedBuilding;
    }

    void Update()
    {
        if (IsColliding())
        {
            AssignMaterialToAllMeshes(invalidMaterial);
            canPlace = false;
        }
        else
        {
            AssignMaterialToAllMeshes(validMaterial);
            canPlace = true;
        }

        transform.position = new Vector3(Mathf.Round(followTarget.position.x), Mathf.Round(followTarget.position.y), Mathf.Round(followTarget.position.z));
    }

    // Place down the Building
    private void PlaceDownBuilding()
    {
        if (canPlace)
        {
            Instantiate(prefabOnPlace, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void CancelUnplacedBuilding()
    {
        Destroy(gameObject);
    }

    // Check if the building can be placed
    private bool IsColliding()
    {
        Collider[] collisions = Physics.OverlapBox(boxCastPosition + transform.position,
            detectionCubeSize / 2,
            Quaternion.identity,
            collisionLayer);
        if (collisions.Length > 0) return true;
        else return false;
    }

    private void AssignMaterialToAllMeshes(Material newMaterial)
    {
        foreach (MeshRenderer mesh in meshs)
            mesh.material = newMaterial;

    }

    private MeshRenderer[] GetAllMeshesInPrefab()
    {
        return GetComponentsInChildren<MeshRenderer>(true);
    }

    private void OnDestroy()
    {

    }
}
