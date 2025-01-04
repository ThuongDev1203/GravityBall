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
        // Gọi hàm SpawnObstacle sau mỗi khoảng thời gian spawnInterval
        InvokeRepeating(nameof(SpawnObstacle), 0f, spawnInterval);
    }

    void SpawnObstacle()
    {
        float randomX = Random.Range(spawnRangeXMin, spawnRangeXMax); // Chọn ngẫu nhiên vị trí X trong phạm vi cho trước

        Vector2 spawnPosition = new Vector2(randomX, spawnYPosition); // Tạo vị trí spawn ở ngoài màn hình (Y phía trên)

        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity); // Tạo chướng ngại vật tại vị trí đã chọn

        Rigidbody2D rb = obstacle.GetComponent<Rigidbody2D>(); // Thêm động lực di chuyển xuống dưới (theo trục Y)
        if (rb != null)
        {
            rb.velocity = new Vector2(0f, -5f);  // Thay đổi giá trị này để điều chỉnh tốc độ rơi xuống
        }
    }
}
