using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NewBehaviourScript : MonoBehaviour {

	private GameObject charmander;
	private GameObject charmeleon;
	private GameObject charizard;
	public string ServerAddress = "localhost";
	public int ServerPort = 7777;
	private bl_ChatManager Chat;
	private InheritanceText InText;

	public Text objectName;

	// Use this for initialization
	void Start () {
		// NetworkManager.singleton.networkAddress = "192.168.43.22";

		Chat = FindObjectOfType<bl_ChatManager>();
    	Debug.Log("AR Camera Started!");
		charmander = GameObject.Find("Charmander");
		charmeleon = GameObject.Find("Charmeleon");
		charizard = GameObject.Find("Charizard");

		objectName.text = "Charizard";
	}

  public void startServer(){
		NetworkManager.singleton.StartHost();
		// NetworkManager.singleton.StartClient();
	}

	public void startClient(){
		NetworkManager.singleton.networkAddress = ServerAddress;
		NetworkManager.singleton.networkPort = ServerPort;
		NetworkManager.singleton.StartClient();
	}

	void Update () {
		if (Input.GetMouseButtonDown (0))		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			ShootRay(ray);
		}
	}

	void ShootRay (Ray ray) {

		Chat = FindObjectOfType<bl_ChatManager>();

		RaycastHit rhit = new RaycastHit();;
		bool objectHit = false;
		GameObject gObjectHit = null;
		if (Physics.Raycast(ray, out rhit)) {

			objectHit = true;
			gObjectHit = rhit.collider.gameObject;
	    	Debug.Log("Object clicked: " + gObjectHit.name);
			objectName.text = gObjectHit.name;
			if (gObjectHit.name == charmander.name) {
				if(Chat != null) {
					Chat.SendMessageChat("vuforia:Charmander", 1);
					return;
				}
				// charmander.SetActive(false);
				// charmeleon.SetActive(true);
				// charizard.SetActive(false);
			} else if (gObjectHit.name == charmeleon.name) {
				 if(Chat != null) {
					 Chat.SendMessageChat("vuforia:Charmeleon", 1);
					 return;
				 }
				// charmander.SetActive(false);
				// charmeleon.SetActive(false);
				// charizard.SetActive(true);
			} else if (gObjectHit.name == charizard.name) {
				if(Chat != null) {
					Chat.SendMessageChat("vuforia:Charizard", 1);
					return;
				}
				// charmander.SetActive(true);
				// charmeleon.SetActive(false);
				// charizard.SetActive(false);
			}


		}
	}
}
