using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryUIManagerLevel2 : MonoBehaviour
{
    [SerializeField]
    private ExitLevelScript player3D;

    [SerializeField]
    private GameObject victoryUI;

    // Update is called once per frame
    void Update()
    {
        if (!victoryUI.activeInHierarchy)
        {
            if (player3D.inside)
            {
                victoryUI.SetActive(true);
            }
        }


    }
}
