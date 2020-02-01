using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingController : MonoBehaviour {
    
    [SerializeField] public float Lightning_Length = 3f;

    public Transform follow;

	public int damage;

    void Start() {
        
    }

    void Update() {
        for (int i=0;i<transform.childCount;i++) {
            transform.GetChild(i).GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>().EndPosition =
                Lightning_Length * follow.forward +
                transform.GetChild(i).GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>().StartObject.transform.position;
        }

        RaycastHit hit;
        if (Physics.Raycast(follow.position, follow.forward, out hit, Lightning_Length))
        {
            Rigidbody rb = hit.rigidbody;

            if (rb && hit.transform.tag.Contains("Enemy"))
            {
                Vector3 force = follow.forward * 1;

                rb.AddForce(force);

				hit.transform.GetComponent<DroneAI>().takeDamage(damage);
            }
        }
    }
}
