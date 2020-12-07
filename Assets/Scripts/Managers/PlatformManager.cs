using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject platformPrefab;
    private GameObject plat;

    [Header("Alignment")]
    [SerializeField]
    private float leftBoundary = -5f;
    [SerializeField]
    private float rightBoundary = 5f;
    [SerializeField]
    private float platformHeight = 14;
    [SerializeField]
    private float minVerticalOffset = 0.7f;
    [SerializeField]
    private float maxVerticalOffset = 1.2f;

    [Header("Spring Platform")]
    [SerializeField]
    private GameObject springPrefab;
    [SerializeField]
    private float chanceToSpawnSpring = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Random.Range(1,100) > chanceToSpawnSpring)
        {
            plat = Instantiate(platformPrefab, new Vector2(Random.Range(leftBoundary, rightBoundary), player.transform.position.y + (platformHeight + Random.Range(minVerticalOffset, maxVerticalOffset))), Quaternion.identity);
        }
        else
        {
            plat = Instantiate(springPrefab, new Vector2(Random.Range(leftBoundary, rightBoundary), player.transform.position.y + (platformHeight + Random.Range(minVerticalOffset, maxVerticalOffset))), Quaternion.identity);
        }
        Destroy(collision.gameObject);
    }
}
