using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    [SerializeField] GameObject[] projectilePrefabs;

    PlayerControllerX playerControllerX;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", 2, 1.5f);
        playerControllerX = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }


    // Spawn obstacles
    void SpawnObjects ()
    {
        if (playerControllerX.gameOver == false)
        {
            Vector3 spawnPos = new Vector3(Random.Range(10, 20), Random.Range(5, 13), 0);
            int spawnIndex = Random.Range(0, projectilePrefabs.Length);
            Instantiate(projectilePrefabs[spawnIndex], spawnPos, projectilePrefabs[spawnIndex].transform.rotation);
        }
    }
}
