using UnityEngine;
using System.Collections;

public class checkPoints : MonoBehaviour {

    public int value;
    private float distance;
    private Rigidbody rb;
    private bool gavePoint;
    private Vector3 startPos;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        gavePoint = false;
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(startPos, transform.position); 

        if (distance > 5 && !gavePoint)
        {
            updatePoints.scoreVal += value;
            gavePoint = true;
        }
       

	}
}
