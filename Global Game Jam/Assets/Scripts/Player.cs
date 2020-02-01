using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    private int maxhealth = health;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateHealth(int deltaHealth) {
        if (health + deltaHealth <= maxhealth) {
  health += deltaHealth;
        }
      
        print(health);
    }

}
