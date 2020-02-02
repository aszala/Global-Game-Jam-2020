using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel1 : MonoBehaviour {

	public GameObject[] spheres;

    void Start()
    {
        
    }

    void Update() {
		bool notDone = false;

        foreach (GameObject o in spheres) {
			if (o != null) {
				notDone = true;
			}
		}

		if (!notDone) {
			SceneManager.LoadScene("Final Level");
		}
    }
}
