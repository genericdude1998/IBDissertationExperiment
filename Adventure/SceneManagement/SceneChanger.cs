using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneChanger : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(ChangeScene);
       
    }


    private void ChangeScene() 
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadSceneAsync(1);
        }

        if (SceneManager.GetActiveScene().buildIndex == 1) 
        {
            SceneManager.LoadSceneAsync(2);
            
        }

        if (gameObject.name == "Quit Application") 
        {
            Application.Quit();
        }
    }

}
