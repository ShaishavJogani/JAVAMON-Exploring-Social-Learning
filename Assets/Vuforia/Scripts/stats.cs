using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stats : MonoBehaviour {

	public Button gotodash; 
	// Use this for initialization
	
	void dash() 
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Dashboard_new");
	}
	void Start () {
		gotodash.onClick.AddListener(dash);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
