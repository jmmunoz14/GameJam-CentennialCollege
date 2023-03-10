using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnplacedBuilding : MonoBehaviour
{
    public GameObject prefab;
    public LayerMask placeLayer;
    public LayerMask collisionLayer;
    public string cameraName;
    public Vector3 detectionCubeSize;
    public Vector3 detectionCubeOffset;
    public Material green;
    public Material red;
    [SerializeField] private Transform followTarget;

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


        followTarget = GetComponent<Camera>().transform.parent;
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
            AssignMaterialToAllMeshes(red);
            canPlace = false;
        }
        else
        {
            AssignMaterialToAllMeshes(green);
            canPlace = true;
        }

        transform.position = new Vector3(Mathf.Round(followTarget.position.x), Mathf.Round(followTarget.position.y), Mathf.Round(followTarget.position.z));
    }

    // Place down the Building
    private void PlaceDownBuilding()
    {
        if (canPlace)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
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
