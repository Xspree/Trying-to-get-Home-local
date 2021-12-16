using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect3DFood : MonoBehaviour
{
    public Text healthyFoodCounter;
    

    private int healthy = 0;
    

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
            
            if(collectible is Collectible3DFood)
            {
                //Debug.Log("3D Food Collected");
                healthy++;
            }
            UpdateGUI();
        }
    }

    private void UpdateGUI()
    {
        healthyFoodCounter.text = healthy.ToString();
        
    }
}
