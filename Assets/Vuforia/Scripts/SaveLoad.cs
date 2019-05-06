using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
 
public static class SaveLoad
{

    public static Dictionary<string,string> users = new Dictionary<string, string>();

    public static void Save(string username, string password)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = null;
        //Debug.Log(Application.persistentDataPath + "/registration.txt");
        if (File.Exists(Application.persistentDataPath + "/registration.txt"))
        {
            SaveLoad.Load();
            SaveLoad.users.Add(username, password);
            //Debug.Log("Opening exisiting file");
            file = File.Open(Application.persistentDataPath + "/registration.txt", FileMode.Create);
            bf.Serialize(file, SaveLoad.users);
        }
        else
        {
            SaveLoad.users.Add(username, password);
            //Debug.Log("Creating new file");
            file = File.Create(Application.persistentDataPath + "/registration.txt");
            bf.Serialize(file, SaveLoad.users);
        }  
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/registration.txt"))
        {
            //Debug.Log("Loading file data");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/registration.txt", FileMode.Open);
            SaveLoad.users = (Dictionary<string,string>)bf.Deserialize(file);
            file.Close();
        }
    }
    public static bool validate(string username, string password)
    {
        //validate a registered user for login
        SaveLoad.Load();
        foreach (KeyValuePair<string, string> entry in SaveLoad.users)
        {
            //Debug.Log(entry.Key+":"+entry.Value);
            if (entry.Key.Equals(username) && entry.Value.Equals(password))
                return true;
        }
        return false;
    }
}