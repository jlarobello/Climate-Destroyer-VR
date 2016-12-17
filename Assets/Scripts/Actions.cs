using UnityEngine;
using System.Collections;

public class Actions : MonoBehaviour
{
	// 0 = waterbottle
	// 1 = phone 
	// 2 = Spray can
	// 3 = oil
	// 4 = fire
	public GameObject bottle;
	public GameObject phone;
    public GameObject sprayCan;
    public Rigidbody attachPoint;
	public ParticleSystem oil;
	public ParticleSystem fire;
	public ParticleSystem spray;
	public float amountForce;
	SteamVR_TrackedObject trackedObj;
	FixedJoint joint;

    private GameObject sprayObj;
    private float timeCount;
    private int selector;
    private int spraying;

	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
        sprayObj = GameObject.Instantiate(sprayCan);
        sprayObj.transform.position = new Vector3(0, 0, 0);
        timeCount = 0;
	}

	void FixedUpdate()
	{
		// Takes the selected action from Touchpad.cs
        selector = Touchpad.selector; 

        if (selector == 0) {
            sprayObj.transform.position = new Vector3(0, 0, 0);
            throwObject(bottle);
		} else if (selector == 1) {
            sprayObj.transform.position = new Vector3(0, 0, 0);
            throwObject(phone);
		} else if (selector == 2) {
            sprayObj.transform.position = attachPoint.transform.position;
            sprayParticles (spray);
		} else if (selector == 3) {
            sprayObj.transform.position = new Vector3(0, 0, 0);
            sprayParticles(oil);
		} else if (selector == 4) {
            sprayObj.transform.position = new Vector3(0, 0, 0);
            sprayParticles(fire);
		}

    }

	void throwObject(GameObject throwObj)
	{
        
        var device = SteamVR_Controller.Input((int)trackedObj.index);
		if (joint == null && device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
		{
			var go = GameObject.Instantiate(throwObj);
			go.transform.position = attachPoint.transform.position;

			joint = go.AddComponent<FixedJoint>();
			joint.connectedBody = attachPoint;
		}
		else if (joint != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
		{
			var go = joint.gameObject;
			var rigidbody = go.GetComponent<Rigidbody>();
			Object.DestroyImmediate(joint);
			joint = null;
			Object.Destroy(go, 15.0f);

			//

			var origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
			if (origin != null)
			{
				rigidbody.velocity = origin.TransformVector(device.velocity) * amountForce;
				rigidbody.angularVelocity = origin.TransformVector(device.angularVelocity) * amountForce;
			}
			else
			{
				rigidbody.velocity = device.velocity;
				rigidbody.angularVelocity = device.angularVelocity;
			}

			rigidbody.maxAngularVelocity = rigidbody.angularVelocity.magnitude;
		}
	}

	void sprayParticles(ParticleSystem system)
	{

        //timeCount = timeCount + Time.deltaTime; 
        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (joint == null && device.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger)) {
            spraying = 1;
            system.Play ();

		} else if (joint == null && device.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger)) {
            spraying = 0;
            sprayObj.transform.position = new Vector3(0, 0, 0);
            system.Stop ();
		}
        if (spraying == 1 && selector == 2)
            updatePoints.scoreVal++;
        else if (spraying == 1 && selector == 3)
            updatePoints.scoreVal += 10;
        else if (spraying == 1 && selector == 4)
            updatePoints.scoreVal += 100;
    }
		

}