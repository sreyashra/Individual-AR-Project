using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    //Static Variables
    public static bool CpuActive = false;
    public static bool SsdActive = false;
    public static bool RamActive = false;
    public static bool PortsActive = false;
    private bool techSpecActive = false;
    
    //UI References
    [SerializeField] private GameObject cpuUI;
    [SerializeField] private GameObject ssdUI;
    [SerializeField] private GameObject ramUI;
    [SerializeField] private GameObject techSpecUI;

    private void Update()
    {
        //Touch Input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            if (Physics.Raycast(ray, out hit))
            {
                //CPU Behavior
                if (hit.collider.gameObject.CompareTag("CPU Collider") && !CpuActive)
                {
                    if (touch.phase == TouchPhase.Ended)
                    {
                        CpuActive = true;
                        cpuUI.SetActive(true);
                    }
                }
                else if (hit.collider.gameObject.CompareTag("CPU Collider") && CpuActive)
                {
                    if (touch.phase == TouchPhase.Ended)
                    {
                        CpuActive = false;
                        cpuUI.SetActive(false); 
                    }
                }
                
                //SSD Behavior
                if (hit.collider.gameObject.CompareTag("SSD Collider") && !SsdActive)
                {
                    if (touch.phase == TouchPhase.Ended)
                    {
                        SsdActive = true;
                        ssdUI.SetActive(true);
                    }
                    
                }
                else if (hit.collider.gameObject.CompareTag("SSD Collider") && SsdActive)
                {
                    if (touch.phase == TouchPhase.Ended)
                    {
                        SsdActive = false;
                        ssdUI.SetActive(false);
                    }
                    
                }
                
                //RAM Behavior
                if (hit.collider.gameObject.CompareTag("RAM Collider") && !RamActive)
                {
                    if (touch.phase == TouchPhase.Ended)
                    {
                        RamActive = true;
                        ramUI.SetActive(true);
                    }
                    
                }
                else if (hit.collider.gameObject.CompareTag("RAM Collider") && RamActive)
                {
                    if (touch.phase == TouchPhase.Ended)
                    {
                        RamActive = false;
                        ramUI.SetActive(false);
                    }
                    
                }
                
                //Other Ports explanation
                if (hit.collider.gameObject.CompareTag("MotherBoard Socket Collider") && !PortsActive)
                {
                    if (touch.phase == TouchPhase.Ended)
                    {
                        PortsActive = true;
                    }
                    
                }
                else if (hit.collider.gameObject.CompareTag("MotherBoard Socket Collider") && PortsActive)
                {
                    if (touch.phase == TouchPhase.Ended)
                    {
                        PortsActive = false;
                    }
                    
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.A) && !CpuActive)
        {
            CpuActive = true;
            cpuUI.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.A) && CpuActive)
        {
            CpuActive = false;
            cpuUI.SetActive(false);
        }
    }

    //Tech Specs UI Button
    public void TechSpecUI()
    {
        if (techSpecActive == false)
        {
            techSpecUI.SetActive(true);
            techSpecActive = true;
        }
        else if (techSpecActive == true)
        {
            techSpecUI.SetActive(false);
            techSpecActive = false;
        }
    }
    
    //Scene Transition

    public void SceneTransition(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ApplicationQuit()
    {
        Application.Quit();
    }
}
