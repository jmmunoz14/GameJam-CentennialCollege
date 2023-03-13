using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //reveals invisible enemies and also slows enemies
    public void onAction(bool active)
    {
        if (gameObject.activeSelf)
        {
            if (active)
            {
                Debug.Log("Spray pressed");

            }
            else
            {
                Debug.Log("Spray unpressed");
            }
        }

    }

}
