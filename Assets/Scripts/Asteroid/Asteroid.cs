using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private Transform asteroidContainer;
    [SerializeField] private Transform asteroid;
    [SerializeField] private Transform asteroidShadow;
    [SerializeField] private float rotationSpeed = 30f;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.gravityScale
    }

    private void Update()
    {
        asteroid.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        asteroidShadow.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
