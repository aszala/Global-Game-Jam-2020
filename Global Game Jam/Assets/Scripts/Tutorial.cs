using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    private AudioSource audioSource;

    public AudioClip[] audioClips;

    private int currentInstruction = 0, timeTillNextLine = 1500;

    private int droneCount = 0, deadDrones = 0;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        
        StartCoroutine(playClip(currentInstruction));
        StartCoroutine(playClip(++currentInstruction));
        StartCoroutine(playClip(++currentInstruction));
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
        yield return new WaitForSeconds(timeTillNextLine);

        

        if (audioSource.isPlaying) {
            audioSource.Stop();
        }

        audioSource.clip = audioClips[index];

        audioSource.Play();

        yield return new WaitForSeconds(audioClips[index].length);
    }
}
