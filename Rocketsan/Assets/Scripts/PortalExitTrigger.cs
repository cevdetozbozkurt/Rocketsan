using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalExitTrigger : MonoBehaviour
{
    [SerializeField] GameObject _ExitPortal;
    
    void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Rocket"))
        {
            _ExitPortal.gameObject.SetActive(true);
        }
    }
}
