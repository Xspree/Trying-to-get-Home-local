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

    private GameObject[] collectibleFoods;

    private void Awake()
    {
        respawnPoints = GameObject.FindGameObjectsWithTag("respawnPoints");
        collectibleFoods = GameObject.FindGameObjectsWithTag("Collectible");
    }
    private void OnTriggerEnter(Collider other)
    {
        
        GameObject closestRespawn = respawnPoints[0];
        float closestDistance = Vector3.Distance(closestRespawn.transform.position, player.transform.position);

        if(respawnPoints.Length > 1)
        {
            foreach (GameObject points in respawnPoints)
            {

                if (Vector3.Distance(points.transform.position, player.transform.position) <= closestDistance)
                {
                    closestRespawn = points;
                }

            }
        }
        

        if(!playerController.is3DGrounded)
        {
            if (playerController.held)
            {
                playerController.DropObject();
            }
            player.transform.position = closestRespawn.transform.position;
            
        }

        if (!player2Controller.is2DGrounded)
        {
            if (player2Controller.held)
            {
                player2Controller.DropObject();
            }
            player2.transform.position = closestRespawn.transform.position;
        }

        if(other.CompareTag("Collectible"))
        {
            foreach(GameObject foodOutOfBounds in collectibleFoods)
            {
                if(foodOutOfBounds == other.gameObject)
                {
                    other.transform.position = closestRespawn.transform.position;
                    break;
                }
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        GameObject closestRespawn = respawnPoints[0];
        float closestDistance = Vector3.Distance(closestRespawn.transform.position, player.transform.position);

        if (respawnPoints.Length > 1)
        {
            foreach (GameObject points in respawnPoints)
            {

                if (Vector3.Distance(points.transform.position, player.transform.position) <= closestDistance)
                {
                    closestRespawn = points;
                }

            }
        }

        if (!playerController.is3DGrounded)
        {
            
            if (playerController.held)
            {
                playerController.DropObject();
            }
            player.transform.position = closestRespawn.transform.position;
        }

        if (!player2Controller.is2DGrounded)
        {
            if (player2Controller.held)
            {
                player2Controller.DropObject();
            }
            player2.transform.position = closestRespawn.transform.position;
        }

        if (other.CompareTag("Collectible"))
        {
            foreach (GameObject foodOutOfBounds in collectibleFoods)
            {
                if (foodOutOfBounds == other.gameObject)
                {
                    other.transform.position = closestRespawn.transform.position;
                    break;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject closestRespawn = respawnPoints[0];
        float closestDistance = Vector3.Distance(closestRespawn.transform.position, player.transform.position);

        if (respawnPoints.Length > 1)
        {
            foreach (GameObject points in respawnPoints)
            {

                if (Vector3.Distance(points.transform.position, player.transform.position) <= closestDistance)
                {
                    closestRespawn = points;
                }

            }
        }

        if (!playerController.is3DGrounded)
        {
            if(playerController.held)
            {
                playerController.DropObject();
            }
            
            player.transform.position = closestRespawn.transform.position;
        }

        if (!player2Controller.is2DGrounded)
        {
            if(player2Controller.held)
            {
                player2Controller.DropObject();
            }
            
            player2.transform.position = closestRespawn.transform.position;
        }

        if (other.CompareTag("Collectible"))
        {
            foreach (GameObject foodOutOfBounds in collectibleFoods)
            {
                if (foodOutOfBounds == other.gameObject)
                {
                    other.transform.position = closestRespawn.transform.position;
                    break;
                }
            }
        }
    }
}
