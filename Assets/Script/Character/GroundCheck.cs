using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    public bool isGround = true;

    private void OnTriggerStay2D(Collider2D other) 
    {
        isGround = other != null && (((1 << other.gameObject.layer) & platformLayerMask) != 0);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isGround = false;    
    }
}
