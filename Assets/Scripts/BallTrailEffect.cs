using UnityEngine;

public class BallTrailEffect : MonoBehaviour
{
    public TrailRenderer trailRenderer;       // Tham chiếu đến Trail Renderer
    public ParticleSystem particle;    // Tham chiếu đến Particle System
    private Rigidbody2D rb;                  // Rigidbody của bóng

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Đảm bảo Trail Renderer và Particle System đã được tham chiếu
        if (trailRenderer == null) trailRenderer = GetComponent<TrailRenderer>();
        if (particle == null) particle = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        // Kiểm tra tốc độ bóng
        if (rb.velocity.magnitude > 0.1f)
        {
            // Khi bóng di chuyển
            if (!trailRenderer.emitting)
            {
                trailRenderer.emitting = true; // Bật Trail Renderer
            }
            if (particle.isPlaying)
            {
                particle.Stop(); // Tắt Particle System
            }
        }
        else
        {
            // Khi bóng đứng yên
            if (trailRenderer.emitting)
            {
                trailRenderer.emitting = false; // Tắt Trail Renderer
            }
            if (!particle.isPlaying)
            {
                particle.Play(); // Bật Particle System
            }
        }
    }
}
