using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAITutorial : MonoBehaviour {

    public GameObject player;

    void Start() {
        
    }

    void Update() {
        transform.LookAt(player.transform);

        if (Vector3.Distance(transform.position, player.transform.position) > 5f) {
            transform.position += 5f * transform.forward * Time.deltaTime;
        }
    }
}
