using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDistToThisOBJ : MonoBehaviour {
    
    private GameObject player;
    
    public UnityEvent onPlayerReach;

    void Start() {
        player = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update() {
        if (Vector3.Distance(player.transform.position, transform.position) < 1f) {
            onPlayerReach.Invoke();

            Destroy(this.gameObject);
        }
    }
}
