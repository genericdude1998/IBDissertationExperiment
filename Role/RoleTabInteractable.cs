using UnityEngine.UI;
using UnityEngine;

public class RoleTabInteractable : MonoBehaviour
{
    private bool m_isPressed;
    private string m_name;
    private Text text;
    private Button m_button;
    public RoleMenu mainMenu;
    private Canvas originCanvas;
    public Canvas targetCanvas;
    public bool m_isASpecificProduct;
    public bool m_isAMenuButton;
    public bool m_isASmallProduct;
    public GameObject prefab;
   


    private void Awake()
    {
        m_name = gameObject.name;
        m_isPressed = false;
        text = GetComponentInChildren<Text>();
        text.text = this.name;
        mainMenu = GetComponentInParent<RoleMenu>();
        m_button = GetComponent<Button>();

        if (!m_isAMenuButton) 
        {
            originCanvas = GetComponentInParent<Canvas>();
        }
        
        m_button.onClick.AddListener(OnClickTab);
        m_button.onClick.AddListener(mainMenu.OnClickMenuManager);

    }


    public void OnClickTab()
    {
        m_isPressed = true;
        //Debug.Log("Setting Booleans " + this.name);
        // VRDebug.InGameLog("OnClickTabActive");
        mainMenu.m_currentTab = this;
        if (targetCanvas != null)
        {
            targetCanvas.enabled = true;
        }
        if (!m_isASpecificProduct && originCanvas != null)
        {
            originCanvas.enabled = false;
        }

        else if(!m_isAMenuButton)
        {
            if (mainMenu.currentPrefab != null) { Destroy(mainMenu.currentPrefab); }

            if (m_isASmallProduct)
            {
                mainMenu.currentPrefab = Instantiate(prefab, mainMenu.prefabPosSmall.position, Quaternion.Euler(180 * Vector3.up)); Debug.Log("Instanciating Small Object");
            }

            else 
            { 
                mainMenu.currentPrefab = Instantiate(prefab, mainMenu.prefabPos.position, Quaternion.Euler(180 * Vector3.up)); Debug.Log("Instanciating Small Object");

            }

        }

        if (m_isAMenuButton) { mainMenu.m_currentTab = this; }
    }


    // optional

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
