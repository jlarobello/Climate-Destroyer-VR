using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class updatePoints : MonoBehaviour {

    private  Text scoreboard; 
    public static int scoreVal;
    
	// Use this for initialization
	void Start () {
        scoreboard = GetComponent<Text>();
        scoreVal = 0;
	}
	
	// Update is called once per frame
	void Update () {
        scoreboard.text =  scoreVal.ToString();
	}
}
