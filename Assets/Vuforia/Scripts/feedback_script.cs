using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class feedback_script : MonoBehaviour {

	public Button button;
	
	void dash() 
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Dashboard_new");
	}
	
	// Use this for initialization
	void Start () {
		button.onClick.AddListener(dash);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
