using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


	public Button level1;
	// Use this for initialization
	void Start () {
		level1.onClick.AddListener(Level1Open);
	}

	void Level1Open() {
		UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
	}

	// Update is called once per frame
	void Update () {

	}
}
