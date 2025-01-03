using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 0.01f; // Tốc độ di chuyển cố định
    public float destroyX = -10f; // Vị trí X để hủy chướng ngại vật

    void Update()
    {
        // Di chuyển chướng ngại vật sang trái
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Hủy chướng ngại vật khi ra khỏi màn hình
        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
