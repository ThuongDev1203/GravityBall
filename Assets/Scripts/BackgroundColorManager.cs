using UnityEngine;

public class BackgroundColorManager : MonoBehaviour
{
    public Camera mainCamera; // Camera chính
    public Color[] colors;    // Mảng màu sắc
    public float transitionSpeed = 0.1f; // Tốc độ chuyển màu
    public float colorChangeInterval = 5f; // Khoảng thời gian giữa các lần thay đổi màu

    private int currentColorIndex = 0; // Chỉ số màu hiện tại
    private float timer = 0f; // Bộ đếm thời gian

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main; // Lấy camera chính nếu chưa gán

        if (colors.Length == 0)
        {
            colors = new Color[] { Color.green, Color.red, Color.blue, Color.yellow }; // Màu mặc định nếu không có màu nào được gán
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= colorChangeInterval)
        {
            timer = 0f;
            currentColorIndex = (currentColorIndex + 1) % colors.Length; // Chuyển sang màu tiếp theo
        }

        mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, colors[currentColorIndex], transitionSpeed * Time.deltaTime);
    }
}
