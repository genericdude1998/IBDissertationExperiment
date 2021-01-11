using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRSimpleInteractable))]
[RequireComponent(typeof(BoxCollider))]

public class Furniture : MonoBehaviour
{
    public Material m_sharedMaterial;

    private FurnitureWindow m_furnitureWindow;

    private XRSimpleInteractable m_simpleInteractable;


    public string nameENG;
    public string descriptionENG;
    public string nameCH;
    public string descriptionCH;
    public Texture picture;

    public Color m_color1;// add real material for Object
    public Color m_color2;// add real material for Object
    public Color m_color3;// add real material for Object

    public Color displayMat1; //  add display material for UI
    public Color displayMat2; //  add display material for UI
    public Color displayMat3; //  add display material for UI*/

    public bool isAvailableInDifferentColors = true;
    public bool isEnglish = true;


    private void Awake()
    {
        FurnitureInit();
    }


    private void FurnitureInit() 
    {
        if (this.GetComponent<MeshRenderer>() != null)
        {
            m_sharedMaterial = this.GetComponent<MeshRenderer>().sharedMaterial;
        }

        else {Debug.Log("Missing Renderer"); }




        m_furnitureWindow = GetComponentInChildren<FurnitureWindow>();        
        m_simpleInteractable = gameObject.GetComponent<XRSimpleInteractable>();

        gameObject.GetComponent<Rigidbody>().useGravity = false;

          
        m_simpleInteractable.onHoverEnter.AddListener(m_furnitureWindow.OnHoverPlusSignEnter);
        m_simpleInteractable.onHoverExit.AddListener(m_furnitureWindow.OnHoverPlusSignExit);
        m_simpleInteractable.onSelectEnter.AddListener(m_furnitureWindow.OnClickPlusSign);

        gameObject.layer = 12;

    }


    public string GetName() 
    {
        if (isEnglish) { return nameENG; }
        else { return nameCH; }
    }
    public string GetDescription()
    {
        if (isEnglish) { return descriptionENG; }
        else { return descriptionCH; }
    }
    public Texture GetTexture() { return picture; }
    public Color GetDisplayColor1() { return displayMat1; }
    public Color GetDisplayColor2() { return displayMat2; }
    public Color GetDisplayColor3() { return displayMat3; }


    public void SetColor1() 
    {
        m_sharedMaterial.color = m_color1;
      //  DebugUtilityVR.VRDebug.InGameLog("Setting Color 1");
    }

    public void SetColor2()
    {
        m_sharedMaterial.color = m_color2;
      //  DebugUtilityVR.VRDebug.InGameLog("Setting Color 2");


    }
    public void SetColor3()
    {
        m_sharedMaterial.color = m_color3;
       // DebugUtilityVR.VRDebug.InGameLog("Setting Color 3");
    }

    

}
