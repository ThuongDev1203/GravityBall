using UnityEngine;

public class BackgroundColorManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Sprite Renderer để hiển thị ảnh nền
    public Color[] colors; // Mảng các màu sắc
    public float transitionSpeed = 0.1f; // Tốc độ chuyển đổi màu sắc
    public float colorChangeInterval = 5f; // Khoảng thời gian giữa các lần thay đổi màu

    private int currentColorIndex = 0; // Chỉ số của màu hiện tại
    private float timer = 0f; // Bộ đếm thời gian
    private bool transitioning = false; // Cờ kiểm tra xem có đang chuyển đổi màu không

    void Start()
    {
        // Kiểm tra Sprite Renderer đã được gán chưa
        if (spriteRenderer == null)
        {
            Debug.LogError("Chưa gán Sprite Renderer!");
            return;
        }

        // Đặt màu sắc ban đầu (giữ alpha là 1)
        Color initialColor = colors[currentColorIndex];
        initialColor.a = 1f; // Đảm bảo alpha luôn là 1
        spriteRenderer.color = initialColor;
    }

    void Update()
    {
        timer += Time.deltaTime; // Cập nhật thời gian mỗi frame

        // Khi hết thời gian đổi màu
        if (timer >= colorChangeInterval && !transitioning)
        {
            timer = 0f; // Reset bộ đếm
            StartCoroutine(CrossfadeToNextColor()); // Bắt đầu chuyển đổi màu
        }
    }

    private System.Collections.IEnumerator CrossfadeToNextColor()
    {
        transitioning = true; // Đang chuyển đổi

        // Lấy màu tiếp theo
        int nextColorIndex = (currentColorIndex + 1) % colors.Length;
        Color nextColor = colors[nextColorIndex];
        nextColor.a = 1f; // Đảm bảo alpha của màu tiếp theo là 1

        // Chuyển dần từ màu hiện tại sang màu mới
        Color currentColor = spriteRenderer.color;
        for (float t = 0f; t <= 1f; t += transitionSpeed * Time.deltaTime)
        {
            spriteRenderer.color = Color.Lerp(currentColor, nextColor, t);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f); // Đảm bảo alpha luôn là 1
            yield return null;
        }

        // Hoàn tất chuyển đổi màu
        spriteRenderer.color = nextColor;
        currentColorIndex = nextColorIndex;
        transitioning = false; // Kết thúc chuyển đổi
    }
}
