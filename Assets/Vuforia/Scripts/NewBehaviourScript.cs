using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
    	Debug.Log("AR Camera Started!");
	}

	void Update () {
		if (Input.GetMouseButtonDown (0))		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			ShootRay(ray);
		}
	}

	// void OnMouseDown(){
 	// 	Debug.Log(gameObject.name.ToString());
 	// }

	void ShootRay (Ray ray) {
		RaycastHit rhit = new RaycastHit();;
		bool objectHit = false;
		GameObject gObjectHit = null;
		if (Physics.Raycast(ray, out rhit)) {

		  objectHit = true;
		  gObjectHit = rhit.collider.gameObject;
	    	Debug.Log("Object clicked: " + gObjectHit.name);
		}
	}
}
