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

    public GameObject drone;

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
        if (currentInstruction == 0)
        {
            StartCoroutine(playClip(currentInstruction));
            currentInstruction++;

        }
        else if (currentInstruction == 1)
        {
            StartCoroutine(playClip(currentInstruction));
            currentInstruction++;
        }
        else if (currentInstruction == 2)
        {
            tutorialLocation.SetActive(true);

        }
        else if (currentInstruction == 3)
        {
             StartCoroutine(playClip(currentInstruction));
            currentInstruction++;
        }
        else if (currentInstruction == 4)
        {
           

        }
        else if (currentInstruction == 5)
        {
            setDroneCount(1);
            Instantiate(drone);
        }
        else if (currentInstruction == 6)
        {
            StartCoroutine(playClip(currentInstruction));
            currentInstruction++;
        }
        else if (currentInstruction == 7)
        {

        }
        else if (currentInstruction == 8)
        {

        }
        else if (currentInstruction == 9)
        {
            StartCoroutine(playClip(currentInstruction));
            currentInstruction++;
        }  else if (currentInstruction == 10)
        {

        }
         else if (currentInstruction == 11)
        {

        }
         else if (currentInstruction == 12)
        {

        }
    
    }

}
