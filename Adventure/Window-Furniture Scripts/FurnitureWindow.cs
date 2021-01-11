using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.UI;
using UnityEngine.XR.Interaction.Toolkit;



public class FurnitureWindow : MonoBehaviour
{
    public float m_resizeCoefficient;
    public float m_maxSize = 100.0f;
    public float m_textResolution = 30.0f;

    
    //base furniture reference
    private Furniture furnitureInstance;

    //elements in the window
    private Canvas m_plusCanvas;
  
    private Canvas m_infoCanvas;
    private Text m_name;
    private Text m_description;
    private RawImage m_productImage;
    private CanvasScaler m_infoCanvasScaler;

    private Canvas m_colorCanvas;
    private Image m_displayMat1;
    private Image m_displayMat2;
    private Image m_displayMat3;
    private CanvasScaler m_noColorCanvasScaler;


    private Canvas m_settingsCanvas;
    private Image m_chineseToggleON;
    private Image m_chineseToggleOFF;
    private Image m_englishToggleON;
    private Image m_englishToggleOFF;
    private CanvasScaler m_settingsCanvasScaler;

    private Canvas m_tabCanvas;
    private Image m_infoTab;
    private Image m_colorTab;
    private Image m_settingsTab;
    private Image m_crossTab;

    private TrackedDeviceGraphicRaycaster m_colorCanvasGraphicRaycaster;
    private TrackedDeviceGraphicRaycaster m_settingsCanvasGraphicRaycaster;
    private TrackedDeviceGraphicRaycaster m_tabCanvasGraphicRaycaster;


    public Color tabColorDefault;
    public Color tabColorPressed;

 


    //Main Camera 

    private Transform camTransform;


    private bool isWindowOpen = false;

   // private CanvasManager canvasManagerSingleton;
    private void Awake()
    {
        //Furniture reference
        furnitureInstance = gameObject.GetComponentInParent<Furniture>();
       // Debug.Log(m_furniture.name);

        //Get UI elements
        GetReferencesUIElements();

        //UI Initialisation
        m_name.text = furnitureInstance.GetName();
        m_description.text = furnitureInstance.GetDescription();
        m_productImage.texture = furnitureInstance.GetTexture();

        if (furnitureInstance.isAvailableInDifferentColors)
        {
            m_displayMat1.color = furnitureInstance.GetDisplayColor1();
            m_displayMat2.color = furnitureInstance.GetDisplayColor2();
            m_displayMat3.color = furnitureInstance.GetDisplayColor3();
        }

        camTransform = Camera.main.transform;

        //canvasManagerSingleton = FindObjectOfType<CanvasManager>(); to close windows automatically when another is pressed for debug
    }

    private void Start()
    {
       
        m_infoCanvasScaler.dynamicPixelsPerUnit = m_textResolution;
        m_settingsCanvasScaler.dynamicPixelsPerUnit = m_textResolution;


    }

    private void Update()
    {
        ResizeUI(m_resizeCoefficient);
        RotateUI();
    }

    private void GetReferencesUIElements()
    {
        // Getting references for all elements of UI
        Canvas[] canvasArr;
        canvasArr = gameObject.GetComponentsInChildren<Canvas>();
        //foreach (Canvas c in canvasArr) { Debug.Log(c.name); }

        m_plusCanvas = canvasArr[0];
        m_infoCanvas = canvasArr[1];

        if (furnitureInstance.isAvailableInDifferentColors)
        { 
            m_colorCanvas = canvasArr[2]; 
        }

        else
        {
            m_colorCanvas = canvasArr[5]; // this is the no color canavas
        }
        
        m_settingsCanvas = canvasArr[3];
        m_tabCanvas = canvasArr[4];

        // foreach (Canvas can in canvasArr) { Debug.Log(can.name); }

        Text[] textArrInfo = m_infoCanvas.GetComponentsInChildren<Text>();
        m_name = textArrInfo[0];
        m_description = textArrInfo[1];

        // foreach (Text text in textArrInfo) { Debug.Log(text.name); }

        m_productImage = m_infoCanvas.GetComponentInChildren<RawImage>();

        //Debug.Log(m_productImage.name);

        if (furnitureInstance.isAvailableInDifferentColors == true)
        {
            Image[] displayMatArr = m_colorCanvas.GetComponentsInChildren<Image>();
            m_displayMat1 = displayMatArr[0];
            m_displayMat2 = displayMatArr[1];
            m_displayMat3 = displayMatArr[2];
        }

        // foreach (Image mat in matArr) { Debug.Log(mat.name); }


        Image[] togglesArr = m_settingsCanvas.GetComponentsInChildren<Image>();

        m_chineseToggleOFF = togglesArr[0];
        m_chineseToggleON = togglesArr[1];
        m_englishToggleOFF = togglesArr[2];
        m_englishToggleON = togglesArr[3];


        // foreach (Image toggle in togglesArr) { Debug.Log(toggle.name); }

        Image[] tabArr = m_tabCanvas.GetComponentsInChildren<Image>();

        m_infoTab = tabArr[0];
        m_colorTab = tabArr[1];
        m_settingsTab = tabArr[2];
        m_crossTab = tabArr[3];

        //  foreach (Image tab in tabArr) { Debug.Log(tab.name); }

        TrackedDeviceGraphicRaycaster[] graphicRaycasterArr = GetComponentsInChildren<TrackedDeviceGraphicRaycaster>();

        foreach (TrackedDeviceGraphicRaycaster graphicRaycast in graphicRaycasterArr) { graphicRaycast.enabled = false; }

        m_colorCanvasGraphicRaycaster = graphicRaycasterArr[0];
        m_settingsCanvasGraphicRaycaster = graphicRaycasterArr[1];
        m_tabCanvasGraphicRaycaster = graphicRaycasterArr[2];

        // foreach (TrackedDeviceGraphicRaycaster raycaster in graphicRaycasterArr) { Debug.Log(raycaster.name); }

        m_infoCanvasScaler = m_infoCanvas.GetComponent<CanvasScaler>();
        m_settingsCanvasScaler = m_settingsCanvas.GetComponent<CanvasScaler>();


        m_infoCanvasScaler.dynamicPixelsPerUnit = m_textResolution;
        m_settingsCanvasScaler.dynamicPixelsPerUnit = m_textResolution;

        if (furnitureInstance.isAvailableInDifferentColors == false) 
        {
            m_noColorCanvasScaler = m_colorCanvas.GetComponent<CanvasScaler>();
            m_noColorCanvasScaler.dynamicPixelsPerUnit = m_textResolution;
        }

        //Debug.Log(m_infoCanvasScaler);
        //Debug.Log(m_settingsCanvasScaler);
    }

