using UnityEngine;

public class HippoController : MonoBehaviour
{
    public float speed = .1f;
    public float jumpHeight = .5f;
    public float acceleration = 3f;
    public float deceleration = 12f;

    float horizontalVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        if (Input.GetKey(KeyCode.RightArrow))
            targetVelocity = speed;
        if (Input.GetKey(KeyCode.LeftArrow))
            targetVelocity = -speed;
        float rate = (Mathf.Abs(targetVelocity) > 0.01f) ? acceleration : deceleration;
        horizontalVelocity = Mathf.MoveTowards(horizontalVelocity, targetVelocity, rate * Time.deltaTime);
        Vector2 curPos = gameObject.transform.position;
        gameObject.transform.position = new Vector2(curPos.x + horizontalVelocity * Time.deltaTime, curPos.y);
        if (Input.GetKey(KeyCode.Space))
        {
            curPos = gameObject.transform.position;
            gameObject.transform.position = new Vector2(curPos.x, curPos.y + jumpHeight);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            curPos = gameObject.transform.position;
            gameObject.transform.position = new Vector2(curPos.x, curPos.y - jumpHeight);
        }
    }
}
