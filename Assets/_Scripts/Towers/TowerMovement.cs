using System.Collections;
using UnityEngine;

public class TowerMovement : MonoBehaviour
{

    [SerializeField] private TowerDetection _towerDetection;
    [SerializeField] private float _rotationSpeedInDegrees;
    //[SerializeField] private GameObject areaDamager;
    //[SerializeField] private ParticleSystem particleSys;

    private Transform _currentTarget;

    void Start()
    {
        //particleSys.Stop();
        _towerDetection.OnTargetUpdate += (newTarget) => _currentTarget = newTarget;
    }

    void Update()
    {
        // > If there is not target then do nothing
        if(_currentTarget == null) return;


        // > Rotate Towards Target
        Vector3 direction = _currentTarget.transform.position - transform.position;
        direction.y = 0f;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeedInDegrees);
        }        
    }    

    private void OnDrawGizmos()
    {
        if(_currentTarget != null)
        {
            Gizmos.DrawLine(transform.position, _currentTarget.position);
            //particleSys.Play();
            //areaDamager.SetActive(true);
        }
    }
}
