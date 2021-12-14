using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public PlayerController playerController;
    public Player2Controller player2Controller;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform player2;

    private GameObject[] respawnPoints;

    private void Awake()
    {
        respawnPoints = GameObject.FindGameObjectsWithTag("respawnPoints");
    }
    private void OnTriggerEnter(Collider other)
    {
        
        GameObject closestRespawn = respawnPoints[0];
        float closestDistance = Vector3.Distance(closestRespawn.transform.position, player.transform.position);

        foreach(GameObject points in respawnPoints)
        {

            if(Vector3.Distance(points.transform.position, player.transform.position) < closestDistance)
            {
                closestRespawn = points;
            }
            
        }

        if(!playerController.is3DGrounded)
        {
            player.transform.position = closestRespawn.transform.position;
        }

        if (!player2Controller.is2DGrounded)
        {
            player2.transform.position = closestRespawn.transform.position;
        }

    }
}
