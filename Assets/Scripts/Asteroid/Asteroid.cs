using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private Transform asteroidContainer;
    [SerializeField] private Transform asteroid;
    [SerializeField] private SpriteRenderer asteroidSprite;
    [SerializeField] private Transform asteroidShadow;
    [SerializeField] private SpriteRenderer asteroidShadowSprite;
    [SerializeField] private float rotationSpeed = 30f;
    private int rotationSide;


    void Start()
    {
        float randomScaleNumber = Random.Range(0.5f, 1.5f);
        asteroidContainer.localScale = new Vector3(randomScaleNumber, randomScaleNumber, randomScaleNumber);
        int randomSide = Random.Range(0, 2);
        rotationSide = randomSide == 0 ? -1 : 1;
    }

    private void Update()
    {
        asteroid.Rotate(Vector3.forward * rotationSide, rotationSpeed * Time.deltaTime);
        asteroidShadow.Rotate(Vector3.forward * rotationSide, rotationSpeed * Time.deltaTime);
    }

    public void AssignSprites(Sprite sprite)
    {
        asteroidSprite.sprite = sprite;
        asteroidShadowSprite.sprite = sprite;
    }
}
