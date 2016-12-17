using UnityEngine;
using System.Collections;

//code source: http://answers.unity3d.com/questions/1101929/keeping-character-upright-with-addtorque.html 
public class Upright : MonoBehaviour {

    
    private Rigidbody rb;
    public int uprightTorque = 100;
    public Transform playerPos;
    private bool collided;
  
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collided = false;
        //StartCoroutine(Waddle( 1f));


    }
	
	// Update is called once per frame
	void Update() 
    {
        var rot = Quaternion.FromToRotation(transform.up, Vector3.forward);
        rb.AddTorque(new Vector3(rot.z, rot.y, rot.z) * uprightTorque);
        
        if ((transform.eulerAngles.x <= 45 || transform.eulerAngles.x >= 135) && !collided ) //keeping these angles for now
        {
            Debug.Log("going up");
           
            //resetting rotation to make it upright again
            transform.rotation = Quaternion.Euler(0, 90, 0);
        } 
        
	}

    void OnCollisionEnter(Collision obj)
    {
       // Debug.Log("goteem");
        if (obj.gameObject.tag == "projectile" )
        {
            collided = true;
        }
    }

    
    //code source: http://answers.unity3d.com/questions/1073407/make-object-move-back-and-forth.html 
    private IEnumerator Waddle( float distance)
    {
        float dist = transform.position.x + 5;
        while(true)
        {   
            if(transform.position.x == dist)
            {
              //  Debug.Log("going back");
                transform.position = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
            }
            else if(transform.position.x >= dist)
            {
             //   Debug.Log("going forward");
                transform.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
            }
            yield return new WaitForSeconds(100);
        }

    }

    void FixedUpdate()
    {
        
        //rb.MovePosition(transform.position + playerPos.position * Time.deltaTime);
    }
}
