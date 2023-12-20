using UnityEngine;

public class MapDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 dragOrigin;

    public float scrollSpeed = 2.0f; // Скорость прокрутки колесика мыши
    public float minZoom = 2.0f; // Минимальный зум
    public float maxZoom = 10.0f; // Максимальный зум
    public float maxX = 10.0f; // Максимальная дистанция перемещения по x
    public float minX = -10.0f; // Минимальная дистанция перемещения по x
    public float maxY = 10.0f; // Максимальная дистанция перемещения по y
    public float minY = -10.0f; // Минимальная дистанция перемещения по y

    private void Update()
    {
        // Приближение/отдаление камеры с использованием колеса мыши
        float zoomAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - zoomAmount, minZoom, maxZoom);

        // Перемещение камеры
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            dragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - dragOrigin;
            Vector3 newPosition = Camera.main.transform.position - new Vector3(difference.x, difference.y, 0);

            // Ограничение по дистанции
            float distanceX = Mathf.Clamp(newPosition.x, minX, maxX);
            float distanceY = Mathf.Clamp(newPosition.y, minY, maxY);

            Camera.main.transform.position = new Vector3(distanceX, distanceY, Camera.main.transform.position.z);
        }
    }
}
