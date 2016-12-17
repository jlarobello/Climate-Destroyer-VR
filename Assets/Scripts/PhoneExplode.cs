using UnityEngine;
using System.Collections;

public class PhoneExplode : MonoBehaviour {

    public GameObject S7;
    public GameObject explosion;

    private AudioClip aud;

	// Use this for initialization
	void Start() 
    {
        
    }
	
	// Update is called once per frame
	void Update() 
    {
        explosion.transform.position = S7.transform.position;
	}

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("kaboom!");
        Instantiate(explosion, other.transform);
		explosion.GetComponentInChildren<ParticleSystem>().Play();
        Destroy(S7);
    }
}
