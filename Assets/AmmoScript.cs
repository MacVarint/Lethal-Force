using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    public int totalAmmo;
    public int currentAmmo;
    public int magazineSize;
    public int maxAmmo;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo != magazineSize)
        {
            Reload();
        }
    }
    public bool HasAmmo()
    {
        //if (currentAmmo > 0)
        //{
        //    return true;
        //}
        //return false;
        
        bool a = currentAmmo > 0 ? true : false; // conditie ? waarde als waar : waarde als niet waar (dit heet een itenary operator)
        return a;
    }
    public void DecreaseAmmo()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
        }
    }
    public void Reload()
    {
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
    }
}
