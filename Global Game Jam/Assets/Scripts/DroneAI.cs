using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAI : MonoBehaviour {

    private GameObject player;

    private Tutorial tutorialController;
    public int DroneHealth;
    private bool isDead;

    void Start() {
        player = GameObject.FindGameObjectWithTag("MainCamera");
        tutorialController = GameObject.Find("Tutorial Contoller").GetComponent<Tutorial>();
    }

    void Update() {

        if (!isDead) {
            transform.LookAt(player.transform);

            if (Vector3.Distance(transform.position, player.transform.position) > 5f) {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 5 * Time.deltaTime);
            }
            
            if (DroneHealth <= 0) {
                isDead = true;
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
