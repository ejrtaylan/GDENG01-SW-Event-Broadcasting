using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject Prefab;
    [SerializeField] protected List<GameObject> spawnedObjects;

    [SerializeField] private float spawnLocVariance = 5.0f;
    [SerializeField] private float spawnLocHeightVariance = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.Prefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void Spawn(){
        Vector3 spawnLoc = this.transform.localPosition;

        spawnLoc.x += Random.Range(-this.spawnLocVariance, spawnLocVariance);
        spawnLoc.y += Random.Range(-this.spawnLocHeightVariance, spawnLocHeightVariance);
        spawnLoc.z += Random.Range(-this.spawnLocVariance, spawnLocVariance);

        GameObject obj = this.SpawnObject(this.Prefab, this.transform, spawnLoc);
        this.spawnedObjects.Add(obj);
    }

    private GameObject SpawnObject(GameObject toSpawn, Transform parent, Vector3 localPos)
    {
        GameObject spawn = GameObject.Instantiate(toSpawn, parent);
        spawn.SetActive(true);
        spawn.transform.localPosition = localPos;
        return spawn;
    }

    protected void ClearSpawns(){
        for(int i = 0; i < this.spawnedObjects.Count; i++){
            GameObject.Destroy(this.spawnedObjects[i]);
        } 

        this.spawnedObjects.Clear();
    }
}
