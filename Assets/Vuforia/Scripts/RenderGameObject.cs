using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderGameObject : MonoBehaviour {

	public Text objectName;

	private GameObject c1;
	private GameObject c2;
	private GameObject c3;

	string character = null;

	// Use this for initialization
	void Start () {
		c1 = GameObject.Find("Charmander");
		c2 = GameObject.Find("Charmeleon");
		c3 = GameObject.Find("Charizard");
	}

	// Update is called once per frame
	void Update () {
		character = objectName.text;
		if(character == "Charmander") {
		  c1.SetActive(false);
		  c2.SetActive(true);
		  c3.SetActive(false);
		} else if(character == "Charmeleon") {
		  c1.SetActive(false);
		  c2.SetActive(false);
		  c3.SetActive(true);
		} else if(character == "Charizard") {
		  c1.SetActive(true);
		  c2.SetActive(false);
		  c3.SetActive(false);
		}
	}
}
