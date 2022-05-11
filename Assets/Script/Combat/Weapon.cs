using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "New Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        [SerializeField] GameObject equippedPrefab = null;
        [SerializeField] float weaponDamage = 5;
        [SerializeField] Projectile projectile = null;
        const string weaponName = "Weapon";

        public void Spawn(Transform weaponTransform)
        {
            DestroyOldWeapon(weaponTransform);
            if (equippedPrefab != null)
            {
                GameObject weapon = Instantiate(equippedPrefab, weaponTransform);
                weapon.name = weaponName;
            }
        }

        public void LaunchProjectile(Transform weaponTransform)
        {
            Projectile projectileInstance = Instantiate(projectile, weaponTransform.position, Quaternion.identity);
        }

        public bool HasProjectile()
        {
            return projectile != null; 
        }

        public void DestroyOldWeapon(Transform weaponTransform)
        {
            Transform oldWeapon = weaponTransform.Find(weaponName);

            if (oldWeapon == null) return;

            oldWeapon.name = "DESTROYING";
            Destroy(oldWeapon.gameObject);
        }
    }

}
