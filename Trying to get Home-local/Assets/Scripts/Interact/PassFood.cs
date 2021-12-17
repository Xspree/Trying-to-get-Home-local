using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassFood : MonoBehaviour
{
    [SerializeField]
    private GameObject objectBeingPassed;
    [SerializeField]
    private GameObject givenObject;
    public bool wasPassed = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collectible") && other.GetComponent<Rigidbody>() && other.gameObject == givenObject)
        {
            givenObject = other.gameObject;
            givenObject.SetActive(false);

            wasPassed = true;

            objectBeingPassed.SetActive(true);
        }
    }

    
}
