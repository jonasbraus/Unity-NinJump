using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void Update()
    {
        Vector3 position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        transform.position = position;
    }
}
