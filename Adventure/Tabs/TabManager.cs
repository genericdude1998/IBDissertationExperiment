using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    /*private TabInteractor infoTab;
    private TabInteractor colorTab;
    private TabInteractor settingsTab;
    private TabInteractor exitCross;

    private TabInteractor color1Tab;
    private TabInteractor color2Tab;
    private TabInteractor color3Tab;*/


    private TabInteractor[] tabsArr;
    private TabInteractor m_currentTab;

    private FurnitureWindow m_window;

    private void Awake()
    {
        //get tab interactor references
        tabsArr = GetComponentsInChildren<TabInteractor>();

       /* color1Tab = tabsArr[0];
        color2Tab = tabsArr[1];
        color3Tab = tabsArr[2];

        infoTab = tabsArr[3];
        colorTab = tabsArr[4];
        settingsTab = tabsArr[5];
        exitCross = tabsArr[6];*/ // remove maybe???


        m_window = gameObject.GetComponent<FurnitureWindow>();

      //  foreach (TabInteractor tab in tabsArr) { Debug.Log(tab.name); }
    }

    /*private void Update() // FOR DEBUG ONLY!!!!
    {
        if (Input.GetKey(KeyCode.S)) { OnClickManager(); }

    }*/
public void OnClickManager() 
    {
       // DebugUtilityVR.VRDebug.InGameLog("OnClickManagerActive");
         foreach (TabInteractor tab in tabsArr) 
         {
            if (tab.GetIsPressed() == true) 
            {
                m_currentTab = tab;
                //  Debug.Log(m_currentTab);
                // Debug.Log(tab.GetIsPressed());
                m_window.ActivateTab(m_currentTab);
                //reset currentTab
                m_currentTab.SetIsPressed(false);
                m_currentTab = null;
            } 
         }
    }

}
