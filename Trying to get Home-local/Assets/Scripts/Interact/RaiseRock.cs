using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseRock : MonoBehaviour
{
   
    [SerializeField]

    private GameObject GameObject;

    private IObject Object;
    private bool standing = false;

    private void Awake()
    {
        Object = GameObject.GetComponent<IObject>();
    }

    private void Update()
    {
        if(!standing)
        {
            Object.LowerObject();
        }
        else
        {
            Object.RaiseObject();
        }
        //Debug.Log(standing);
           
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Rigidbody>() != null)
        {
            standing = true;
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<Rigidbody>() != null)
        {
            standing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
      
            standing = false;
        
        
    }


}