    private void ResizeUI(float resizeCoefficient) 
    {
        float dist = Vector3.Distance(camTransform.position, transform.position);
        if (dist / resizeCoefficient <= m_maxSize)
        {
            transform.localScale = new Vector3(dist / resizeCoefficient, dist / resizeCoefficient, dist / resizeCoefficient);
        }
    }
    private void RotateUI() 
    {
        transform.LookAt(camTransform.position);
    }


    public void OnHoverPlusSignEnter(XRBaseInteractor interactor) 
    {
        if (isWindowOpen == false)
        {
            m_plusCanvas.enabled = true;
        }
    }

    public void OnHoverPlusSignExit(XRBaseInteractor interactor)
    {
        if (isWindowOpen == false)
        {
            m_plusCanvas.enabled = false;
        }
    }

    public void OnClickPlusSign(XRBaseInteractor interactor)  // maybe remove ????
    {
        if (isWindowOpen == false)
        {
            OpenPlusTab();
            isWindowOpen = true;
           // CanvasManager.isHoveringOnCanvas = false; for debug
        }
    }

    public void ActivateTab(TabInteractor currentTab) 
    {
        string name = currentTab.GetName();
        switch (name)
        {
            //case "Plus": OpenPlusTab(); break; // maybe remove button?
            case "InfoIcon": OpenInfoPage(); break;
            case "ColorIcon": OpenColorPage(); break;
            case "SettingsIcon": OpenSettingsPage(); break;
            case "ExitCrossIcon": ClosePages(); break;
            case "Color1Tab": furnitureInstance.SetColor1();break;
            case "Color2Tab": furnitureInstance.SetColor2(); break;
            case "Color3Tab": furnitureInstance.SetColor3(); break;
            case "ToggleTabEnglish": ToggleEnglishLanguage(); break;
            case "ToggleTabChinese": ToggleChineseLanguage();break;
        }
    }

    void OpenPlusTab() 
    {

        m_infoCanvasScaler.dynamicPixelsPerUnit = m_textResolution;
        m_infoCanvasScaler.enabled = false;
        m_infoCanvasScaler.enabled = true; // this is not the way to do it!!! 

        // sets enabled info canvas and tab
        m_infoCanvas.enabled = true;

        // sets disable evrythign else

        m_plusCanvas.enabled = false;

        m_colorCanvas.enabled = false;
        m_colorCanvasGraphicRaycaster.enabled = false;
        m_colorTab.color = tabColorDefault;

        m_settingsCanvas.enabled = false;
        m_settingsCanvasGraphicRaycaster.enabled = false;
        m_settingsTab.color = tabColorDefault;
        
        m_tabCanvas.enabled = true;
        m_tabCanvasGraphicRaycaster.enabled = true; // enables graphicRaycaster of tab Canvas
        m_infoTab.color = tabColorPressed;

       
    }

