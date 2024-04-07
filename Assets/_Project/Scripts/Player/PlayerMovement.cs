using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private PausePopUp pausePopUp;
    private Animator animator;
    private Rigidbody2D rb;
    private int movingDirection;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (pausePopUp.IsPaused()) return;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if ((touch.position.x < (Screen.width / 2)) && (movingDirection != -1))
            {
                PointerDown(true);
            }

            else if ((touch.position.x > (Screen.width / 2)) && (movingDirection != 1))
            {
                PointerDown(false);
            }
        }
        else if (movingDirection != 0)
        {
            PointerUp();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void PointerDown(bool isLeft)
    {
        movingDirection = isLeft ? -1 : 1;
        animator.SetBool(isLeft ? "Left" : "Right", true);
        animator.SetBool(isLeft ? "Right" : "Left", false);
    }

    public void PointerUp()
    {
        movingDirection = 0;
        animator.SetBool("Left", false);
        animator.SetBool("Right", false);
    }

    private void MovePlayer()
    {
        if (movingDirection == 0 && rb.velocity == Vector2.zero) return;
        float movementSpeed = movingDirection != 0 ? moveSpeed : 0f;
        Vector2 movement = Vector2.right * movingDirection * movementSpeed * Time.fixedDeltaTime;
        rb.velocity = transform.rotation * movement;
    }
}
