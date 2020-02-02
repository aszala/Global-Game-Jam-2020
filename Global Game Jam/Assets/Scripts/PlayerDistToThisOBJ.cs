using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDistToThisOBJ : MonoBehaviour {
    
    private GameObject player;
    
    public UnityEvent onPlayerReach;

    public float TriggerDistance;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        print("Hose");
        if (Vector3.Distance(player.transform.position, transform.position) < TriggerDistance) {

            onPlayerReach.Invoke();

            Destroy(this.gameObject);
        }
    }
}
