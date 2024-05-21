using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject CubePrefab;
    [SerializeField] private GameObject BallPrefab;
    [SerializeField] private List<GameObject> spawnedObjects;

    [SerializeField] private float spawnLocVariance = 6.0f;
    [SerializeField] private float spawnLocHeightVariance = 2.0f;

    // Remove once proper implementation exists
    [SerializeField] private int spawnCount = 3;

    // Start is called before the first frame update
    void Start()
    {
        this.CubePrefab.SetActive(false);
        this.BallPrefab.SetActive(false);

        // Remove once proper implementation exists
        this.StartCoroutine(this.RepeatEvery(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Remove once proper implementation exists
    private IEnumerator RepeatEvery(float seconds){
        yield return new WaitForSeconds(seconds);

        for(int i = 0; i < spawnCount; i++){
            this.SpawnCube();
            this.SpawnBall();
        }

        yield return new WaitForSeconds(2);

        this.ClearSpawns();

        this.StartCoroutine(this.RepeatEvery(seconds));
    }

    private void SpawnCube(){
        Vector3 spawnLoc = this.transform.localPosition;

        spawnLoc.x += Random.Range(-this.spawnLocVariance, spawnLocVariance);
        spawnLoc.y += Random.Range(-this.spawnLocHeightVariance, spawnLocHeightVariance);
        spawnLoc.z += Random.Range(-this.spawnLocVariance, spawnLocVariance);

        GameObject obj = this.SpawnObject(this.CubePrefab, this.transform, spawnLoc);
        this.spawnedObjects.Add(obj);
    }

    private void SpawnBall(){
        Vector3 spawnLoc = this.transform.localPosition;

        spawnLoc.x += Random.Range(-this.spawnLocVariance, spawnLocVariance);
        spawnLoc.y += Random.Range(-this.spawnLocHeightVariance, spawnLocHeightVariance);
        spawnLoc.z += Random.Range(-this.spawnLocVariance, spawnLocVariance);

        GameObject obj = this.SpawnObject(this.BallPrefab, this.transform, spawnLoc);
        this.spawnedObjects.Add(obj);
    }

    private void ClearSpawns(){
        for(int i = 0; i < this.spawnedObjects.Count; i++){
            GameObject.Destroy(this.spawnedObjects[i]);
        } 

        this.spawnedObjects.Clear();
    }

    private GameObject SpawnObject(GameObject toSpawn, Transform parent, Vector3 localPos){
        GameObject spawn = GameObject.Instantiate(toSpawn, parent);
        spawn.SetActive(true);
        spawn.transform.localPosition = localPos;
        return spawn;
    }
}
