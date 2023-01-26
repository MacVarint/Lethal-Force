using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    public int totalAmmo;
    public int currentAmmo;
    public int magazineSize;
    public int maxAmmo;
    public Transform colliderPosition;
    public Vector3 thisCollider;
    public LayerMask isPickuppable;
    public enum ActionState
    {
        Idle,
        Shooting,
        Reloading
    }

    public ActionState actionState = ActionState.Idle;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo != magazineSize)
        {
           
        }
        Collider[] collisions = Physics.OverlapBox(colliderPosition.position, thisCollider, Quaternion.identity, isPickuppable);
        foreach(Collider c in collisions)
        {
            print(c.gameObject.name);
        }
        
    }
    public bool HasAmmo()
    {
        bool hasAmmo = currentAmmo > 0; // if current ammo is higher than 0 this will result in a "true" statement.
        return hasAmmo;
    }
    public void DecreaseAmmo()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
        }
    }
    public async Task Reload()
    {
        actionState = ActionState.Reloading;

        await Task.Delay(1000);
        if (totalAmmo >= magazineSize)
        {
            totalAmmo += currentAmmo;
            totalAmmo -= magazineSize;
            currentAmmo = magazineSize;

            
            print("reloading");
            totalAmmo = Mathf.Clamp(totalAmmo, 0, maxAmmo);
        }
        else if (totalAmmo > 0)
        {
            currentAmmo = totalAmmo;
            totalAmmo = 0;
        }
        else
        {   
            print(0);
        }

        actionState = ActionState.Idle;
    }

    public void AddAmmo(int newAmmo)
    {
        totalAmmo += newAmmo;
        totalAmmo = Mathf.Clamp(totalAmmo, 0, maxAmmo);
    }

   
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(colliderPosition.position, thisCollider);
    }
}
