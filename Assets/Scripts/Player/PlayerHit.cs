using System.Collections;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField] private HitCounter hitCounter;
    private SpriteRenderer playerSprite;
    private Color32 initialPlayerColor;


    private void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        initialPlayerColor = playerSprite.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(collision.gameObject);
            DamagePlayer();
        }
    }

    private void DamagePlayer()
    {
        StartCoroutine(ChangeColor());
        hitCounter.UpdateHitCounter(1);
    }

    private IEnumerator ChangeColor()
    {
        playerSprite.color = new Color32(192, 57, 57, 255);
        yield return new WaitForSeconds(0.25f);
        playerSprite.color = initialPlayerColor;
    }
}
