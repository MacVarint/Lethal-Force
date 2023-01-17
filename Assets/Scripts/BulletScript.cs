using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject hitObject;
    RaycastHit hit;
    Vector3 oldPosition;
    public LayerMask ground;
    private void Start()
    {
        oldPosition = transform.position;
    }
    private void FixedUpdate()
    {
        Vector3 difference = transform.position - oldPosition;
        if (Physics.Raycast(oldPosition, difference,out hit,1000f,ground))
        {
            Instantiate(hitObject, hit.point, Quaternion.identity);
            Destroy(this);
        }
        oldPosition = transform.position;
        
    }
    

}
