using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BowlScripts : MonoBehaviour
{

    public GameObject energyOrbs;

    private GameObject[] detectBowlTags;
    private int numberofBowls;
    private int numberofOrbsPlaced;

    public Canvas ObjectivesCanvas;
    private Text objectives;

    private bool addObject = true;


    // Start is called before the first frame update
    void Awake()
    {
        objectives = ObjectivesCanvas.GetComponentInChildren<Text>();
        objectives.text = "Objective: Restore power by placing hands on energy sinks.";

        StartCoroutine(TurnTextOff());



        detectBowlTags = GameObject.FindGameObjectsWithTag("DontDestroy");
        numberofBowls = detectBowlTags.Length;



    }

    // Update is called once per frame
    void Update()
    {
        print(numberofOrbsPlaced);
      
       
    }

  
    public void placeOrbOnBowl()
    {
        if (numberofOrbsPlaced < numberofBowls)
        {   
            
            if (addObject) {
                
                

                GameObject a = Instantiate(energyOrbs, this.transform.position + new Vector3(0, 2, 0), this.transform.rotation);
                addObject = false;
                a.GetComponent<PlayerDistToThisOBJ>().enabled = false;

            } 





        }


    }

    IEnumerator endGame()
    {
        yield return new WaitForSeconds(5);

        objectives.text = "OBJECTIVE COMPLETE: POWER RESTORED TO UNIT-173";
        StartCoroutine(TerminalKillsYou());
    }
    IEnumerator TerminalKillsYou()
    {
        yield return new WaitForSeconds(10);
        objectives.text = "";


        // terminal pops up and completely destroys you - lasts for as long as the video and fade to black
        // Voice says congrats Guardian-e27, you have failed your objective, Initiating Guardian-e28

    }

    IEnumerator TurnTextOff()
    {
        yield return new WaitForSeconds(10);



        objectives.text = "";
    }



}
