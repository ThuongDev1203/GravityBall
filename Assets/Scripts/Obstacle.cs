using UnityEngine;

public class Obstacle : MonoBehaviour
{
    UIManager uIManager; // Đối tượng uIManager

    void Start()
    {
        uIManager = FindObjectOfType<UIManager>(); // Tìm đối tượng UIManager
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Kiểm tra nếu nhân vật va chạm
        {
            uIManager.GameOver(); // Kết thúc game
        }
    }
}
