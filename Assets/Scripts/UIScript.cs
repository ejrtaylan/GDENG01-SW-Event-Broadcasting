using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Palmmedia.ReportGenerator.Core.Common;

public class UIScript : MonoBehaviour
{
    private int spawnCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSpawnCubeClicked(){
        Parameters param = new Parameters();
        param.PutExtra("NUM_SPAWNS", this.spawnCount);
        EventBroadcaster.Instance.PostEvent(EventNames.S23_ABT_Events.ON_SPAWN_CUBES_CLICKED, param);
    }

    public void OnSpawnBallClicked(){
        Parameters param = new Parameters();
        param.PutExtra("NUM_SPAWNS", this.spawnCount);
        EventBroadcaster.Instance.PostEvent(EventNames.S23_ABT_Events.ON_SPAWN_BALLS_CLICKED);

    }

    public void OnClearAllClicked(){
        EventBroadcaster.Instance.PostEvent(EventNames.S23_ABT_Events.CLEAR_ALL_CLICKED);
    }

    public void OnUpdateSpawnCount(string input){
        this.spawnCount = 1;
        spawnCount = int.Parse(input);
    }
}
