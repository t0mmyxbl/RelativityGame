using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObject : MonoBehaviour {


	public Transform holdPosition;
	private GameObject lastHitObject, newHitObject;
	private Camera camera_;
	private Collider objectCollider;
	private RaycastHit hit;

	//private Transform objectOriginalPosition;

	// Use this for initialization
	void Start () {
	
	}

	public void UpdateHeldObject(GameObject gObject)
	{
		newHitObject = gObject;
		
		CheckForAlreadyHeld (newHitObject);


		
	}

void CheckForAlreadyHeld(GameObject newHitObject)
{
		

		if (lastHitObject != newHitObject) {
			holdPosition.position = newHitObject.transform.position;
			holdPosition.rotation = newHitObject.transform.rotation;
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
			newHitObject.transform.position = holdPosition.position;
			newHitObject.transform.rotation = holdPosition.rotation;

		}



	
}

}
