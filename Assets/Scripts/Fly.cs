using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {

    public float speed = 1.0F;
    public Vector3 pointA;
    public Vector3 pointB;
    public Vector3 pointC;
    public float delay;

    private float time = 0;
    private float startTime;
    private float journeyLength;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private bool hasDelayed;


	// Use this for initialization
	void Start () {
        time = time + Time.deltaTime;
        startTime = time;
        startPoint = pointA;
        endPoint = pointB;
        journeyLength = Vector3.Distance(startPoint, endPoint);
        hasDelayed = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (hasDelayed)
        {

            time = time + Time.deltaTime;
            float distCovered = (time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;

            if (transform.position != endPoint)
            {
                transform.position = Vector3.Lerp(startPoint, endPoint, fracJourney);
                transform.LookAt(endPoint);
            }
            else
            {
                if (startPoint == pointA)
                {
                    startPoint = pointB;
                    endPoint = pointC;
                }
                else if (startPoint == pointB)
                {
                    startPoint = pointC;
                    endPoint = pointA;
                }
                else if (startPoint == pointC)
                {
                    startPoint = pointA;
                    endPoint = pointB;
                }

                time = 0;

            }

        }
        else
        {
            time = Time.deltaTime;
            delay = delay - time; 

            if (delay <= 0)
            {
                hasDelayed = true;
            }
        }

       

    }
}
