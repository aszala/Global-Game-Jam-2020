using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalSceneController : MonoBehaviour
{

    public Text objectives;
    public GameObject troller;

    private bool gameEndBool = true;
    // Start is called before the first frame update
    void Start()
    {
        objectives.text = "Objective: Restore power by placing hands on energy sinks.";

        StartCoroutine(TurnTextOff());


    }

    void Update()
    {
        if ((GameObject.FindGameObjectsWithTag("Orbs").Length == 9) && gameEndBool)
        {
            StartCoroutine(endGame());
        }
    }



    IEnumerator endGame()
    {
        troller.SetActive(true);

        yield return new WaitForSeconds(5);

        gameEndBool = false;

        objectives.text = "OBJECTIVE COMPLETE: POWER RESTORED TO UNIT-173";
        StartCoroutine(TerminalKillsYou());
    }
    IEnumerator TerminalKillsYou()
    {
        yield return new WaitForSeconds(10);
        objectives.text = "";



        // terminal pops up and completely destroys you - lasts for as long as the video and fade to black
        // Voice says congrats Guardian-e27, you have failed your objective, Initiating Guardian-e28
        SceneManager.LoadScene("Tutorial");
    }

    IEnumerator TurnTextOff()
    {
        yield return new WaitForSeconds(10);



        objectives.text = "";
    }




}

