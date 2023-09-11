using UnityEngine;

public class MapDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 initialPosition;

    public Transform objectToDrag; // ������ ��� ��������������
    public Vector3 minPosition;
    public Vector3 maxPosition;

    private void Start()
    {
        if (objectToDrag == null)
        {
            objectToDrag = transform; // ���� ������ ��� �������������� �� ��������, ���������� ������� ������
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

            // ����������� �� ������� �������
            objectToDrag.position = new Vector3(
                Mathf.Clamp(objectToDrag.position.x, minPosition.x, maxPosition.x),
                Mathf.Clamp(objectToDrag.position.y, minPosition.y, maxPosition.y),
                Mathf.Clamp(objectToDrag.position.z, minPosition.z, maxPosition.z)
            );
        }
    }
}
