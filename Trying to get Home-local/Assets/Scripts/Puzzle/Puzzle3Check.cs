using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3Check : MonoBehaviour
{
    [SerializeField]
    private GameObject endWall;

    [SerializeField]
    private GameObject passedFood;

    [SerializeField]
    private GameObject swingSet;

    private BoxCollider swingCollider;
    private Animator swingAnim;
    private BoxCollider boxCollider;

    private bool completed = false;


    private void Awake()
    {
        swingCollider = swingSet.GetComponent<BoxCollider>();
        swingAnim = swingSet.GetComponent<Animator>();
        boxCollider = endWall.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if(!completed)
        {
            
            if(!passedFood.activeInHierarchy)
            {
                //Debug.Log("Wall should be gone");
                boxCollider.enabled = false;
                completed = true;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            swingAnim.enabled = false;
            swingCollider.enabled = false;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<Rigidbody>() != null)
        {
           
            swingAnim.enabled = false;
            swingCollider.enabled = false;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            
            swingAnim.enabled = true;
            swingCollider.enabled = true;
        }
    }
}
