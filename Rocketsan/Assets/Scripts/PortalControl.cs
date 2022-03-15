using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControl : MonoBehaviour
{

    ParticleSystem PortalEnter;
    ParticleSystem PortalExit;

    void Start()
    {
        PortalEnter = GameObject.FindGameObjectWithTag("Portal Enter").GetComponent<ParticleSystem>();    
    }

    void Update() 
    {
        
    }

    void EnterPortal()
    {

    }

}
