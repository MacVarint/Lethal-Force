using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] float maxdictance = 100;
    public Transform gunRaycastSnapPoint;
    public Transform chamberExit;
    RaycastHit hit;
    RaycastHit hitGun;
    public GameObject hitObject;
    public GameObject bulletPrefab;
    public GameObject bulletCasing;
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
        GameObject bullet = Instantiate(bulletPrefab, gunRaycastSnapPoint.position, Quaternion.identity);
        bullet.transform.rotation = gunRaycastSnapPoint.rotation;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxdictance)) {
            Instantiate(hitObject, hit.point, Quaternion.identity);
            bullet.transform.LookAt(hit.point);
        }
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 100;
    }
}
