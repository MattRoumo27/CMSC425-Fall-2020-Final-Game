using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyStats enemyStats;

    public int zone;

    public int currentHealth;

    private string[] drops = { "Primary", "Secondary", "HealthPack", "None"};

    public GameObject primary;
    public GameObject secondary;
    public GameObject healthPack;

    public Equipment primaryScriptable;
    public Equipment secondaryScriptable;

    private void Start() 
    {
        currentHealth = enemyStats.enemyMaxHealth; 
   
    }

    public void DealDamage(int damage) 
    {
        currentHealth -= damage;
        CheckIfDead();
    }

    private void CheckIfDead()
    {
        if (currentHealth <= 0)
        {
            DropItemOnDeath();
            Destroy(gameObject);
        }
    }

    private void DropItemOnDeath()
    {
        string item = drops[Random.Range(0, 4)];

        if (item == "None")
            return;

        else if (item == "Primary")
        {

            GameObject primaryWeapon = Instantiate(primary, transform.position + new Vector3(0, 0.1f, 0), Quaternion.Euler(0, 0, 90));
            Equipment primaryWep = Instantiate(primaryScriptable);
            if (zone == 1)
            {
                primaryWep.damageModifier = 10;
            }
            else if (zone == 2)
            {
                primaryWep.damageModifier = 10 + Random.Range(5, 10);

            }
            else if (zone == 3)
            {
                primaryWep.damageModifier = 10 + Random.Range(10, 15);
            }
            primaryWeapon.GetComponent<EquipmentPickup>().equipment = primaryWep;
        }

        else if (item == "Secondary")
        {
            GameObject secondaryWeapon = Instantiate(secondary, transform.position + new Vector3(0, 0.1f, 0), Quaternion.Euler(0, 0, 90));
            Equipment secondaryWep = Instantiate(secondaryScriptable);

            if (zone == 1)
            {
                secondaryWep.damageModifier = 5;
            }
            else if (zone == 2)
            {
                secondaryWep.damageModifier = 5 + Random.Range(5, 10);
            }
            else if (zone == 3)
            {
                secondaryWep.damageModifier = 5 + Random.Range(10, 15);
            }
            secondaryWeapon.GetComponent<EquipmentPickup>().equipment = secondaryWep;
        }

        else if (item == "HealthPack")
        {
            Instantiate(healthPack, transform.position + new Vector3(0, 0.1f, 0), Quaternion.Euler(90, 0, 90));
        }


    }
}
