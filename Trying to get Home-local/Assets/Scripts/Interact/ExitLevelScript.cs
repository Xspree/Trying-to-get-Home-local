using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevelScript : MonoBehaviour
{
    

    

    public bool inside = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>() != null || other.GetComponent<Player2Controller>() != null)
        {
            inside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inside = false;
    }




}
