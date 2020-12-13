using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public HealthBar healthBar;
    public Text healthValue;

    public PauseMenu pauseMenu;
   
    public int currentHealth { get; private set; }

    public int maxHealth = 100;

   

    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            TakeDamage(10);
        }
    }



    public void TakeDamage(int damage)
    {

        damage = Mathf.Clamp(damage, 0, damage);
       //GameObject points =  Instantiate(floatingDamage, transform.position, Quaternion.identity) as GameObject;
        //points.transform.GetChild(0).GetComponent<TextMesh>().text = "" + damage;
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthValue.text = "" + currentHealth;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            //Die
            pauseMenu.OnDeath();
        }
    }

    public void Heal(int value)
    {
        currentHealth += value;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthValue.text = "" + currentHealth;
        healthBar.SetHealth(currentHealth);
    }



}
