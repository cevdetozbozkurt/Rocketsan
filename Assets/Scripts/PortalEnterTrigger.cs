using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEnterTrigger : MonoBehaviour
{
    [SerializeField] GameObject EnterPortal;
    
    void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Rocket"))
        {
            Invoke("asd",1f);
        }
    }

    void asd()
    {
        EnterPortal.SetActive(false);
    }
    
}
