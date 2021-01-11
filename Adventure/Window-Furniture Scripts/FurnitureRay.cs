using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/*public class FurnitureRay : MonoBehaviour
{
    private GameObject m_UIray;
    public XRRayInteractor m_furnitureRay;
    private float m_deactivationDistance;
    private float m_activationDistance;

    

    // Start is called before the first frame update
    private void Start()
    {
        m_UIray = gameObject;
        m_deactivationDistance = 0.0f; // is this the best solution???
        m_activationDistance = 30;

    }

    private void Update()
    {

        Vector3 pos = new Vector3();
        Vector3 norm = new Vector3();

        int index = 0;
        bool validTarget = false;

        bool isHovering = m_UIray.GetComponent<XRRayInteractor>().TryGetHitInfo(ref pos, ref norm, ref index, ref validTarget);

        if (isHovering)
        {
            DeactivateFurnitureRay();
        }

        else 
        { 
            ActivateFurnitureRay(); 
        }

        
    }


    public void ActivateFurnitureRay() 
    {
        //  m_ray.SetActive(true);
        m_furnitureRay.GetComponent<XRRayInteractor>().maxRaycastDistance = m_activationDistance;
        m_furnitureRay.GetComponent<LineRenderer>().enabled = true;
        m_furnitureRay.GetComponent<XRInteractorLineVisual>().enabled = true;

        DebugUtilityVR.VRDebug.InGameLog("activated furniture ray ");
    }

    public void DeactivateFurnitureRay()
    {
       //m_ray.SetActive(false);
        m_furnitureRay.GetComponent<XRRayInteractor>().maxRaycastDistance = m_deactivationDistance;
        m_furnitureRay.GetComponent<LineRenderer>().enabled = false;
        m_furnitureRay.GetComponent<XRInteractorLineVisual>().enabled = false;

        DebugUtilityVR.VRDebug.InGameLog( "deactivated furniture ray ");

    }*/




