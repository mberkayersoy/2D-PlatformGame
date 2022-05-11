using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float speed = 20f;
        [SerializeField] float damage = 20f;
            
        private void Update()
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime);       
            //transform.Translate(Vector3.right * speed * Time.deltaTime);
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                other.GetComponent<Health>().TakeDamage(damage);
                Destroy(gameObject);  
            }
        }

    }
}