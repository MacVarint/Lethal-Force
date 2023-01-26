using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject hitObject;
    RaycastHit hit;
    Vector3 oldPosition;
    private Rigidbody rb;
    public LayerMask ground;
    private HittableScript target;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        oldPosition = transform.position;
    }
    private void FixedUpdate()
    {
      

        Vector3 difference = transform.position - oldPosition;
        bool hasHit = Physics.Raycast(oldPosition, difference, out hit, 1000f, ground);
       
        if (hasHit)
        {
            bool hitTerrain = hit.transform.gameObject.layer == 3;

            transform.position = hitTerrain ? hit.point : hit.transform.position;
            if(hitTerrain) Instantiate(hitObject, transform.position, Quaternion.identity);

            rb.velocity = Vector3.zero;
            Destroy(gameObject);








        }

        oldPosition = transform.position;
        
    }
    

}
