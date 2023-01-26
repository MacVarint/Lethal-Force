using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private StatsScript stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<StatsScript>();

        stats.CreateStat("Health", ObjectStats.StatType.HealthPoints, 50);
    }

    // Update is called once per frame
    void Update()
    {
        if(stats.GetStatValue("Health") <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Damage(float damage)
    {
        stats.ChangeStat("Health", -Mathf.Abs(damage));
        Debug.Log(stats.GetStatValue("Health"));
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.name == "Bullet")
        {
            Damage(10);
        }

        Debug.Log(other.name == "Bullet");
    }

 
}
