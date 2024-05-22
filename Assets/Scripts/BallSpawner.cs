using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : Spawner
{
    public const string NUM_SPAWNS = "NUM_SPAWNS";

    // Start is called before the first frame update
    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.S23_ABT_Events.ON_SPAWN_BALLS_CLICKED, this.OnSpawnEvent);
        EventBroadcaster.Instance.AddObserver(EventNames.S23_ABT_Events.CLEAR_ALL_CLICKED, this.OnClearEvent);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.S23_ABT_Events.ON_SPAWN_BALLS_CLICKED);
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
            this.Spawn();
        }

    }

    private void OnClearEvent()
    {
        this.ClearSpawns();
    }
}
