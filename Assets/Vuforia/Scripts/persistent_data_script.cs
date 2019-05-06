using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class persistent_data_script : MonoBehaviour {

    public static persistent_data_script control;
    public string currUser;
    void Awake()
    {
        DontDestroyOnLoad(this);
        control = this;
    }
}
