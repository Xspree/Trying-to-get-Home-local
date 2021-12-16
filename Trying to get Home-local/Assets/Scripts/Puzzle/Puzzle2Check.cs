using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2Check : MonoBehaviour
{
    [SerializeField]
    private GameObject Spinny1;
    [SerializeField]
    private GameObject Spinny2;
    [SerializeField]
    private GameObject Spinny3;
    [SerializeField]
    private GameObject Object;
    [SerializeField]
    private GameObject wallToDestroy;

    private Vector3 spinRotation = new Vector3(90, 0f, 0f);

    private Vector3 spinRotationCorrect1 = new Vector3(0f, 180f, 180f);
    private Vector3 spinRotationCorrect2 = new Vector3(90, 0f, 0f);
    private Vector3 spinRotationCorrect3 = new Vector3(0f, 0f, 0f);

    public bool completed = false;

    

    private void Update()
    {
        if(!completed)
        {
            
            if (Spinny1.transform.localEulerAngles == spinRotationCorrect1 && Spinny2.transform.localEulerAngles == spinRotationCorrect2 && Spinny3.transform.localEulerAngles == spinRotationCorrect3)
            {
                wallToDestroy.SetActive(false);
                completed = true;
                Object.SetActive(true);
            }

            
        }
        
    }

    // Update is called once per frame
    public void OnClickRotateSpinny1()
    {
        Spinny1.transform.Rotate(spinRotation);
    }

    public void OnClickRotateSpinny2()
    {
        Spinny2.transform.Rotate(spinRotation);
    }

    public void OnClickRotateSpinny3()
    {
        Spinny3.transform.Rotate(spinRotation);
    }

 
}
