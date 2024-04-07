using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private Asteroid asteroidPrefab;
    [SerializeField] private Image spawnArea;
    [SerializeField] private float spawnInterval;
    [SerializeField] private List<Sprite> asteroidSprites;

    private void Start()
    {
        Random.InitState((int)System.DateTime.UtcNow.Ticks);
        InvokeRepeating(nameof(SpawnAsteroid), 0f, spawnInterval);
    }

    public void SpawnAsteroid()
    {
        RectTransform rectTransform = spawnArea.rectTransform;

        Vector3 minWorldPos = rectTransform.TransformPoint(rectTransform.rect.min);
        Vector3 maxWorldPos = rectTransform.TransformPoint(rectTransform.rect.max);

        float randomX = Random.Range(minWorldPos.x, maxWorldPos.x);
        float randomY = Random.Range(minWorldPos.y, maxWorldPos.y);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

        Asteroid asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

        int randomAsteroidIndex = Random.Range(0, asteroidSprites.Count);
        asteroid.AssignSprites(asteroidSprites[randomAsteroidIndex]);
    }
}
