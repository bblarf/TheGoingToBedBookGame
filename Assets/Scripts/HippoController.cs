using UnityEngine;

public class HippoController : MonoBehaviour
{
    public float speed = .1f;
    public float jumpHeight = .5f;

    public float momentum = 1.1f;
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
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 curPos = gameObject.transform.position;
            Vector2 newPos = new Vector2(curPos.x + Time.deltaTime * speed * momentum, curPos.y);
            gameObject.transform.position = newPos;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 curPos = gameObject.transform.position;
            Vector2 newPos = new Vector2(curPos.x - Time.deltaTime * speed * momentum, curPos.y);
            gameObject.transform.position = newPos;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Vector2 curPos = gameObject.transform.position;
            Vector2 newPos = new Vector2(curPos.x, curPos.y + jumpHeight);
            gameObject.transform.position = newPos;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector2 curPos = gameObject.transform.position;
            Vector2 newPos = new Vector2(curPos.x, curPos.y - jumpHeight);
            gameObject.transform.position = newPos;
        }
    }
}
