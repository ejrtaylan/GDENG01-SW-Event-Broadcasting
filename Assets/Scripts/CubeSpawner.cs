using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject template;
    [SerializeField] private List<GameObject> objectList;

    [SerializeField] private float spawnLocVariance = 6.0f;
    [SerializeField] private float spawnLocHeightVariance = 2.0f;

    public const string NUM_SPAWNS = "NUM_SPAWNS";

    // Start is called before the first frame update
    void Start()
    {
        this.template.SetActive(false);
        EventBroadcaster.Instance.AddObserver(EventNames.S23_ABT_Events.ON_SPAWN_CUBES_CLICKED, this.OnSpawnEvent);
        EventBroadcaster.Instance.AddObserver(EventNames.S23_ABT_Events.CLEAR_ALL_CLICKED, this.OnClearEvent);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.S23_ABT_Events.ON_SPAWN_CUBES_CLICKED);
        EventBroadcaster.Instance.RemoveObserver(EventNames.S23_ABT_Events.CLEAR_ALL_CLICKED);
    }

    void Update()
    {
        
    }

    private void OnSpawnEvent(Parameters param)
    {
        int numSpawn = param.GetIntExtra(NUM_SPAWNS, 1);

        for (int i = 0; i < numSpawn; i++)
        {
            Vector3 spawnLoc = this.transform.localPosition;

            spawnLoc.x += Random.Range(-this.spawnLocVariance, spawnLocVariance);
            spawnLoc.y += Random.Range(-this.spawnLocHeightVariance, spawnLocHeightVariance);
            spawnLoc.z += Random.Range(-this.spawnLocVariance, spawnLocVariance);

            GameObject instance = GameObject.Instantiate(this.template, spawnLoc, this.transform.rotation, this.transform);
            instance.SetActive(true);
            this.objectList.Add(instance);
        }
        
    }

    private void OnClearEvent()
    {
        for(int i = 0; i < this.objectList.Count; i++)
        {
            GameObject.Destroy(this.objectList[i]);
        }

        this.objectList.Clear();

    }
}
