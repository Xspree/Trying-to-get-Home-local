using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFood : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collectible"))
        {
            Collect(other.GetComponent<Collectible>());
        }
    }

    private void Collect(Collectible collectible)
    {
        if(collectible.Collect())
        {
            if(collectible is Collectible2DFood)
            {
                Debug.Log("2D Food Collected");
            }
            else if(collectible is Collectible3DFood)
            {
                Debug.Log("3D Food Collected");
            }

        }
    }
}
