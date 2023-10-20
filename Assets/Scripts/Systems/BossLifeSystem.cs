using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLifeSystem : MonoBehaviour
{
    public int totalLife;
    public int totalStun;
    float lifePoints;
    public float GetLifePoints => lifePoints;
    float stunPoints;
    public float GetStunPoints => stunPoints;
    public Image lifeImage;
    public Image stunImage;

    private void Start() {
        lifePoints = totalLife;
        stunPoints = totalStun;
    }
    private void Update() {
        lifePoints = (lifePoints < 0)? 0 : lifePoints;
        lifePoints = (lifePoints > totalLife)? totalLife: lifePoints;

        stunPoints = (stunPoints < 0)? 0 : stunPoints;
        stunPoints = (stunPoints > totalStun)? totalStun: stunPoints;

        if(stunPoints < 0)
            stunPoints = 0;

        lifeImage.fillAmount = lifePoints / totalLife;
        stunImage.fillAmount = stunPoints / totalStun;
    }
    private void RemoveLife(int value){
        lifePoints -= value;
    }
    private void RemoveStun(int value){
        stunPoints -= value;
    }
    public void FillStun(){
        stunPoints = totalStun;
    }
    public void ReceiveDamage(int value){
        if(stunPoints > 0){
            RemoveStun(value);
        }
        else{
            RemoveLife(value);
        }
    }
    public void Disappear(){
        Destroy(gameObject);
    }
}
