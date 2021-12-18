using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOnVictoryUi : MonoBehaviour
{
    [SerializeField]
    private ExitLevelScript player3D;

    [SerializeField]
    private ExitLevelScript player2D;

    [SerializeField]
    private GameObject victoryUI;

    [SerializeField]
    private Text timerText;

    private float startTimer;
    private bool finished = false;

    private void Start()
    {
        startTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!victoryUI.activeInHierarchy)
        {
            if (player3D.inside && player2D.inside)
            {
                finished = true;
                victoryUI.SetActive(true);
            }
            else
            {
                if(!finished)
                {
                    float t = Time.time - startTimer;

                    string minutes = ((int)t / 60).ToString();
                    string seconds = (t % 60).ToString("f0");

                    timerText.text = minutes + " : " + seconds;
                }
                
            }
        }
        
        
    }
}
