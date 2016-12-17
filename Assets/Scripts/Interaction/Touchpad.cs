using UnityEngine;
using System.Collections;

//code source: https://www.youtube.com/watch?v=Awr52z9Y670 
public class Touchpad : MonoBehaviour {

	public static int selector = 0;
	public static bool s7_unlocked, spray_unlocked, oil_unlocked, fire_unlocked;

	private int scoreVal;
    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;
    private SteamVR_TrackedController controller;

	// Use this for initialization
	void Start () {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        controller = GetComponent<SteamVR_TrackedController>();
        controller.PadClicked += Controller_PadClicked;
	}
	
	// Update is called once per frame
	void Update () {
		scoreVal = updatePoints.scoreVal;
        device = SteamVR_Controller.Input((int)trackedObject.index);

        if (scoreVal > 500)
			s7_unlocked = true;
		if (scoreVal > 2500)
			spray_unlocked = true;
		if (scoreVal > 4000)
			oil_unlocked = true;
		if (scoreVal > 10000)
			fire_unlocked = true;

       /* s7_unlocked = true;
        spray_unlocked = true;
        oil_unlocked = true;
        fire_unlocked = true;*/
	}

    private void Controller_PadClicked(object sender, ClickedEventArgs e)
    {
        if (device.GetAxis().x != 0 || device.GetAxis().y != 0)
        {
            selector += getSelectorIndex(device.GetAxis().x, device.GetAxis().y);

			if (selector < 0)
				selector = 0;
			else if (selector == 1 && !s7_unlocked)
				selector = 0;
			else if (selector == 2 && !spray_unlocked)
				selector = 1;
			else if (selector == 3 && !oil_unlocked)
				selector = 2;
			else if (selector == 4 && !fire_unlocked)
				selector = 3;
			else if (selector > 4)
				selector = 4;
        }
    }

    // answers.unity3d.com/questions/1032673/how-to-get-
    private static int getSelectorIndex(float x, float y)
    {
        int value = 0;
        float deg = (float)((Mathf.Atan2(x, y) / Mathf.PI) * 180f);
        if (deg < 0) deg += 360;
        if (deg <= 180) value = 1;
        else if (deg > 180) value = -1;
        return value;
    }
}
