using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bug Entered");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Bug Exited");
    }
}
