using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName = "Weapon", menuName = "New Weapon", order = 0)]
public class Weapon : ScriptableObject
{
    [SerializeField] GameObject equippedPrefab = null;
    [SerializeField] float weaponDamage = 5;
    //[SerializeField] Projectile projectile = null;
     const string weaponName = "Weapon";


}
