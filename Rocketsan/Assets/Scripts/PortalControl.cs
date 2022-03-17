using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControl : MonoBehaviour
{

    ParticleSystem PortalEnter;
    ParticleSystem PortalExit;
    [SerializeField] GameObject rocket;
    
    Vector3 PortalEnterTransform;
    Vector3 PortalExitTransform;
    Vector3 RocketTransform;

    void Start()
    {
        PortalEnter = GameObject.FindGameObjectWithTag("Portal Enter").GetComponent<ParticleSystem>();
        PortalExit = GameObject.FindGameObjectWithTag("Portal Exit").GetComponent<ParticleSystem>();
        PortalEnterTransform = PortalEnter.transform.position;
        PortalExitTransform = PortalExit.transform.position;
        Debug.Log("Rocket Transform = " + RocketTransform);
        Debug.Log("Portal Enter Transform ="+PortalEnterTransform);
        Debug.Log("Portal Exit Transform = "+PortalExitTransform);
    }

    void Update() 
    {
        
        RocketTransform = rocket.transform.position;
        Debug.Log("New Rocket Transform"+RocketTransform);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Portal Enter"){
            RocketTransform = PortalExitTransform;
            Debug.Log("After tp rocket transform = "+RocketTransform);
        }
    }
    void EnterPortal()
    {
        if(RocketTransform == PortalEnterTransform)
        {
            RocketTransform = PortalExitTransform;
        }
    }

}
