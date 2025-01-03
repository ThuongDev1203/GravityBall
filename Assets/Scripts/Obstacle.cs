using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameController gameController; // Đối tượng GameController

    void Start()
    {
        gameController = FindObjectOfType<GameController>(); // Tìm đối tượng GameController
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Kiểm tra nếu nhân vật va chạm
        {
            gameController.GameOver(); // Kết thúc game
        }
    }
}
