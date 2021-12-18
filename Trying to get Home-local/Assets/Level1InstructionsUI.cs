using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1InstructionsUI : MonoBehaviour
{
    [SerializeField]
    private GameObject instructions1;

    [SerializeField]
    private GameObject instructions2;

    private float timer;

    

    // Start is called before the first frame update
    private void Start()
    {
        instructions1.SetActive(true);
        timer = Time.time;
    }

    private void Update()
    {
        
        float t = Time.time - timer;

        float seconds = t % 60;

        if(seconds >= 10f && seconds < 20f)
        {
            instructions1.SetActive(false);
            instructions2.SetActive(true);
        }
        else if(seconds >= 20f)
        {
            instructions2.SetActive(false);
            gameObject.SetActive(false);
        }
        
    }


}
