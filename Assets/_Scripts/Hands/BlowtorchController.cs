using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowtorchController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 10))
            print("There is something in front of the object!");
    }

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
