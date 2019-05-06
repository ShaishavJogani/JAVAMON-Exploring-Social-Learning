using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    public RoundData[] allRoundData;


    // Use this for initialization
    void Start ()
    {

    }

    public RoundData GetCurrentRoundData()
    {
        return allRoundData [0];
    }

    public void quizStart() {
        DontDestroyOnLoad (gameObject);
        SceneManager.LoadScene ("QuizPage");
    }

    public void backToDashboard() {
        SceneManager.LoadScene ("Dashboard_new");
    }

    // Update is called once per frame
    void Update () {

    }
}
