using UnityEngine;
using System.Collections;
using Valve.VR;

public class myTouchpad : MonoBehaviour
{
    public GameObject player;

    SteamVR_Controller.Device device;
    SteamVR_TrackedObject controller;

    Vector2 touchpad;

    private float sensitivityX = 1.5F;
    private Vector3 playerPos;

    void Start()
    {
        controller = gameObject.GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        device = SteamVR_Controller.Input((int)controller.index);
        //If finger is on touchpad
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            //Read the touchpad values
            touchpad = device.GetAxis(EVRButtonId.k_EButton_SteamVR_Touchpad);


            // Handle movement via touchpad
            if (touchpad.y > 0.2f || touchpad.y < -0.2f)
            {
                // Move Forward
                player.transform.position -= player.transform.forward * Time.deltaTime * (touchpad.y * 5f);

                // Adjust height to terrain height at player positin
                playerPos = player.transform.position;
                playerPos.y = Terrain.activeTerrain.SampleHeight(player.transform.position);
                player.transform.position = playerPos;
            }

            // handle rotation via touchpad
            if (touchpad.x > 0.3f || touchpad.x < -0.3f)
            {
                player.transform.Rotate(0, touchpad.x * sensitivityX, 0);
            }

            //Debug.Log ("Touchpad X = " + touchpad.x + " : Touchpad Y = " + touchpad.y);
        }
    }
}
