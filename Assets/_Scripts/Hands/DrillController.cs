using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 10))
            print("There is something in front of the object!");


        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
    }
    // Drill destroys armor for tank enemies
    public void onAction(bool active)
    {
        if (gameObject.activeSelf)
        {
            if (active)
            {
                Debug.Log("Drill pressed");

            }
            else
            {
                Debug.Log("Drill unpressed");
            }
        }

    }
}
