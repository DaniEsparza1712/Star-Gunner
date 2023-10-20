using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData weaponData;
    public int bullets;
    public GameObject muzzleFlash;
    public LayerMask layerMask;
    public ParticleSystem enemyHitParticles;
    public ParticleSystem wallHitParticles;
    public AudioSource audioSource;
    [HideInInspector] public List<Cartridge> cartridges = new List<Cartridge>();
    private bool shooting = false;
    [HideInInspector] public bool canShoot = true;
    
    // Start is called before the first frame update
    void Start()
    {
        muzzleFlash.SetActive(false);
        Recharge(bullets);
        canShoot = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Recharge")){
            bullets = GetBulletCount();
            Recharge(bullets);
        }
        if((Input.GetButton("Fire1") | Input.GetAxisRaw("Fire1") == 1) && !shooting && canShoot){
            if(weaponData.type == WeaponData.weaponType.rifle | weaponData.type == WeaponData.weaponType.shotgun){
                StartCoroutine("Shoot");
            }
            else if(weaponData.type == WeaponData.weaponType.laser){
                ShootLaser();
            }
        }
        else if((Input.GetButtonUp("Fire1") | Input.GetAxisRaw("Fire1") != 1) && weaponData.type == WeaponData.weaponType.laser){
            Transform beam = gameObject.transform.Find("Beam");
            beam.gameObject.SetActive(false);
        }
        if(GetComponentInParent<LifeSystem>().life <= 0){
            gameObject.SetActive(false);
        }
    }

    public void PickUpBullets(int amount){
        int excess = amount;
        bool lastCartridge = cartridges.Count == weaponData.cartridgesAmount;
        if(cartridges.Count > 0){
            while(excess > 0 && !lastCartridge){
                excess = cartridges[cartridges.Count-1].AddBullets(excess);
                if(excess > 0 && !lastCartridge){
                    cartridges.Add(new Cartridge(weaponData.cartridgeBullets));
                }
                lastCartridge = cartridges.Count == weaponData.cartridgesAmount;
            }
        }
        else{
            cartridges.Add(new Cartridge(weaponData.cartridgeBullets));
            PickUpBullets(amount);
        }
        if(lastCartridge){
            cartridges[cartridges.Count-1].AddBullets(excess);
        }
    }

    void Recharge(int totalBullets){
        canShoot = false;
        cartridges.Clear();
        int counter = 0;
        while(cartridges.Count < weaponData.cartridgesAmount && totalBullets > 0){
            cartridges.Add(new Cartridge(weaponData.cartridgeBullets));
            totalBullets = cartridges[counter].AddBullets(totalBullets);
            counter++;
        }
        StartCoroutine("WaitForRecharge", weaponData.rechargeTime);
    }
    IEnumerator WaitForRecharge(float time){
        audioSource.PlayOneShot(weaponData.reload1);
        yield return new WaitForSeconds(time);
        audioSource.PlayOneShot(weaponData.reload2);
        canShoot = true;
    }
    int GetBulletCount(){
        int bulletCount = 0;
        foreach(Cartridge cartridge in cartridges){
            bulletCount += cartridge.GetBullets;
        }
        return bulletCount;
    }
    
    IEnumerator Shoot(){
        shooting = true;
        if(cartridges.Count > 0 && cartridges[0].GetBullets > 0){
            audioSource.PlayOneShot(weaponData.shootSound);
            if(weaponData.type == WeaponData.weaponType.rifle){
                cartridges[0].ShootBullet(1);
            }
            else if(weaponData.type == WeaponData.weaponType.shotgun){
                cartridges[0].ShootBullet(5);
            }
            CastBullet();
            StartCoroutine("MuzzleFlashing");
            yield return new WaitForSeconds(weaponData.shootingRate);
        }
        else{
            bullets = GetBulletCount();
            Recharge(bullets);
        }
        shooting = false;
    }
    IEnumerator MuzzleFlashing(){
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.02f);
        muzzleFlash.SetActive(false);
    }

    void CastBullet(){
        GameObject player = GameObject.Find("Player");
        RaycastHit hit;
        if(Physics.Raycast(player.transform.position, player.transform.forward, out hit, weaponData.scope, layerMask)){
            string hitTag = hit.transform.tag;
            switch(hitTag){
                case "Wall":
                    Instantiate(wallHitParticles, hit.point, Quaternion.LookRotation(hit.normal));
                    break;
                case "Enemy":
                    var playerObj = GameObject.Find("Player");
                    var enemyMachine = hit.transform.GetComponent<BasicEnemyMachine>();
                    enemyMachine.target = playerObj;
                    enemyMachine.ChangeTo("Follow");
                    hit.transform.GetComponent<LifeSystem>().ApplyDamage(weaponData.damage);
                    Instantiate(enemyHitParticles, hit.point, Quaternion.LookRotation(hit.normal));
                    break;
                case "Boss":
                    hit.transform.GetComponent<BossLifeSystem>().ReceiveDamage(weaponData.damage);
                    Instantiate(enemyHitParticles, hit.point, Quaternion.LookRotation(hit.normal));
                    break;
            }
        }
    }

    void ShootLaser(){
        GameObject player = GameObject.Find("Player");
        RaycastHit hit;
        Vector3 dir;
        Transform beam = gameObject.transform.Find("Beam");
        beam.gameObject.SetActive(true);
        if(Physics.Raycast(player.transform.position, player.transform.forward, out hit, weaponData.scope, layerMask)){
            RaycastHit gunHit;
            dir = (hit.point - muzzleFlash.transform.position).normalized;
            Physics.Raycast(muzzleFlash.transform.position, dir, out gunHit);
            if(gunHit.transform.gameObject.CompareTag("Enemy") && gunHit.transform.gameObject.GetComponent<LifeSystem>()){
                LifeSystem enemyLife = gunHit.transform.gameObject.GetComponent<LifeSystem>();
                enemyLife.ApplyDamage(weaponData.damage);
                if(gunHit.transform.gameObject.GetComponent<BasicEnemyMachine>().target != player){
                    BasicEnemyMachine enemy = gunHit.transform.gameObject.GetComponent<BasicEnemyMachine>();
                    enemy.target = player;
                    enemy.ChangeTo("Follow");
                }
            }
            else if(gunHit.transform.gameObject.CompareTag("Boss") && gunHit.transform.gameObject.GetComponent<BossLifeSystem>()){
                BossLifeSystem bossLife = gunHit.transform.gameObject.GetComponent<BossLifeSystem>();
                bossLife.ReceiveDamage(weaponData.damage);
            }
            DrawLaser(muzzleFlash.transform.position, gunHit.point);
        }
        else{
            dir = (player.transform.position + (player.transform.forward * weaponData.scope) - muzzleFlash.transform.position).normalized;
            Vector3 endPoint = muzzleFlash.transform.position + dir * weaponData.scope;
            DrawLaser(muzzleFlash.transform.position, endPoint);
        }
    }
    void DrawLaser(Vector3 startPos, Vector3 endPos){
        LineRenderer line = GetComponentInChildren<LineRenderer>();
        line.SetPosition(0, startPos);
        line.SetPosition(1, endPos);
        Transform endVFX = gameObject.transform.Find("Beam/EndVFX");
        endVFX.position = endPos;
    }
}