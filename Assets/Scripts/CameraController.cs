using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    // here we are going to follow player movements by adding offsets to the position values of player
    // and assigning it to the camera position values

    private Vector3 offset;
    public GameObject player;

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }
    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}