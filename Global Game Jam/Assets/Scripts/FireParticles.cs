using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticles : MonoBehaviour
{
    private ParticleSystem PSystem;
    private ParticleCollisionEvent[] CollisionEvents;
    public float fireforce = 0f;

	public int damage;

    void Start()
    {
        PSystem = GetComponent<ParticleSystem>();

        CollisionEvents = new ParticleCollisionEvent[8];
    }

    public void OnParticleCollision(GameObject other) {

        int collCount = PSystem.GetSafeCollisionEventSize();
 
        if (collCount > CollisionEvents.Length)
            CollisionEvents = new ParticleCollisionEvent[collCount];
 
        int eventCount = PSystem.GetCollisionEvents(other, CollisionEvents);

        for (int i = 0; i < eventCount; i++)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (rb && CollisionEvents[i].colliderComponent.tag.Contains("Enemy"))
            {
                Vector3 pos = CollisionEvents[i].intersection;
                Vector3 force = CollisionEvents[i].velocity * fireforce / 10;
                rb.AddForce(force);

				other.GetComponent<DroneAI>().takeDamage(damage);
			}
        }
    }    
}

