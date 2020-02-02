using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int health;
    private int maxhealth;



    void Start()
    {
        maxhealth = health;
    }

    void Update()
    {

    }


	public void updateHealth(int deltaHealth)
    {
        if (health + deltaHealth <= maxhealth)
        {
            health += deltaHealth;
        }

		print(health);
      
    }

}
