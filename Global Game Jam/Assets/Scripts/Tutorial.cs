using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    private AudioSource audioSource;

    public Transform droneSpawnpoint;

    public GameObject tutorialLocation;
    public AudioClip[] audioClips;

    private int currentInstruction;
    private float timeTillNextLine;

    private int droneCount = 0, deadDrones = 0;

    public GameObject drone;

    public GameObject player;

    void Start() {
        currentInstruction = 0;
        timeTillNextLine = 1f;
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(playClip(currentInstruction));


    }

    public void onPlayerReachPointA() {
        StartCoroutine(playClip(++currentInstruction));
    }

    public void setDroneCount(int drones) {
        droneCount = drones;
        deadDrones = 0;
    }

    public void droneDeath() {
        deadDrones++;

        if (deadDrones == droneCount) {
            StartCoroutine(playClip(++currentInstruction));
        }
    }

    public IEnumerator playClip(int index) {

        if (index == 0)
        {
            yield return new WaitForSeconds(timeTillNextLine);

        }
        else
        {
            audioSource.clip = audioClips[index - 1];

            yield return new WaitForSeconds(audioSource.clip.length + timeTillNextLine);

        }
        audioSource.clip = audioClips[index];

        audioSource.Play();
        currentInstruction++;

        if (currentInstruction == 3)
        {
            tutorialLocation.SetActive(true);
            currentInstruction--;
        }
        else if (currentInstruction == 5) {
            setDroneCount(1);
            GameObject A = Instantiate(drone);
            A.transform.position = droneSpawnpoint.position;
            StartCoroutine(playClip(currentInstruction));

        }
        else if (currentInstruction == 6)
        {
            currentInstruction--;

        } else if (currentInstruction == 8) {
            setDroneCount(3);
            GameObject A = Instantiate(drone);
            GameObject B = Instantiate(drone);
            GameObject C = Instantiate(drone);
            
            A.transform.position = droneSpawnpoint.position;
            B.transform.position = droneSpawnpoint.position + new Vector3(1, 0, 2);
            C.transform.position = droneSpawnpoint.position + new Vector3(-1, 0, -1);
            
        }else if (currentInstruction == 9)
        {
            currentInstruction--;

        } else if (currentInstruction == 10) {
            player.GetComponent<Player>().updateHealth(-4);

            setDroneCount(1);

            GameObject A = Instantiate(drone);

            A.transform.position = player.transform.position + new Vector3(6f, 1.5f, 6f);

            currentInstruction--;
        } else if (currentInstruction == 11) {
            currentInstruction--;
        }
        else
        {
            StartCoroutine(playClip(currentInstruction));

        }
    }

}
