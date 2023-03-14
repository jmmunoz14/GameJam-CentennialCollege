using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowtorchController : MonoBehaviour
{
    public Transform rayCastOrigin;

    bool onActionCalled = false;

    LayerMask bugLayer;

    public ParticleSystem fireParticle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        fireParticle.Play();


        if (onActionCalled)
        {
            Debug.Log("Drill pressed");
            Vector3 fwd = rayCastOrigin.TransformDirection(Vector3.forward);

            if (Physics.Raycast(rayCastOrigin.position, fwd, 0.1f, bugLayer))
                print("There is something in front of the object!");

            Vector3 forward = rayCastOrigin.TransformDirection(Vector3.forward) * 0.1f;
            Debug.DrawRay(rayCastOrigin.position, forward, Color.cyan);

        }

        fireParticle.Stop();
    }
    // Drill destroys armor for tank enemies
    public void onAction(bool active)
    {
        if (gameObject.activeSelf)
        {
            onActionCalled = active;
        }

    }
}
