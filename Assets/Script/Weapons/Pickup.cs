using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] float damage = 20;
    
    private void Start()
    {
            
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("circle");
        if (other.tag == "Player"){
            other.GetComponent<Health>().TakeDamage(damage);
            //Destroy(gameObject);
        }    
    }
}
