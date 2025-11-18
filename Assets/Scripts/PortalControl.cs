using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControl : MonoBehaviour
{

    [SerializeField] GameObject PortalEnter;
    [SerializeField] GameObject PortalExit;
    [SerializeField] GameObject rocket;
    
    Vector3 PortalEnterTransform;
    Vector3 PortalExitTransform;
    Vector3 RocketTransform;

    void Start()
    {
        PortalEnterTransform = PortalEnter.transform.position;
        PortalExitTransform = PortalExit.transform.position;
    }

    void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag == "Portal Enter")
        {
            Enterteleport();
        }
        else if (other.gameObject.tag == "Portal Exit")
        {
            Exitteleport();
        }

        
        // switch(other.gameObject.tag)
        // {
        //     case "Enter Portal":
        //         Exitteleport();
        //         break;
        //     case "Exit Portal":
        //         Enterteleport();
        //         break;
        //     default:
        //         break;
        // }

    }


    void Enterteleport()
    {
        rocket.transform.position = PortalExitTransform;
    }

    void Exitteleport()
    {
        rocket.transform.position = PortalEnterTransform;
    }
}
