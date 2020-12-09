using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    #region Singleton
    public static HealthManager instance;

    private void Awake()
    {
        instance = this;
        currentCount = startingCount;
    }
    #endregion

    public int startingCount = 0;
    public int maxCount = 5;
    public int currentCount;

    public int healAmount = 30;
    public PlayerStats playerStats;
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha3)) {
            if (currentCount > 0)
            {
                if (playerStats.currentHealth < playerStats.maxHealth)
                {

                    playerStats.Heal(healAmount);
                    currentCount -= 1;
                    updateUI();
                }
            }
        }   
    }

    public bool AddPotion()
    {
        if (currentCount + 1 <= maxCount)
        {

            currentCount = currentCount + 1;
            updateUI();
            return true;
        }
        else
        {
            return false;
        }
    }

    void updateUI()
    {
        healthText.text = "" + currentCount;
    }


}
