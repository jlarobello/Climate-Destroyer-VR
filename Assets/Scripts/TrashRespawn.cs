using UnityEngine;
using System.Collections;

public class TrashRespawn : MonoBehaviour {

    public GameObject trash;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            //"respawn" another object in its place
            Instantiate(trash, trash.transform);
        }
    }


}
