using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject startUI; // UI Start Game
    public GameObject gameOverUI; // UI Game Over

    void Start()
    {
        // Dừng toàn bộ game (vật lý, animation, chuyển động, v.v.)
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        // Ẩn UI Start Game
        startUI.SetActive(false);
        Time.timeScale = 1; // Bắt đầu game
    }

    public void GameOver()
    {
        // Hiển thị UI Game Over
        gameOverUI.SetActive(true);
        Time.timeScale = 0; // Dừng game
    }
}
