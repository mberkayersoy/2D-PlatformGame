using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject player; // or transform
    [SerializeField] private Transform respawnPoint;
    [SerializeField] float nextSpawnTime = 0;
    [SerializeField] float spawnCooldownTime = 5f;
   // bool isDead = false;
    private void Update() 
    {
        if (Time.time > nextSpawnTime)
        {
            Debug.Log("update");
            nextSpawnTime = Time.time + spawnCooldownTime;
            player.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        //if(isColliding) return;
        //isColliding = true;
        if (other.tag == "Player")
        {
            Debug.Log("trigger"); 
            player.transform.position = respawnPoint.transform.position;
            //isDead = !isDead;
            player.SetActive(false);
        }  
        //StartCoroutine(Reset());
    }
}
