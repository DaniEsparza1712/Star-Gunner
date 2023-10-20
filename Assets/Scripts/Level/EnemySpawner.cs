using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private int enemies = 5;
    public List<GameObject> spawnPositions;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< enemies; i++){
            int pos = Random.Range(0, spawnPositions.Count);
            GameObject enemyInst = Instantiate(enemy, spawnPositions[pos].transform.position, spawnPositions[pos].transform.rotation);
            enemyInst.transform.parent = GameObject.Find("Level").transform;
            spawnPositions.Remove(spawnPositions[pos]);
        }
    }
}
