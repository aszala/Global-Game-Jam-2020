using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    private AudioSource audioSource;


    public GameObject tutorialLocation;
    public AudioClip[] audioClips;
    

    private int currentInstruction;
    private float timeTillNextLine;

    private int droneCount = 0, deadDrones = 0;

    void Start()
    {
        currentInstruction = 0;
        timeTillNextLine = 1f;
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(playClip(currentInstruction));


    }

    public void onPlayerReachPointA()
    {
        StartCoroutine(playClip(++currentInstruction));
    }

  


    public void setDroneCount(int drones)
    {
        droneCount = drones;
        deadDrones = 0;
    }

    public void droneDeath()
    {
        deadDrones++;

        if (deadDrones == droneCount)
        {
            StartCoroutine(playClip(++currentInstruction));
        }
    }

    public IEnumerator playClip(int index)
    {

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
        playNextClip();

    }

    public void playNextClip() {
        if (currentInstruction < audioClips.Length) {
         StartCoroutine(playClip(currentInstruction));
        
        } 
        
        if (currentInstruction == 3) {
            tutorialLocation.SetActive(true);

        }   

    }


}


