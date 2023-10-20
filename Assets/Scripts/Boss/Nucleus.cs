using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nucleus : MonoBehaviour
{
    public EnemyProjectile projectile;
    public GameObject shield;
    public IEnumerator SpawnProjectiles(){
        for(int i = 0; i < 5; i++){
            yield return new WaitForSeconds(0.3f);
            Instantiate(projectile.gameObject, transform.position, Quaternion.identity);
            
        }
    }
    public void ActivateShield(){
        shield.SetActive(true);
    }
}
