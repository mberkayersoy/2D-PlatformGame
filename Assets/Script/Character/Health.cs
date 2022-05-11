using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    public class Health : MonoBehaviour
    {
        float maxHealth = 100;
        [SerializeField] float currentHealth;
        [SerializeField] GameObject respawnPoints;
        public HealthBar healthBar = null;

        private void Start() 
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth); 
        }
        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0) {
                CreateCharacter();
            }
        }

        public void CreateCharacter()
        {
            gameObject.SetActive(false);
            gameObject.transform.position = respawnPoints.transform.position;
            RandomSpawner();
            gameObject.SetActive(true);
            DefaultCharacter(); 
        }

        public void DefaultCharacter() 
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth); 
            gameObject.GetComponent<Fighter>().SetDefaultWeapon();
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
}
