using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAITutorial : MonoBehaviour {

    private GameObject player;
    public int DroneHealth;
    private bool isDead;

    void Start() {
        player = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update() {
        transform.LookAt(player.transform);





        if (Vector3.Distance(transform.position, player.transform.position) > 5f) {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 5 * Time.deltaTime);

        }
    }

    void takeDamage() {
        if (DroneHealth > 0) {
            DroneHealth--;
        } else [
            isDead = true;
        DroneDeath();

        ]
    }

    void DroneDeath() {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        StartCoroutine(DespawnDrone());
    }


    IEnumerator DespawnDrone() {
        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    

    }
}
