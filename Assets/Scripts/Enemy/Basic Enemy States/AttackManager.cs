using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public ParticleSystem hitParticle;
    public ParticleSystem smoke;
    public int damage;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Wall")){
            Instantiate(hitParticle, other.transform.position, Quaternion.identity);
            Instantiate(smoke, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("Player")){
            Instantiate(hitParticle, other.transform.position, Quaternion.identity);
            var playerLife = other.GetComponent<LifeSystem>();
            playerLife.ApplyDamage(damage);
        }
    }
}
