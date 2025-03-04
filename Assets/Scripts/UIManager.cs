using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject startUI; // UI Start Game
    public GameObject gameOverUI; // UI Game Over
    AudioManager audioManager; // AudioManager để phát âm thanh

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>(); // Tìm AudioManager trong Scene
    }
    void Start()
    {
        Time.timeScale = 0; // Dừng toàn bộ game (vật lý, animation, chuyển động, v.v.)
    }

    public void StartGame()
    {
        startUI.SetActive(false); // Ẩn UI Start Game
        Time.timeScale = 1; // Bắt đầu game
        audioManager.PlayBackgroundMusic(); // Phát nhạc nền
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true); // Hiển thị UI Game Over
        Time.timeScale = 0; // Dừng game

        //tắt nhạc nền
        audioManager.StopBackgroundMusic();

        // Cập nhật điểm BestScore khi trò chơi kết thúc
        if (GameManager.Instance != null)
        {
            GameManager.Instance.EndGame();
        }
    }

    public void Home()
    {
        SceneManager.LoadScene("MainGame");
    }
}