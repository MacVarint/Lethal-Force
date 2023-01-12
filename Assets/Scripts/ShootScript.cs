using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] float maxdictance = 100;
    RaycastHit hit;
    public GameObject hitObject;
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
    }

}
