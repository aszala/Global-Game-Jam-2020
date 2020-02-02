using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingController : MonoBehaviour {
    
    public GameObject leftWeapon, rightWeapon;

    void Start() {
        
    }

    void Update() {
        float indexL = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
        float handL = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch);

        if (indexL > 0.5f && handL > 0.5f) {
			var em = leftWeapon.transform.GetChild(0).GetComponent<ParticleSystem>().emission;
			em.enabled = true;
			em = leftWeapon.transform.GetChild(1).GetComponent<ParticleSystem>().emission;
			em.enabled = true;
		} else {
			var em = leftWeapon.transform.GetChild(0).GetComponent<ParticleSystem>().emission;
			em.enabled = true;
			em = leftWeapon.transform.GetChild(1).GetComponent<ParticleSystem>().emission;
			em.enabled = true;
		}

        float indexR = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        float handR = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);

        if (indexR > 0.5f && handR > 0.5f) {
            rightWeapon.SetActive(true);
        } else {
            rightWeapon.SetActive(false);
        }
    }
}
