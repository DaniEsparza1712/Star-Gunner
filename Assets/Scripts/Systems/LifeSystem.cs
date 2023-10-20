using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public float totalLife = 200;
    public float life = 200;
    public Image image;

    void Update()
    {
        life = (life < 0)? 0 : life;
        life = (life > totalLife)? totalLife: life;

        image.fillAmount = life / totalLife;
    }

    public void ApplyDamage(int damage)
    {
        if(life > 0)
            life -= damage;
    }
    public void Disappear(){
        Destroy(gameObject);
    }
}