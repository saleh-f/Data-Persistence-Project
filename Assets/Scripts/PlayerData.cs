using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;


public  class PlayerData:MonoBehaviour
{
    public string name;
    public int hightScore=0;
    public static PlayerData instance;
    public static PlayerData oldData=new PlayerData();// with this static object we would be able to save the old data to its varabales 
    public void Awake()
    {
        if(instance == null)
        {
            load();
            instance = this;
        DontDestroyOnLoad(gameObject);
        }

        else
        {
        Destroy(gameObject);
            return;
        }
    }
    [Serializable]
    public class data
    {
       public string name;
       public int hightScore;
    }
    public void save()
    {
        data temp =new data();
        temp.name=name;
        temp.hightScore=hightScore;
        string json = JsonUtility.ToJson(temp);
        File.WriteAllText( "Assets/savefile.json", json);
    }
    public void load() {
        string path = "Assets/savefile.json";
        if(File.Exists(path)) {
            string json = File.ReadAllText(path);
            data temp =JsonUtility.FromJson<data>(json);
            oldData.name = temp.name;
            oldData.hightScore = temp.hightScore;
        }
        
    }

}
