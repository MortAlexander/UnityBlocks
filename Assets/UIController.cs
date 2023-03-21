#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text nameText;
    public Text BestScoreText;
    private void Start()
    {
        if (DataContainer.Instance.Name!="")
        {
            ChangeName(DataContainer.Instance.Name);
        }
        else
        {
            ChangeName("Player");
        }
        DataContainer dataContainer = DataContainer.Instance;
        BestScoreText.text ="Best Score :"+ dataContainer.OldName +" : " +dataContainer.Score ;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        DataContainer.Instance.SaveName(); 
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void ChangeName(string s)
    {
        DataContainer.Instance.Name = s;
        nameText.text = s;
    }
}


