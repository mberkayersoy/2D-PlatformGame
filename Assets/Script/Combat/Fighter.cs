using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Combat
{
    public class Fighter : MonoBehaviour
    {
        Weapon currentWeapon = null;
        [SerializeField] Weapon defaultWeapon = null;
        [SerializeField] Transform weaponTransform;
        [SerializeField] float destroySeconds = 5;

        private void Start() 
        {
            if (currentWeapon == null)
            {
                EquipWeapon(defaultWeapon);
            }
        }
        private void Update() 
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();    
            }
        }
        public void EquipWeapon(Weapon weapon)
        {
            currentWeapon = weapon;
            weapon.Spawn(weaponTransform);
            StartCoroutine(DestroyWeaponAfterWeapon(destroySeconds));
        }
        

        public void Attack()
        {
            if (currentWeapon.HasProjectile())
            {
                currentWeapon.LaunchProjectile(weaponTransform);
                print("1");
            }
        }

        private IEnumerator DestroyWeaponAfterWeapon(float destroySeconds)
        {
            yield return new WaitForSeconds(destroySeconds);
            SetDefaultWeapon();
            currentWeapon.DestroyOldWeapon(weaponTransform);
            
        }

        public void SetDefaultWeapon()
        {
            currentWeapon = defaultWeapon;
        }
        
    }
}
