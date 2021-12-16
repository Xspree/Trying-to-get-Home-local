using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collect2DFood : MonoBehaviour
{
    
    public Text junkFoodCounter;

    
    private int junk = 0;

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
                //Debug.Log("2D Food Collected");
                junk++;
            }
            
            UpdateGUI();
        }
    }

    private void UpdateGUI()
    {
        
        junkFoodCounter.text = junk.ToString();
    }
}
