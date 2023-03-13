using UnityEngine;

public class TowerMovement : MonoBehaviour
{
    public GameObject[] possibleTargets;
    public float radiusOfVision;
    private Transform thisTransform;
    private GameObject currentTarget;
    private Material radiusOfVisionMaterial;

    void Start()
    {
        thisTransform = transform;
        currentTarget = FindClosestTarget();

        // Create a new material with a transparent green color
        radiusOfVisionMaterial = new Material(Shader.Find("Unlit/Color"));
        radiusOfVisionMaterial.color = new Color(0f, 1f, 0f, 0.25f);

        // Add a new SphereCollider component to the Tower GameObject
        SphereCollider radiusOfVisionCollider = gameObject.AddComponent<SphereCollider>();
        radiusOfVisionCollider.radius = radiusOfVision;

        // Set the new material to the Mesh Renderer component of the SphereCollider
        MeshRenderer radiusOfVisionRenderer = radiusOfVisionCollider.gameObject.GetComponent<MeshRenderer>();
        radiusOfVisionRenderer.material = radiusOfVisionMaterial;

        // Set the SphereCollider to not be visible in the game view
        radiusOfVisionRenderer.enabled = false;
    }

    void Update()
    {
        if (currentTarget != null)
        {
            float distanceToTarget = Vector3.Distance(thisTransform.position, currentTarget.transform.position);
            if (distanceToTarget > radiusOfVision)
            {
                // Look for the next closest target that may come into vision of the tower
                GameObject nextTarget = null;
                float nextDistance = Mathf.Infinity;
                foreach (GameObject possibleTarget in possibleTargets)
                {
                    float distanceToPossibleTarget = Vector3.Distance(thisTransform.position, possibleTarget.transform.position);
                    if (distanceToPossibleTarget <= radiusOfVision && distanceToPossibleTarget < nextDistance && possibleTarget != currentTarget)
                    {
                        nextDistance = distanceToPossibleTarget;
                        nextTarget = possibleTarget;
                    }
                }
                currentTarget = nextTarget;
            }

            Vector3 direction = currentTarget.transform.position - thisTransform.position;
            direction.y = 0f;
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                thisTransform.rotation = Quaternion.RotateTowards(thisTransform.rotation, targetRotation, Time.deltaTime * 180f);
            }
        }
        else
        {
            // Look for the closest target within the radius of vision
            currentTarget = FindClosestTarget();
        }
    }

    GameObject FindClosestTarget()
    {
        float closestDistance = Mathf.Infinity;
        GameObject closestTarget = null;
        foreach (GameObject possibleTarget in possibleTargets)
        {
            float distanceToTarget = Vector3.Distance(thisTransform.position, possibleTarget.transform.position);
            if (distanceToTarget <= radiusOfVision && distanceToTarget < closestDistance)
            {
                closestDistance = distanceToTarget;
                closestTarget = possibleTarget;
            }
        }
        return closestTarget;
    }
}
