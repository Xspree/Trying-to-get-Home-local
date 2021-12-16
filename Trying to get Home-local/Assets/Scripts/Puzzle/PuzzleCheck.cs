using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCheck : MonoBehaviour
{
    [SerializeField]
    private GameObject Object;
    [SerializeField]
    private GameObject wallToDestroy;

    private bool wentThrough = false;

    


    private void OnTriggerEnter(Collider other)
    {
        if(!wentThrough)
        {
            if (other.GetComponent<Rigidbody>() != null)
            {
                Object.SetActive(true);
                wallToDestroy.SetActive(false);
                wentThrough = true;
            }
        }
        
    }
}
