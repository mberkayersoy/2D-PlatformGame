using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollider : MonoBehaviour
{
    [SerializeField] float spawnCooldownTime = 5f;
    [SerializeField] float nextSpawnTime = 0;
    [SerializeField] float respawnTime = 3;
    [SerializeField] private Transform respawnPoint;

    private void Update() 
    {
        
    }
/*    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            other.gameObject.SetActive(false);
            CreateCharacter(other.gameObject);
        }
    }

    public void CreateCharacter(GameObject other)
    {
        other.gameObject.transform.position = respawnPoint.transform.position;
        if (Time.time > nextSpawnTime)
        {   
            Debug.Log("create");
            nextSpawnTime = Time.time + spawnCooldownTime;
            other.gameObject.SetActive(true);
        }
    }*/
}
