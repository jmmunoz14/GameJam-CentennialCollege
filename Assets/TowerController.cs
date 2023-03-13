using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform availablePosition;

    void Start()
    {
        availablePosition = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "AvailableTerrain")
        {
            availablePosition = transform;
            Debug.Log(collision.gameObject.name);

            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            Debug.Log(collision.gameObject.name);

            transform.position = availablePosition.position;
        }
    }
}
