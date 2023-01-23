using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    private AmmoScript gunAmmo;

    private void Start()
    {
        gunAmmo = gun.GetComponent<AmmoScript>();
    }
    public void PickUpItem(GameObject item)
    {
       AmmoBox itemContents = item.GetComponent<AmmoBox>();
        if (itemContents != null) 
        {
            gunAmmo.AddAmmo(itemContents.ammoCount);
            Destroy(item);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ammo-Box 45-ACP FMJ")
        {
            PickUpItem(other.gameObject);
        }
    }
}
