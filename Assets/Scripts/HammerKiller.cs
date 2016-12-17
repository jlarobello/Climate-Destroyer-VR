using UnityEngine;
using System.Collections;

public class HammerKiller : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        Debug.Log("Hammer script working");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    
	}

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Fish")) {
            Debug.Log("Collided with Fish!");
            other.gameObject.SetActive(false);
        }
    }
}
