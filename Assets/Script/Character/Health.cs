using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] GameObject respawnPoints;

    private void Start() 
    {  
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) {
            gameObject.SetActive(false);
            gameObject.transform.position = respawnPoints.transform.position;
            RandomSpawner();
            gameObject.SetActive(true);
            DefaultCharacter(); 
        }
    }

    public void DefaultCharacter() 
    {
        health = 100;
    }

    public void RandomSpawner()
    {
        int randomSpawnPoint = UnityEngine.Random.Range(0, respawnPoints.transform.childCount);
        gameObject.transform.position = respawnPoints.transform.GetChild(randomSpawnPoint).position;

        /*Transform[] childs = (Transform[]) respawnPoints.GetComponentsInChildren<Transform>();
        respawnPoints = (GameObject)((Transform)childs[UnityEngine.Random.Range(0, childs.Length)]).gameObject;
        return respawnPoints;*/
    }
    
}
