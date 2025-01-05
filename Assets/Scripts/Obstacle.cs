using UnityEngine;

public class Obstacle : MonoBehaviour
{
    UIManager uIManager; // Đối tượng UIManager

    void Start()
    {
        uIManager = FindObjectOfType<UIManager>(); // Tìm đối tượng UIManager
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) // Kiểm tra nếu nhân vật va chạm
        {
            uIManager.GameOver(); // Kết thúc game
        }
    }
}
