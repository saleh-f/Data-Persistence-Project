using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_InputField NameInput;
    public TMP_Text TopPlayer;

    public void Start()
    {
        
        TopPlayer.text=$"Top Player: {PlayerData.oldData.name} Score: {PlayerData.oldData.hightScore}";
    }




    public void setName(string n)
    {
        PlayerData.instance.name = n;
    }
    public void StartBtn()
    {
        SceneManager.LoadScene(1);
        setName(NameInput.text);
    }
 
    public void Exit()
    {
        if(PlayerData.oldData.hightScore<PlayerData.instance.hightScore)// checks if the the new score is higher than the old one to decide to save it or not
        PlayerData.instance.save();

        if (EditorApplication.isPlaying)
        {
            EditorApplication.ExitPlaymode();
        }
        else
            Application.Quit();
    }
}
