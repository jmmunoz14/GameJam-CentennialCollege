using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class DrillController : MonoBehaviour
{
    public Transform rayCastOrigin;

    bool onActionCalled = false;

    public LayerMask bugLayer;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onActionCalled)
        {
            Debug.Log("Drill pressed");
            Vector3 fwd = rayCastOrigin.TransformDirection(Vector3.forward);

            var r = Physics.Raycast(rayCastOrigin.position, fwd, out RaycastHit hit, 100f, bugLayer);
            if (r)
            {
                hit.collider.gameObject.GetComponent<EnemyController>().isArmored = false;
                print("There is something in front of the object!" + hit.collider.gameObject.name);
            }

            Vector3 forward = rayCastOrigin.TransformDirection(Vector3.forward) * 100f;
            Debug.DrawRay(rayCastOrigin.position, forward, Color.cyan);


        }
    }
    // Drill destroys armor for tank enemies
    public void onAction(bool active)
    {
        if (gameObject.activeSelf && active)
        {
            onActionCalled = active;
        }
        else if (gameObject.activeSelf && !active)
        {
                   }


    }
}
