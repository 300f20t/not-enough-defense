using UnityEngine;

public class MapDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 initialPosition;

    public Transform objectToDrag; // Объект для перетаскивания
    public Vector3 minPosition;
    public Vector3 maxPosition;

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
    }
}
