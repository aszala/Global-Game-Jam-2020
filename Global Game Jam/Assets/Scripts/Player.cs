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



    void Start()
    {
        maxhealth = health;

        color = redFlash.color;
        color.a = 0;
        redFlash.color = color;
    }

    void Update()
    {

    }


    public void updateHealth(int deltaHealth)
    {
        if (health + deltaHealth <= maxhealth && health >= 0)
        {
            health += deltaHealth;
        }

        color.a += .10f;
        redFlash.color = color;
        StartCoroutine(healthFadeOut());


        print(health);

    }

     IEnumerator healthFadeOut() {
        yield return new WaitForSeconds(.1f);

        color.a -= .05f;
        
        redFlash.color = color;

    }

}
