using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;    // Prefab chướng ngại vật
    public float spawnInterval = 1f;     // Khoảng thời gian giữa các lần spawn

    // Phạm vi x mà chướng ngại vật có thể spawn
    public float spawnRangeXMin = -2f;
    public float spawnRangeXMax = 2f;
    public float spawnYPosition = 6f;   // Vị trí Y spawn nằm ngoài màn hình (phía trên)

    void Start()
    {
        // Gọi hàm SpawnObstacle liên tục
        InvokeRepeating(nameof(SpawnObstacle), 0f, spawnInterval);
    }

    void SpawnObstacle()
    {
        // Chọn ngẫu nhiên vị trí X trong phạm vi cho trước
        float randomX = Random.Range(spawnRangeXMin, spawnRangeXMax);

        // Tạo vị trí spawn ở ngoài màn hình (Y phía trên)
        Vector2 spawnPosition = new Vector2(randomX, spawnYPosition);

        // Tạo chướng ngại vật tại vị trí đã chọn
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // Thêm động lực di chuyển xuống dưới (theo trục Y)
        Rigidbody2D rb = obstacle.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(0f, -5f);  // Thay đổi giá trị này để điều chỉnh tốc độ rơi xuống
        }
    }
}
