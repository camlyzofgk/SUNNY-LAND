using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Biến để lưu tốc độ thị sai
    public float parallaxSpeed = 0.5f;

    // Biến để lưu vị trí ban đầu của hình ảnh
    private Vector3 originalPosition;

    // Hàm được gọi khi hình ảnh được khởi tạo
    private void Start()
    {
        // Lưu vị trí ban đầu của hình ảnh
        originalPosition = transform.position;
    }

    // Hàm được gọi mỗi khung hình
    private void Update()
    {
        // Tính toán vị trí mới của hình ảnh theo tốc độ thị sai
        Vector3 newPosition = originalPosition + Vector3.left * parallaxSpeed * Time.time;

        // Di chuyển hình ảnh đến vị trí mới
        transform.position = newPosition;
    }
}
