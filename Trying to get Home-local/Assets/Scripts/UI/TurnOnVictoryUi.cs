using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnVictoryUi : MonoBehaviour
{
    [SerializeField]
    private ExitLevelScript player3D;

    [SerializeField]
    private ExitLevelScript player2D;

    [SerializeField]
    private GameObject victoryUI;

    // Update is called once per frame
    void Update()
    {
        if(!victoryUI.activeInHierarchy)
        {
            if (player3D.inside && player2D.inside)
            {
                victoryUI.SetActive(true);
            }
        }
        
        
    }
}
