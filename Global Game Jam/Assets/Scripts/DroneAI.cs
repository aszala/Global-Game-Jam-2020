using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAI : MonoBehaviour {

    private GameObject player;

    private Tutorial tutorialController;
    public int DroneHealth;
    private bool isDead;

	public GameObject projectile;

    void Start() {
        player = GameObject.FindGameObjectWithTag("MainCamera");

		try {
			tutorialController = GameObject.Find("Tutorial Contoller").GetComponent<Tutorial>();
		} catch {

		}
    }

    void Update() {
        if (!isDead) {
            transform.LookAt(player.transform);

			if (Random.value < 0.001f) {
				GameObject pro = Instantiate(projectile);
				pro.transform.position = transform.position + (transform.forward * 0.5f);
				pro.transform.LookAt(player.transform);

				pro.GetComponent<Rigidbody>().AddForce(transform.forward * 20);
			}

            if (Vector3.Distance(transform.position, player.transform.position) > 5f) {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 5 * Time.deltaTime);
            }
            
            if (DroneHealth <= 0) {
                isDead = true;

				if (tutorialController != null)
					tutorialController.droneDeath();
                
                gameObject.GetComponent<Rigidbody>().useGravity = true;

                StartCoroutine(DespawnDrone());
            }
        }
    }

    public void takeDamage(int damage) {
        if (DroneHealth > 0) {
            DroneHealth -= damage;
        } 
    }
    
    IEnumerator DespawnDrone() {
        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }
}
