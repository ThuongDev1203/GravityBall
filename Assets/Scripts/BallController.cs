using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed = 20f;      // Tốc độ di chuyển
    private Rigidbody2D rb;          // RigidBody2D của quả bóng
    private Vector2 moveDirection;  // Hướng di chuyển

    [SerializeField] private GameObject leftBoundary;  // GameObject giới hạn bên trái
    [SerializeField] private GameObject rightBoundary; // GameObject giới hạn bên phải

    private bool isMoving = false;  // Kiểm tra xem quả bóng có đang di chuyển không
    private Vector2 targetPosition; // Vị trí mục tiêu quả bóng cần di chuyển tới

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Lấy RigidBody2D của quả bóng

        // Kiểm tra nếu các đối tượng giới hạn chưa được gán
        if (leftBoundary == null || rightBoundary == null)
        {
            Debug.LogError("Các giới hạn chưa được gán trong Inspector!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Kiểm tra các giới hạn đã được gán chưa
        if (leftBoundary == null || rightBoundary == null)
        {
            return;  // Nếu chưa gán, không tiếp tục thực thi các thao tác bên dưới
        }

        // Nếu người chơi nhấn vào màn hình
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);  // Lấy vị trí của chuột
            touchPosition.z = 0;

            // Nếu người chơi nhấn bên phải quả bóng
            if (touchPosition.x > transform.position.x)
            {
                targetPosition = rightBoundary.transform.position; // Đặt mục tiêu là giới hạn bên phải
                isMoving = true; // Bắt đầu di chuyển
            }
            // Nếu người chơi nhấn bên trái quả bóng
            else
            {
                targetPosition = leftBoundary.transform.position; // Đặt mục tiêu là giới hạn bên trái
                isMoving = true; // Bắt đầu di chuyển
            }
        }

        // Nếu đang di chuyển, di chuyển quả bóng về phía mục tiêu
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);  // Di chuyển quả bóng về phía mục tiêu

            // Sử dụng Vector2.Distance để kiểm tra xem quả bóng đã gần đến mục tiêu chưa
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)  // Điều chỉnh giá trị 0.1f nếu cần thiết
            {
                isMoving = false;  // Dừng di chuyển
            }
        }
    }
}
