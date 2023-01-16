using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] float maxdictance = 100;
    public Transform gunRaycastSnapPoint;
    RaycastHit hit;
    RaycastHit hitGun;
    public GameObject hitObject;
    public GameObject hitObject2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    
    // Update is called once per frame
    public void Shoot()
    {
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxdictance)) {
            Instantiate(hitObject, hit.point, Quaternion.identity);
        }
        if (Physics.Raycast(gunRaycastSnapPoint.position, gunRaycastSnapPoint.forward, out hitGun, maxdictance))
        {
            Instantiate(hitObject2, hitGun.point, Quaternion.identity);
        }
    }

}
