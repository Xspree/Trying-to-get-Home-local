using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockRisen : MonoBehaviour , IObject
{
    // Start is called before the first frame update
    private bool isRisen = false;
    private float downSpeed = 0.1f;
    private float upSpeed = .7f;
    private Vector3 originalPos;

    private void Awake()
    {
        originalPos = transform.position;
    }


    public void RaiseObject()
    {
        float step = upSpeed * Time.deltaTime;
        Vector3 newPos = new Vector3(transform.position.x, -.5f, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, newPos, step);
    }
    public void LowerObject()
    {
        float step = downSpeed * Time.deltaTime;
        Vector3 newPos = new Vector3(transform.position.x, -2.5f, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, newPos, step);
        
    }
    public void ToggleObject()
    {
        isRisen = !isRisen;
        if(isRisen)
        {
            RaiseObject();
        }
        else
        {
            LowerObject();
        }
    }

   
}
