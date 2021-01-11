using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleMenu : MonoBehaviour
{
    private RoleTabInteractable[] roleTabsArr; 
    public RoleTabInteractable m_currentTab;
    public GameObject currentPrefab;
    public Transform prefabPos;
    public Transform prefabPosSmall;
    public ObjectRotator rotator;

    private Canvas[] canvasArr;

    private void Awake()
    {
        roleTabsArr = GetComponentsInChildren<RoleTabInteractable>();
        canvasArr = GetComponentsInChildren<Canvas>();
    }

    public void OnClickMenuManager()
    {
        CheckMenuCommandsRoleTabInteractor(m_currentTab);

        if (currentPrefab != null)
            rotator.currentObjectSpawned = currentPrefab;
        else 
        {
            rotator.currentObjectSpawned = null;
        }
    }

    void CheckMenuCommandsRoleTabInteractor(RoleTabInteractable roleTab)  // only for the menu controls
    {
      

        switch (m_currentTab.name) 
        {
            case "BackTab": OpenBackTab(); break;
            case "ExitTab": OpenExitTab(); break;
            case "DeleteTab": DeletePrefab(); break;
        }
    }

    void OpenBackTab() 
    {
        foreach (Canvas canvas in canvasArr) 
        {
            if (canvas.name == "MainMenuCanvas" || canvas.name == "TabsCanvas" || canvas.name == "Canvas")
            { canvas.enabled = true; }

           else { canvas.enabled = false; }
            
        }
    }
    void OpenExitTab() 
    {
        Application.Quit();
    }
    void DeletePrefab() 
    {
        Destroy(currentPrefab);

    }

}
