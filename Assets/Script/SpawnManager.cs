using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject SpawnObj;
    Vector3 spawnPos = new Vector3(30, 0, 0);
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObject", 2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObject()
    {
        if (playerControllerScript.isGameOver == false)
        {
            Instantiate(SpawnObj, spawnPos, transform.rotation);

        }
    }
}
