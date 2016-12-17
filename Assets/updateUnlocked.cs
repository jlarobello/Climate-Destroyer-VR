using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class updateUnlocked : MonoBehaviour {

    private Text unlocked;
    private bool showns7, shownspray, shownoil, shownfire;
	// Use this for initialization
	void Start () {
        unlocked = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (Touchpad.s7_unlocked && !showns7)
        {
            unlocked.text = "Galaxy Note 7 ";
            showns7 = true;

        } else if (Touchpad.spray_unlocked && !shownspray)
        {
            unlocked.text = "Galaxy Note 7 and Aerosol Spray!";
            shownspray = true;
        }
        else if (Touchpad.oil_unlocked && !shownoil)
        {
            unlocked.text = "Galaxy Note 7, Aerosol Spray and Oil!";
            shownoil = true;
        }
        else if (Touchpad.fire_unlocked && !shownfire)
        {
            unlocked.text = "Galaxy Note 7, Aerosol Spray, Oil and Fire!";
            shownfire = true;
        }
    }
}
