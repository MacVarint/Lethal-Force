using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public Animator animator;
    public Animator pistolAnimator;
    AmmoScript ammoScript;
    public ParticleSystem particleSystem1;
    [SerializeField] float maxdictance = 100;
    public Transform gunRaycastSnapPoint;
    public Transform chamberExit;
    RaycastHit hit;
    RaycastHit hitGun;
    public GameObject bulletPrefab;
    public GameObject bulletCasingPrefab;
    // Start is called before the first frame update
    void Start()
    {
        ammoScript = GetComponent<AmmoScript>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            if (ammoScript.HasAmmo() && !animator.GetCurrentAnimatorStateInfo(0).IsName("Recoil"))
            {
                Shoot();
            }
        }
    }
    
    // Update is called once per frame
    public void Shoot()
    {
        animator.SetTrigger("Shoot");
        pistolAnimator.SetTrigger("Shoot");

        particleSystem1.Play();
        ParticleSystem.EmissionModule em = particleSystem1.emission;
        em.enabled = true;

        GameObject bullet = Instantiate(bulletPrefab, gunRaycastSnapPoint.position, Quaternion.identity);
        GameObject bulletCasing = Instantiate(bulletCasingPrefab, chamberExit.position, chamberExit.rotation, transform);
        bullet.transform.rotation = gunRaycastSnapPoint.rotation;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxdictance)) {
            bullet.transform.LookAt(hit.point);
        }
        else
        {
            Vector3 target = Camera.main.transform.position + Camera.main.transform.forward * maxdictance;
            bullet.transform.LookAt(target);
        }
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 100;
        ammoScript.DecreaseAmmo();

        bulletCasing.GetComponent<Rigidbody>().velocity = bulletCasing.transform.right * 1f+Vector3.up;
        
    }
}
