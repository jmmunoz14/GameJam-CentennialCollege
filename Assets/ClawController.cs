using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AllowUngrab()
    {

        Vector3 dwn = transform.TransformDirection(Vector3.down);


        if (Physics.Raycast(transform.position, dwn, out RaycastHit hit, 10f))
            if(hit.collider.gameObject.tag == "AvailableTerrain")
            {
                print("There is something in front of the object!");
            }

        Vector3 down = transform.TransformDirection(Vector3.forward) * 1f;
        Debug.DrawRay(transform.position, down, Color.cyan);
    }
}
