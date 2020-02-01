using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAITutorial : MonoBehaviour {

    private GameObject player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update() {
        transform.LookAt(player.transform);





        if (Vector3.Distance(transform.position, player.transform.position) > 5f) {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 5 * Time.deltaTime);

        }
    }
}
