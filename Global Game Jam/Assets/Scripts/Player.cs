using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health;
    private int maxhealth;
    public Image redFlash;
    private Color color;

    private float timeTracker;



    void Start()
    {
        maxhealth = health;

        color = redFlash.color;
        color.a = 0;
        redFlash.color = color;
    }

    void Update()
    {
        timeTracker += Time.deltaTime;
        if (timeTracker > 3)
        {
            updateHealth(1);
        } 

        
    }


    public void updateHealth(int deltaHealth)
    {
        if (health + deltaHealth <= maxhealth && health >= 0)
        {
            health += deltaHealth;

            if (deltaHealth > 0 && health < maxhealth)
            {
                color.a -= .3f;
                redFlash.color = color;
                timeTracker = 0;
            }
            else if (deltaHealth < 0)
            {
                timeTracker = 0f;
                color.a += .10f;
                redFlash.color = color;

            } else if (health == maxhealth) {
                timeTracker = 0;
                color.a = 0f;
                redFlash.color = color;

            }


        }



        


    }



}
