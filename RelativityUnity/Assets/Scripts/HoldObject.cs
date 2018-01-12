using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObject : MonoBehaviour {


	public Transform holdPosition;
	private Transform lastHitObject, newHitObject;
	private Camera camera_;
	private Collider objectCollider;
	private RaycastHit hit;

	//private Transform objectOriginalPosition;

	// Use this for initialization
	void Start () {
	
	}

	public void UpdateHeldObject(RaycastHit hit)
	{
		newHitObject = hit.transform;
		
		CheckForAlreadyHeld (newHitObject);


		
	}

void CheckForAlreadyHeld(Transform newHitObject)
{
		

		if (lastHitObject != newHitObject) {
			holdPosition.position = newHitObject.position;
			holdPosition.rotation = newHitObject.rotation;
			//newHitObject.gameObject.GetComponent<Collider> ().enabled = false;
			lastHitObject = newHitObject;

			
		} else {
			
			holdPosition.position = transform.position;
			holdPosition.rotation = transform.rotation;
			//newHitObject.gameObject.GetComponent<Collider> ().enabled = true;
			lastHitObject = null;
		}
			
			


}
	// Update is called once per frame
	void FixedUpdate () {
		if (lastHitObject != null) {
			newHitObject.position = holdPosition.position;
			newHitObject.rotation = holdPosition.rotation;

		}



	
}

}
