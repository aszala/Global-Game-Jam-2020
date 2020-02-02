﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

    private AudioSource audioSource;

    public Transform droneSpawnpoint;

    public GameObject tutorialLocation;
    public AudioClip[] audioClips;

    public string[] subtitleArray;
    public string[] instructionsArray;

    private int currentInstruction;
    private float timeTillNextLine;

    private int droneCount = 0, deadDrones = 0;

    public GameObject drone;

    public GameObject player;

    public GameObject healthCube;

    public Text Instructions;

    public Text Subtitles;



    void Start()
    {
        currentInstruction = 0;
        timeTillNextLine = 0f;
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(playClip(currentInstruction));
        Subtitles.text = subtitleArray[currentInstruction];


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




        Subtitles.text = subtitleArray[currentInstruction];
        Instructions.text = instructionsArray[currentInstruction];

        currentInstruction++;

        if (currentInstruction == 3)
        {
            tutorialLocation.SetActive(true);
            currentInstruction--;
        }
        else if (currentInstruction == 5)
        {
            setDroneCount(1);
            GameObject A = Instantiate(drone);
            A.transform.position = droneSpawnpoint.position;
            StartCoroutine(playClip(currentInstruction));

        }
        else if (currentInstruction == 6)
        {
            currentInstruction--;

        }
        else if (currentInstruction == 8)
        {
            setDroneCount(3);
            GameObject A = Instantiate(drone);
            GameObject B = Instantiate(drone);
            GameObject C = Instantiate(drone);

            A.transform.position = droneSpawnpoint.position;
            B.transform.position = droneSpawnpoint.position + new Vector3(1, 0, 2);
            C.transform.position = droneSpawnpoint.position + new Vector3(-1, 0, -1);

        }
        else if (currentInstruction == 9)
        {
            currentInstruction--;

        }
        else if (currentInstruction == 10)
        {


            player.GetComponent<Player>().updateHealth(-1);

            setDroneCount(1);

            GameObject A = Instantiate(drone);

            A.transform.position = player.transform.position + new Vector3(6f, 1.5f, 6f);


            currentInstruction--;




        }
        else if (currentInstruction == 11)
        {

            GameObject C = Instantiate(healthCube);
            C.transform.position = transform.position;






        }
        else
        {
            StartCoroutine(playClip(currentInstruction));

        }



    }

    public void healthCubeCollected()
    {
        print("healthCubeCollected");
        StartCoroutine(playClip(currentInstruction));

    }
}





