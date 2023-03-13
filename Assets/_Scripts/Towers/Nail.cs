using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Nail : MonoBehaviour
{
    [SerializeField] private float _travelVelocity;
    [SerializeField] private Rigidbody rb;

    private Transform _target;

    public void InitializeNail(Transform target)
    {
        _target = target;
    }

    private void FixedUpdate()
    {
        // Calculate Direction Vector from Nail (This Object) and the target bug(target)
    }
}
