using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{

    public GameObject prefab;
	private Touchpad touchpad;
    public Rigidbody attachPoint;
    public ParticleSystem oil;
    public ParticleSystem fire;
    public float amountForce;
    SteamVR_TrackedObject trackedObj;
    FixedJoint joint;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
		touchpad = GetComponent<Touchpad> ();
    }

    void FixedUpdate()
    {
        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (joint == null && device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            var go = GameObject.Instantiate(prefab);
            go.transform.position = attachPoint.transform.position;
            fire.Play();
            var rigidbody = go.GetComponent<Rigidbody>();

            // We should probably apply the offset between trackedObj.transform.position
            // and device.transform.pos to insert into the physics sim at the correct
            // location, however, we would then want to predict ahead the visual representation
            // by the same amount we are predicting our render poses.

            var origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
            if (origin != null)
            {
                Rigidbody projectile = rigidbody;
                rigidbody.velocity = transform.TransformDirection(new Vector3(0, 0, amountForce));
            }
            else
            {
                rigidbody.velocity = device.velocity;
                rigidbody.angularVelocity = device.angularVelocity;
            }

            rigidbody.maxAngularVelocity = rigidbody.angularVelocity.magnitude;
        }
        else if (joint == null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            fire.Stop();
        }
    }
}
