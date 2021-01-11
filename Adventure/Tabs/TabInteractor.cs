using UnityEngine;
using UnityEngine.UI;
using DebugUtilityVR;
public class TabInteractor : MonoBehaviour
{
    private bool m_isPressed;
    private string m_name;
    

    private void Awake()
    {
        m_name = gameObject.name;
        m_isPressed = false;
    }

   /* private void Update() // for debug ONLY!!!
    {
        if (Input.GetKey(KeyCode.S) && m_name == "ExitCrossIcon") { OnClickTab(); }
    }*/
    public void OnClickTab()
    {
        m_isPressed = true;
        Debug.Log("Setting Booleans " + this.name);
       // VRDebug.InGameLog("OnClickTabActive");
    }

    public bool GetIsPressed() 
    {
        return m_isPressed;
    }
  

    public void SetIsPressed(bool b) 
    {
        m_isPressed = b;
    }

    public string GetName() 
    {
        return m_name;
    }
}
