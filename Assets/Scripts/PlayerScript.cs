using ObjectStats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using UnityEditor.Timeline.Actions;
using UnityEngine.InputSystem;


[RequireComponent(typeof(StatsScript))]
public class PlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private StatsScript stats;
    public ViewHeightScript arm;
    public MovementScript move;
    public AmmoText ammoCount;
    public PrefabsSO prefabs;
    private AmmoScript gunAmmo;
    private PlayerInputActions playerInputActions;
    public ViewHeightScript camPos;
    public Vector3 crouchOffSet;
    public enum ActionState
    {
        Idle,
        Reloading
    }

    public ActionState actionState = ActionState.Idle;

    private void Awake()
    {
        move = GetComponent<MovementScript>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Reload.performed += Reload;
    }
    private void Start()
    {
        
        
        gunAmmo = gun.GetComponent<AmmoScript>();
        stats = GetComponent<StatsScript>();

        stats.CreateStat("Health", StatType.HealthPoints, 100);
        Debug.Log(stats.GetStatValue("Health"));

        /*
        stats.CreateStat("Reload", StatType.HealthPoints, 0);

        
        GameObject resourcebar = Instantiate(prefabs.pfResourcebar);
        ResourceBarScript resourceBarScript = resourcebar.GetComponent<ResourceBarScript>();
        resourceBarScript.SetStat(stats, "Reload");
        */


    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            Damage(10);
        }
        //stats.ChangeStat("Reload", 0.01f);
        ammoCount.UpdateText(gunAmmo.currentAmmo, gunAmmo.totalAmmo);

        if(move.movementAction == MovementScript.MovementActions.Crouching)
        {
            camPos.SetViewHeight(crouchOffSet);
            arm.SetViewHeight(crouchOffSet);
        }
        else
        {
            camPos.ResetViewHeight();
            arm.ResetViewHeight();

        }
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
        else if (other.name == "Bullet")
        {
            Damage(10);
        }
    }

    public void Damage(float damage)
    {
        stats.ChangeStat("Health", -damage);
        Debug.Log("OUCH! " + stats.GetStatValue("Health"));
    }
    public async void Reload(InputAction.CallbackContext callbackContext)
    {
        if (actionState != ActionState.Reloading)
        {
            actionState = ActionState.Reloading;
            await ReloadAction();
            actionState = ActionState.Idle;
        }
    }

    public async Task ReloadAction()
    { 
        await gunAmmo.Reload();
    }


}
