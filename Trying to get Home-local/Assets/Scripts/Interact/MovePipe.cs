using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField]
    private GameObject givenObject;

    [SerializeField]
    private GameObject givenFood;


    private ILeftRight iLeftRight;

    private bool standing = false;

    private void Awake()
    {
        iLeftRight = givenObject.GetComponent<ILeftRight>();
    }

    private void Update()
    {
        if(!standing)
        {
            iLeftRight.MoveObjectLeft();
        }
        else
        {
            iLeftRight.MoveObjectRight();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Rigidbody>() != null && other.gameObject == givenFood)
        {
            standing = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<Rigidbody>() != null && other.gameObject == givenFood)
        {
            standing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        standing = false;
    }

}
