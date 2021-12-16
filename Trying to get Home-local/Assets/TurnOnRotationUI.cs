using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnRotationUI : MonoBehaviour
{
    [SerializeField]
    private GameObject rotationUI;
    
    public Puzzle2Check puzzle2Check;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(!puzzle2Check.completed)
        {
            if (other.GetComponent<Rigidbody>() != null)
            {
                rotationUI.SetActive(true);
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        rotationUI.SetActive(false);
    }
}
