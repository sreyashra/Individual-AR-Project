using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motherboard : MonoBehaviour
{
    //Child Object References
    [SerializeField] private GameObject cpu;
    [SerializeField] private GameObject ssd;
    [SerializeField] private GameObject ram1;
    [SerializeField] private GameObject ram2;
    [SerializeField] private GameObject ram3;
    [SerializeField] private GameObject ram4;
    [SerializeField] private GameObject portConnectors;
    [SerializeField] private GameObject deleteTxt;

    private void Awake()
    {
        deleteTxt = GameObject.FindGameObjectWithTag("ScanTxt");
        Destroy(deleteTxt);
        deleteTxt = null;
    }

    private void Update()
    {
        //CPU Behavior
        if (InputManager.CpuActive == false)
        {
            cpu.SetActive(false);
        }
        else if (InputManager.CpuActive == true)
        {
            cpu.SetActive(true);
        }

        //SSD Behavior
        if (InputManager.SsdActive == false)
        {
            ssd.SetActive(false);
        }
        else if (InputManager.SsdActive == true)
        {
            ssd.SetActive(true);
        }

        //RAM Behavior
        if (InputManager.RamActive == true)
        {
            ram1.SetActive(true);
            ram2.SetActive(true);
            ram3.SetActive(true);
            ram4.SetActive(true);
        }
        else if (InputManager.RamActive == false)
        {
            ram1.SetActive(false);
            ram2.SetActive(false);
            ram3.SetActive(false);
            ram4.SetActive(false);
        }
        
        //Ports Behavior
        if (InputManager.PortsActive == true)
        {
            portConnectors.SetActive(true);
        }
        else if (InputManager.PortsActive == false)
        {
            portConnectors.SetActive(false);
        }
    }
}
