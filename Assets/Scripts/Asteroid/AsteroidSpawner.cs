using UnityEngine;
using UnityEngine.UI;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroid;
    [SerializeField] private Image spawnArea;
    [SerializeField] private float spawnInterval;

    private void Start()
    {
        Random.seed = System.DateTime.Now.Millisecond;
        InvokeRepeating(nameof(SpawnObject), 0f, spawnInterval);
    }
    public void SpawnObject()
    {
        RectTransform rectTransform = spawnArea.rectTransform;

        Vector3 minWorldPos = rectTransform.TransformPoint(rectTransform.rect.min);
        Vector3 maxWorldPos = rectTransform.TransformPoint(rectTransform.rect.max);

        float randomX = Random.Range(minWorldPos.x, maxWorldPos.x);
        float randomY = Random.Range(minWorldPos.y, maxWorldPos.y);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

        Instantiate(asteroid, spawnPosition, Quaternion.identity);
    }
}
