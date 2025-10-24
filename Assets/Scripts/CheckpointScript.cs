using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private RespawnScript respawn;
    private BoxCollider2D checkPointCollider;


    private void Awake()
    {
        checkPointCollider = GetComponent<BoxCollider2D>();
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnScript>();
    }

    private void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            respawn.respawnPoint = transform;
            checkPointCollider.enabled = false;
        }
    }



}