    void OpenInfoPage() // maybe better performance???????
    {
        // sets enabled info canvas and tab
        if (m_infoCanvas.enabled == false)
        {
            m_infoCanvas.enabled = true;
            m_infoTab.color = tabColorPressed;

        
            m_infoCanvasScaler.dynamicPixelsPerUnit = m_textResolution;
            m_infoCanvasScaler.enabled = false;
            m_infoCanvasScaler.enabled = true;

        }


        // sets disable evrythign else
        if (m_colorCanvas.enabled == true)
        {
            m_colorCanvas.enabled = false;
            m_colorCanvasGraphicRaycaster.enabled = false;
            m_colorTab.color = tabColorDefault;
        }

        if (m_settingsCanvas.enabled == true)
        {
            m_settingsCanvas.enabled = false;
            m_settingsCanvasGraphicRaycaster.enabled = false;
            m_settingsTab.color = tabColorDefault;
        }
        
       
    }
    void OpenColorPage() // maybe better performance???????
    {
        if (furnitureInstance.isAvailableInDifferentColors == false) // maybe cleaner?
        {
            DebugUtilityVR.VRDebug.InGameLog("This object does not have colors");

            m_noColorCanvasScaler.dynamicPixelsPerUnit = m_textResolution;
            m_noColorCanvasScaler.enabled = false;
            m_noColorCanvasScaler.enabled = true;
        }

        if (m_colorCanvas.enabled == false)
        {
            m_colorCanvas.enabled = true;
            m_colorCanvasGraphicRaycaster.enabled = true; // enables graphicRaycaster of Color Canvas
            m_colorTab.color = tabColorPressed;
        }
        // sets disable evrythign else
        if (m_infoCanvas.enabled == true)
        {
            m_infoCanvas.enabled = false;
            m_infoTab.color = tabColorDefault;
        }


        if (m_settingsCanvas.enabled == true)
        {
            m_settingsCanvas.enabled = false;
            m_settingsCanvasGraphicRaycaster.enabled = false;
            m_settingsTab.color = tabColorDefault;
        }
        

       
    }
    void OpenSettingsPage() // maybe better performance???????
    {

        if (m_infoCanvas.enabled == true)
        {
            m_infoCanvas.enabled = false;
            m_infoTab.color = tabColorDefault;
        }

   
        if (m_colorCanvas.enabled == true)
        {
            m_colorCanvas.enabled = false;
            m_colorCanvasGraphicRaycaster.enabled = false;
            m_colorTab.color = tabColorDefault;
        }


        if (m_settingsCanvas.enabled == false)
        {
            m_settingsCanvas.enabled = true;
            m_settingsCanvasGraphicRaycaster.enabled = true; // enables raycaster settings
            m_settingsTab.color = tabColorPressed;

            m_settingsCanvasScaler.dynamicPixelsPerUnit = m_textResolution;
            m_settingsCanvasScaler.enabled = false;
            m_settingsCanvasScaler.enabled = true;
        }
       
    }
    void ClosePages() // maybe better performance??????? 
    {
        //DebugUtilityVR.VRDebug.InGameLog("ClosePages");
        // disable evrythign else
        m_tabCanvas.enabled = false;
        m_tabCanvasGraphicRaycaster.enabled = false;

        m_infoCanvas.enabled = false;
        m_infoTab.color = tabColorDefault;

        m_colorCanvas.enabled = false;
        m_colorCanvasGraphicRaycaster.enabled = false;
        m_colorTab.color = tabColorDefault;

        m_settingsCanvas.enabled = false;
        m_settingsCanvasGraphicRaycaster.enabled = false;
        m_settingsTab.color = tabColorDefault;

        m_plusCanvas.enabled = false;

        isWindowOpen = false;

        DebugUtilityVR.VRDebug.InGameLog("Cross pressed");
    }

    void ToggleEnglishLanguage() 
    {
        if (furnitureInstance.isEnglish == false) // add logic to furniture
        {
            furnitureInstance.isEnglish = true;

            m_englishToggleON.enabled = true;
            m_englishToggleOFF.enabled = false;

            m_chineseToggleOFF.enabled = true;
            m_chineseToggleON.enabled = false;

            m_name.text = furnitureInstance.GetName();
            m_description.text = furnitureInstance.GetDescription();

            if (furnitureInstance.isAvailableInDifferentColors == false)
            {
                m_colorCanvas.GetComponentInChildren<Text>().text = CanvasManager.noColorEnglishText;
            }

        }

        //  DebugUtilityVR.VRDebug.InGameLog("Toggle English");

    }

    void ToggleChineseLanguage()
    {
        if (furnitureInstance.isEnglish == true)
        {
            furnitureInstance.isEnglish = false;

            m_englishToggleON.enabled = false;
            m_englishToggleOFF.enabled = true;

            m_chineseToggleOFF.enabled = false;
            m_chineseToggleON.enabled = true;

            m_name.text = furnitureInstance.GetName();
            m_description.text = furnitureInstance.GetDescription();


            if (furnitureInstance.isAvailableInDifferentColors == false)
            {
                m_colorCanvas.GetComponentInChildren<Text>().text = CanvasManager.noColorChineseText;
                //Debug.Log(m_colorCanvas.GetComponentInChildren<Text>().text);
            }
        }
            // DebugUtilityVR.VRDebug.InGameLog("Toggle Chinese");

    }


}
