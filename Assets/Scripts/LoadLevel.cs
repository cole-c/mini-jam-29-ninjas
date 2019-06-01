using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public Button startButton;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        startButton.onClick.AddListener(LoadMainLevel);
    }

    void LoadMainLevel()
    {
        SceneManager.LoadScene(1);
    }
}
