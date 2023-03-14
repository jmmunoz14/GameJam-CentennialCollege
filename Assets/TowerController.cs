using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform availablePosition;

    private void Start()
    {

        availablePosition = transform;


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("posisition " + availablePosition.transform.position.ToString());

    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "AvailableTerrain")
        {
            Debug.Log("available " + collision.gameObject.name);
            Debug.Log("current transform" + availablePosition.position.ToString());

            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else
        {
            Debug.Log("not available" +collision.gameObject.name);
            Debug.Log("availablePosition transform" + availablePosition.position.ToString());
            //change turrret mode to deactivated
        }
    }
}
