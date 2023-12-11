using UnityEngine;

public class MapDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 initialPosition;

    public Transform objectToDrag; // Объект для перетаскивания
    public Vector3 minPosition;
    public Vector3 maxPosition;
    public float zoomSpeed = 1.0f; // Скорость приближения/отдаления камеры
    public float minZoom = 2.0f; // Минимальный зум
    public float maxZoom = 10.0f; // Максимальный зум

    private void Start()
    {
        if (objectToDrag == null)
        {
            objectToDrag = transform; // Если объект для перетаскивания не назначен, используем текущий объект
        }

        initialPosition = objectToDrag.position;
    }

    private void OnMouseDown()
    {
        offset = objectToDrag.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, objectToDrag.position.z));
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, objectToDrag.position.z));
            objectToDrag.position = new Vector3(newPosition.x, newPosition.y, initialPosition.z) + offset;

            // Ограничения на позицию объекта
            objectToDrag.position = new Vector3(
                Mathf.Clamp(objectToDrag.position.x, minPosition.x, maxPosition.x),
                Mathf.Clamp(objectToDrag.position.y, minPosition.y, maxPosition.y),
                Mathf.Clamp(objectToDrag.position.z, minPosition.z, maxPosition.z)
            );
        }

        // Приближение/отдаление камеры с использованием колеса мыши
        float zoomAmount = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - zoomAmount, minZoom, maxZoom);
    }
}
