using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformSpawner : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;
    [SerializeField] private float maxDistance;
    [SerializeField] private float spawnDelay;
    [SerializeField] private GameObject movingPlatform;

    private float lastTimeSpawned = 0;

    private void Update()
    {
        if(Time.time - lastTimeSpawned > spawnDelay)
        {
            lastTimeSpawned = Time.time;
            GameObject instance = Instantiate(movingPlatform);
            instance.transform.position = transform.position;
            MovingPlatform platform = instance.GetComponent<MovingPlatform>();
            platform.velocity = velocity;
            platform.maxDistance = maxDistance;
        }
    }
}
