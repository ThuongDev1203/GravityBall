using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObstacel : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Va chạm với: " + collision.gameObject.name); // Kiểm tra va chạm
        if (collision.gameObject.CompareTag("Obstacle")) // Kiểm tra nếu nhân vật va chạm
        {
            GameManager.Instance.AddScore(1); // Cộng điểm
            Debug.Log("Cộng điểm!");
        }
    }
}
