using UnityEngine;
using UnityEngine.SceneManagement;

public class BedDetector : MonoBehaviour
{
    [SerializeField] string winSceneName = "winScreen";
    bool won;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            TryWin();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            TryWin();
    }

    void TryWin()
    {
        if (won)
            return;
        won = true;
        SceneManager.LoadScene(winSceneName);
    }
}
