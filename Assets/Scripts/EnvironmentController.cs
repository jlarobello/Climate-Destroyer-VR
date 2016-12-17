using UnityEngine;
using System.Collections;

//for controlling the environment as you continue to destroy it
//stage 0 -> stage 1 -> stage 2 -> stage 3
public class EnvironmentController : MonoBehaviour {

    public GameObject scoreboard;
    public GameObject birds;
    public GameObject lake;
    public GameObject snow;
    public GameObject ash;

    public bool stage1 = false;
    public bool stage2 = false;
    public bool stage3 = false;

	// Use this for initialization
	void Start () 
    {
	    
	}
	
    //you reach the next stage by achieving a certain amount of points through the scoring system
    //after reaching stage 3, environment can get worse than that
	// Update is called once per frame
	void Update () 
    {
        float densityVal = updatePoints.scoreVal / 300000f;

   
        if(densityVal >= .05f)
        {
            stage1 = true;
        }
        if(densityVal >= .13f)
        {
            stage2 = true;
        }
        if (densityVal >= .15f)
        {
            stage3 = true;
        }

        RenderSettings.fogDensity = densityVal;
        //starts to fog up
        if (stage1)
        {
          //  RenderSettings.fog = true;
        }
       

        //fog density dependent on number of points? trash used? (so it can gradually get worse and exceed the limit)
        //birds die
        //stops snowing
        if (stage2)
        {
            snow.SetActive(false);
            birds.SetActive(false);
        }

        //lake "melts"
        //starts to rain ash
        //fog gets worse
        if(stage3)
        {
            lake.SetActive(false);
        }

    

	}
}
