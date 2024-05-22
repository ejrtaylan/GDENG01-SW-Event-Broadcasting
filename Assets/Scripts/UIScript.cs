using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    private int spawnCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSpawnCubeClicked(){
        Debug.Log("Spawn Cubes Clicked");
        Parameters param = new Parameters();
        param.PutExtra("NUM_SPAWNS", 2);
        EventBroadcaster.Instance.PostEvent(EventNames.S23_ABT_Events.ON_SPAWN_CUBES_CLICKED, param);
    }

    public void OnSpawnBallClicked(){
        Debug.Log("Spawn Ball Clicked");
        EventBroadcaster.Instance.PostEvent(EventNames.S23_ABT_Events.ON_SPAWN_BALLS_CLICKED);

    }

    public void OnClearAllClicked(){
        Debug.Log("Clear All Clicked");
        EventBroadcaster.Instance.PostEvent(EventNames.S23_ABT_Events.CLEAR_ALL_CLICKED);
    }

    public void OnUpdateSpawnCount(){
        // InputField this.GameObject().GetComponentInChildren(InputField, false);
        this.spawnCount = 0;
        Debug.Log("Value update");
    }
}
