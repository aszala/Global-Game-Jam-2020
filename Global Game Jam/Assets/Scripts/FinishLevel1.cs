using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishLevel1 : MonoBehaviour {

	public GameObject[] spheres;

    public Text objectiveText;
    private bool boolText = true;

	
    void Start()
    {
        objectiveText.text = "Objective: collect all power orbs";
    }

    void Update() {
		bool notDone = false;


        if (boolText) {
            StartCoroutine(endText());
            boolText = false;
        }
        foreach (GameObject o in spheres) {
			if (o != null) {
				notDone = true;
                
            }
		}

		if (!notDone) {
            finishLevel();
        }
    }

	public void finishLevel() {
		objectiveText.text = "New Objective: Restore power back to the temple";
                    StartCoroutine(waitFinishLevel());


	}

	IEnumerator waitFinishLevel() {
        yield return new WaitForSeconds(3);

 
        SceneManager.LoadScene("Final Level");

    }

    IEnumerator endText() {
        yield return new WaitForSeconds(3);

        objectiveText.text = "";
    }
}
