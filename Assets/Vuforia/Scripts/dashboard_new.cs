using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class dashboard_new : MonoBehaviour {

	Color r = new Color(0.831f, 0.043f, 0.16f, 0.53f);
	Color g = new Color(0.105f, 0.623f, 0.372f, 1f);
	Color all = new Color(0.29f, 0.0f, 0.396f,1f);
	public Button logout;
    public class User {
        public string username;
        public float completionPercent;
        public float[] levelCompletionTime;

        public User(string uname)
        {
            username = uname;
        }
    }

    float[] studentsCompletionPercent = new float[12] { 100, 65, 55, 50, 52, 71, 60, 75, 0, 80, 30, 0};
    float[] averageCompletionTime = new float[12] { 10, 12, 11, 20, 11, 16, 10, 15, 20, 13, 11, 20};

    public Button[] levelButtons = new Button[12];
    public Button[] peerLevelButtons = new Button[12];

    public Text currUser;
    public Button profilePage;
    public User[] users = new User[3] { new User("aaa"), new User("bbb"), new User("ccc") };

    void openProfilePage()
    {
		UnityEngine.SceneManagement.SceneManager.LoadScene("ProfilePage");
    }

	void openLevelGame()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
	}

	void logOut()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainPage");
	}
    // Use this for initialization
    void Start () {
		logout.onClick.AddListener(logOut);
        currUser.text = "Hi, "+ persistent_data_script.control.currUser;
        profilePage.onClick.AddListener(openProfilePage);
        users[0].levelCompletionTime = new float[12] { 11, 13, 15, 10, 12, 25, 0, 0, 0, 0, 0, 0};
        users[0].completionPercent = 50;

		for (int i=0; i<12; i++)
        {
			levelButtons[i].onClick.AddListener(openLevelGame);
		}
		for (int i=0; i<12; i++)
        {
			peerLevelButtons[i].onClick.AddListener(openLevelGame);
		}
        //users[1].levelCompletionTime =  = new float[12] { };
        //users[2].levelCompletionTime =  = new float[12] { };

        /*float userAverageTime = 0;
        int userCount = 0;
        for (int i=0; i < 12; i++)
        {

            if (users[0].levelCompletionTime[i] > 0)
            {
                userCount++;
                userAverageTime += users[0].levelCompletionTime[i];
            }

        }
        if (userCount > 0)
        {
            userAverageTime = (float)userAverageTime / userCount;
        }

        float peerAverageTime = 0;
        int peerCount = 0;
        for (int i = 0; i < 12; i++)
        {

            if (averageCompletionTime[i] > 0)
            {
                peerCount++;
                peerAverageTime += averageCompletionTime[i];
            }
        }
        if (peerCount > 0)
        {
            peerAverageTime = (float)peerAverageTime / peerCount;
        }*/

        for (int i=0; i<12; i++)
        {
            ColorBlock btnColor = new ColorBlock();
            if (users[0].levelCompletionTime[i] == 0) {
                btnColor.normalColor = r;
                btnColor.highlightedColor = r;
                btnColor.pressedColor = r;
                btnColor.colorMultiplier = 1;
            } else
            {
                btnColor.normalColor = g;
                btnColor.highlightedColor = g;
                btnColor.pressedColor = g;
                btnColor.colorMultiplier = 0.5f + (float)(averageCompletionTime[i] - users[0].levelCompletionTime[i]) / 100;
            }
            //Debug.Log(btnColor.colorMultiplier);
            levelButtons[i].colors = btnColor;
        }

        for (int i = 0; i < 12; i++)
        {
            ColorBlock btnColor = new ColorBlock();
            if (studentsCompletionPercent[i] == 0)
            {
                btnColor.normalColor = r;
                btnColor.highlightedColor = r;
                btnColor.pressedColor = r;
                btnColor.colorMultiplier = 1;
            }
            else
            {
                btnColor.normalColor = all;
                btnColor.highlightedColor = all;
                btnColor.pressedColor = all;
                btnColor.colorMultiplier = (float)studentsCompletionPercent[i]/100;
            }
            //Debug.Log(btnColor.colorMultiplier);
            peerLevelButtons[i].colors = btnColor;
        }
    }

	// Update is called once per frame
	void Update () {

	}

	void DrawQuad(Rect position, Color color)
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, color);
        texture.Apply();
        GUI.skin.box.normal.background = texture;
        GUI.Box(position, GUIContent.none);
    }

    void OnGUI()
    {
        DrawQuad(new Rect(175, 225, 450, 75), g);
        DrawQuad(new Rect(625, 225, 450, 75), r);
        DrawQuad(new Rect(1575, 225, 600, 75), g);
        DrawQuad(new Rect(2175, 225, 300, 75), r);
        //EditorGUI.ProgressBar(new Rect(175, 225, 900, 75), (float)users[0].completionPercent/100, "");
        //EditorGUI.ProgressBar(new Rect(1575, 225, 900,  75), (float)0.67, "");
    }
}
