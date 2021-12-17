using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoved : MonoBehaviour, ILeftRight
{
    private bool isRight = false;
    private float leftSpeed = 2f;
    private float rightSpeed = 3f;
    private Vector3 originalPos;

    private void Awake()
    {
        originalPos = transform.position;
    }

    public void MoveObjectRight()
    {
        float step = rightSpeed * Time.deltaTime;
        Vector3 newPos = new Vector3(-9f, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, newPos, step);
    }

    public void MoveObjectLeft()
    {
        float step = leftSpeed * Time.deltaTime;
        Vector3 newPos = new Vector3(-15f, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, newPos, step);
    }

    public void ToggleLeftRight()
    {
        isRight = !isRight;
        if(isRight)
        {
            MoveObjectRight();
        }
        else
        {
            MoveObjectLeft();
        }
    }
}
