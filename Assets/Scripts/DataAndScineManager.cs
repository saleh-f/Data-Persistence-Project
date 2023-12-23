using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataAndScineManager : MonoBehaviour
{
    public InputField nameInput;
    public static DataAndScineManager Instance;
    private void Awake()
    {

        string name=this.nameInput.text;
        Debug.Log(name);
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable]
      class data
    {
        public string name;
        public int HightScore;
    }







}
