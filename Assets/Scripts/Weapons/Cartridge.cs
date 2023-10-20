using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartridge
{
    private int bullets;
    public int GetBullets => bullets;
    private int bulletLimit;
    public Cartridge(int limit){
        bulletLimit = limit;
    }
    public int AddBullets(int amount){
        bullets += amount;
        int excess = 0;
        if(bullets > bulletLimit){
            excess = bullets - bulletLimit;
            bullets = bulletLimit;
        }
        return excess;
    }
    public void ShootBullet(int shotBullets){
        bullets-=shotBullets;
        Debug.Log(bullets);
    }
}
