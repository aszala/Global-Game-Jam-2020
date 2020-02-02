using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{

    public Player player;



    public int projectileDamage;



    void Start()
    {
      


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Contains("Enemy"))
        {
          

            player.updateHealth(projectileDamage);

            if (collision.transform.name.Contains("Proj"))
            {
                Destroy(collision.transform.gameObject);
            }
        }
    }

    void Update()
    {

    }
}
