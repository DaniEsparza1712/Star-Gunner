using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Transform> spawnPositions;
    public GameObject pointObject;
    public GameObject ammoObject;
    public GameObject transformContainer;
    [SerializeField] private int spawnedPoints;
    [SerializeField] private int spawnedAmmo;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < transformContainer.transform.childCount; i++){
            spawnPositions.Add(transformContainer.transform.GetChild(i).GetComponent<Transform>());
        }
        for(int i = 0; i < spawnedPoints; i++){
            Spawn(pointObject);
        }
        for(int i = 0; i < spawnedAmmo; i++){
            Spawn(ammoObject);
        }
    }
    void Spawn(GameObject objectSpawn){
        int n = spawnPositions.Count;
        int selectedPos = Random.Range(0, n);

        GameObject spawned = Instantiate(objectSpawn, spawnPositions[selectedPos].transform.position, Quaternion.identity);
        spawned.transform.parent = gameObject.transform;
        spawnPositions.Remove(spawnPositions[selectedPos]);
    }
}
