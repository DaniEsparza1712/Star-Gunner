using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public Rigidbody rb;
    public float impulse;
    public ParticleSystem boomParticles;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.Find("Player");
        transform.LookAt(player.transform.position + Vector3.up * 0.5f);
        rb.AddForce(transform.forward * impulse, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Wall") | other.CompareTag("Lava")){
            Instantiate(boomParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if(other.CompareTag("Player")){
            Instantiate(boomParticles, other.transform.position, Quaternion.identity);
            var playerLife = other.GetComponent<LifeSystem>();
            playerLife.ApplyDamage(damage);
        }
    }
}
