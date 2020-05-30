using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthbar;
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(GameObject.Find("Go6o").GetComponent<PlayerCombat>().TookDmg == true)
        {
            ChangeHP();
        }
        if (GameObject.Find("small Potions_0").GetComponent<Potion>().heal == true)
        {
            RestoreHP();
            GameObject.Find("small Potions_0").GetComponent<Potion>().heal = false;
        }
    }
    public void ChangeHP()
    {
        currentHealth = GameObject.Find("Go6o").GetComponent<PlayerCombat>().CurrHealth;
        healthbar.SetHealth(currentHealth);
    }
    public void RestoreHP()
    {
        GameObject.Find("Go6o").GetComponent<PlayerCombat>().CurrHealth = maxHealth;
        healthbar.SetHealth(currentHealth);
    }

}
