using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] GameObject respawnPoints;
    [SerializeField] float coolDown = 5f;
    [SerializeField] float nextTime = 0;
    bool isDead = false;
    
   
    private void Start() 
    {
        nextTime = Time.time + coolDown;
    }
    private void Update() 
    {
        /*if (Time.time > nextTime)
        {
            Debug.Log("update");
            nextTime = Time.time + coolDown;
            gameObject.SetActive(true);
        }*/
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        //int randomPoint = UnityEngine.Random.Range(0, 100);

        if (other.tag == "Fall")
        {

            gameObject.SetActive(false);
            nextTime = Time.time + coolDown;
            isDead = true;
            RandomSpawner();
            gameObject.SetActive(true);

        }
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
