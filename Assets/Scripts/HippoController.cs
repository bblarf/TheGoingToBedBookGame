using UnityEngine;

public class HippoController : MonoBehaviour
{
    public float speed = .1f;
    public float jumpHeight = 1.5f;
    public float acceleration = 3f;
    public float deceleration = 12f;
    public SpriteRenderer spriteRenderer;
    float horizontalVelocity;
    public LayerMask groundLayer;

    [Header("Ground check")]
    public float groundCheckRadius = 0.08f;

    Collider2D col;
    bool jumpUsedSinceGrounded;

    bool IsGrounded()
    {
        if (col == null)
        {
            return false;
        }

        // Check just below the collider's bottom, so we only count as grounded when touching.
        Bounds b = col.bounds;
        Vector2 checkPos = new Vector2(b.center.x, b.min.y - 0.02f);

        Debug.DrawLine(new Vector2(b.min.x, b.min.y), new Vector2(b.max.x, b.min.y), Color.yellow);
        Debug.DrawRay(checkPos, Vector2.down * 0.05f, Color.green);

        // OverlapCircle can return our own collider if the player's layer is included in groundLayer.
        // So we explicitly ignore self.
        Collider2D[] hits = Physics2D.OverlapCircleAll(checkPos, groundCheckRadius, groundLayer);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] != null && hits[i] != col)
            {
                return true;
            }
        }
        return false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // Horizontal movement: accelerate toward top speed, decelerate quickly when key released
        float targetVelocity = 0f;
        if (Input.GetKey(KeyCode.RightArrow)){
            targetVelocity = speed;
            spriteRenderer.flipX = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            targetVelocity = -speed;
            spriteRenderer.flipX = false;
        }
        float rate = (Mathf.Abs(targetVelocity) > 0.01f) ? acceleration : deceleration;
        horizontalVelocity = Mathf.MoveTowards(horizontalVelocity, targetVelocity, rate * Time.deltaTime);
        Vector2 curPos = gameObject.transform.position;
        gameObject.transform.position = new Vector2(curPos.x + horizontalVelocity * Time.deltaTime, curPos.y);

        bool grounded = IsGrounded();
        if (grounded)
        {
            jumpUsedSinceGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded && !jumpUsedSinceGrounded)
        {
            jumpUsedSinceGrounded = true;
            curPos = gameObject.transform.position;
            gameObject.transform.position = new Vector2(curPos.x, curPos.y + jumpHeight);
        }
    }
}
