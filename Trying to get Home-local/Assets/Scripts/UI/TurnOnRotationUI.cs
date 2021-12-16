using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnRotationUI : MonoBehaviour
{
    [SerializeField]
    private GameObject rotationUI;

    [SerializeField]
    private GameObject matchHelper;

    public Puzzle2Check puzzle2Check;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<Rigidbody>() != null)
        {
            if(!puzzle2Check.completed)
            {
                matchHelper.SetActive(true);
                rotationUI.SetActive(true);
            }
            
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        matchHelper.SetActive(false);
        rotationUI.SetActive(false);
    }
}
