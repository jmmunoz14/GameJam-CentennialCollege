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
    void Update()
    {
        
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
