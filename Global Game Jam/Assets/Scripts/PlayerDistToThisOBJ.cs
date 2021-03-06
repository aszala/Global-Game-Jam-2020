﻿using System.Collections;
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
        
        
        if (Vector3.Distance(player.transform.position, transform.position) < TriggerDistance) {
            onPlayerReach.Invoke();

            if (this.gameObject.tag != "DontDestroy") {
            Destroy(gameObject);
            


            } 
        }
    }
}
