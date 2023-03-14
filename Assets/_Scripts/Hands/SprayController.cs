using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayController : MonoBehaviour
{
    public Transform rayCastOrigin;

    bool onActionCalled = false;

    LayerMask bugLayer = 9;

    public ParticleSystem foamParticles;

    // Start is called before the first frame update
    void Start()
    {
        foamParticles.Stop();
    }

    // Update is called once per frame
    void Update()
    {

        if (onActionCalled)
        {
            Vector3 fwd = rayCastOrigin.TransformDirection(Vector3.forward);

            if (Physics.SphereCast(rayCastOrigin.position, 0.1f, fwd, out RaycastHit hit, 1f, bugLayer)) 
            {
                hit.collider.gameObject.GetComponent<EnemyController>().isSteathly = false;
                print("There is something in front of the object!");
            }

            //OnDrawGizmosSelected();
        }

    }

    //reveals invisible enemies and also slows enemies
    public void onAction(bool active)
    {
        if (gameObject.activeSelf && active)
        {
            Debug.Log("Spray pressed");
            onActionCalled = active;
            foamParticles.Play();
        }
        else if (gameObject.activeSelf && !active) {
            Debug.Log("Particles");
            foamParticles.Stop();
        }

    }

}
