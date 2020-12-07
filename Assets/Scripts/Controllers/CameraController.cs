using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Tooltip("Player object with PlayerController script attached.")]
    private PlayerController player;

    private Vector3 lastPlayerPosition;
    private float distanceToMoveY;
    private float distanceToMoveX;

    private void Start()
    {
        // get player
        player = FindObjectOfType<PlayerController>();
        // get initial player position
        lastPlayerPosition = player.transform.position;
    }

    private void Update()
    {
        MoveCameraWhenPlayerMoves();
    }

    /// <summary>
    /// Move camera on x-axis at the same speed as player runs.
    /// </summary>
    private void MoveCameraWhenPlayerMoves()
    {
        distanceToMoveX = player.transform.position.x - lastPlayerPosition.x;
        distanceToMoveY = player.transform.position.y - lastPlayerPosition.y;
        transform.position = new Vector3(transform.position.x + distanceToMoveX, transform.position.y + distanceToMoveY, transform.position.z);
        lastPlayerPosition = player.transform.position;
    }
}
