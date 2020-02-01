using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingController : MonoBehaviour {
    
    [SerializeField] public float Lightning_Length = 3f;

    public Transform follow;

    void Start() {
        
    }

    void Update() {
        for (int i=0;i<transform.childCount;i++) {
            transform.GetChild(i).GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>().EndPosition =
                Lightning_Length * follow.forward +
                transform.GetChild(i).GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>().StartObject.transform.position;
        }
    }
}
