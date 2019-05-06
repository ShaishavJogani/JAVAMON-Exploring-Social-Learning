using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class login_new : MonoBehaviour {

    public InputField username;
    public InputField password;
    public Button loginButton;

    public InputField regUsername;
    public InputField regPassword;
    public InputField age;
    public Button registerButton;

    public persistent_data_script control;

    Dictionary<string, string> staffDetails = new Dictionary<string, string>
    {
        {"aaa","aaa" },
        {"bbb","bbb" },
        {"ccc","ccc" }
    };

    void validateCredentials()
    {
		string u = username.text;
		string p = password.text;
		string foundPassword;

        if(SaveLoad.validate(username.text, password.text))
        {
            Debug.Log("Valid Credentials");
            persistent_data_script.control.currUser = username.text;
			UnityEngine.SceneManagement.SceneManager.LoadScene("Dashboard_new");
        }
        else
        {
            Debug.Log("Invalid Credentials");
        }
        password.Select();
        password.text = "";
    }

    void registerUser()
    {
        if(regUsername.text!="" && regPassword.text!="")
        {
            Debug.Log("Registered User");
            SaveLoad.Save(regUsername.text, regPassword.text);
        }
        else
        {
            Debug.Log("Registration Unsuccessful!");
            return;
        }
        regPassword.Select();
        regPassword.text = "";

		persistent_data_script.control.currUser = regUsername.text;
		UnityEngine.SceneManagement.SceneManager.LoadScene("Dashboard_new");
    }
    // Use this for initialization
    void Start () {
		password.contentType = InputField.ContentType.Password;
		regPassword.contentType = InputField.ContentType.Password;
        loginButton.onClick.AddListener(validateCredentials);
        registerButton.onClick.AddListener(registerUser);
    }

	// Update is called once per frame
	void Update () {

    }
}
