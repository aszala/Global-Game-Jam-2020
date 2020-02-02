using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BowlScripts : MonoBehaviour
{

    public GameObject energyOrbs;

    private GameObject[] detectBowlTags;
    private int numberofBowls;
    private int numberofOrbsPlaced;

    public Text objectives;

    private bool turnoffText = false;

    // Start is called before the first frame update
    void Start()
    {
        detectBowlTags = GameObject.FindGameObjectsWithTag("DontDestroy");
        numberofBowls = detectBowlTags.Length;

        objectives.text = "Objective: Restore power by placing hands on energy sinks.";

    }

    // Update is called once per frame
    void Update()
    {
        if (!turnoffText) {

            StartCoroutine(TurnTextOff());
        }
        if (numberofBowls == numberofOrbsPlaced)
        {

            // some cool animations go here idk

   

            StartCoroutine(endGame());
        }
    }

    public void placeOrbOnBowl()
    {
        if (numberofOrbsPlaced < numberofBowls)
        {
            print("lin");
            energyOrbs.GetComponent<PlayerDistToThisOBJ>().enabled = false;
            Instantiate(energyOrbs, this.transform.position + new Vector3(0, 2, 0), this.transform.rotation);

            numberofOrbsPlaced++;
        }
    }
    
    IEnumerator endGame() {
        yield return new WaitForSeconds(5);

        objectives.text = "OBJECTIVE COMPLETE: POWER RESTORED TO UNIT-173";
        StartCoroutine(TerminalKillsYou());
    }
    IEnumerator TerminalKillsYou() {
        yield return new WaitForSeconds(10);
        objectives.text = "";


        // terminal pops up and completely destroys you - lasts for as long as the video and fade to black
        // Voice says congrats Guardian-e27, you have failed your objective, Initiating Guardian-e28

    }

    IEnumerator TurnTextOff() {
        yield return new WaitForSeconds(5);

        turnoffText = true;

        objectives.text = "";
    }
    

  
}
