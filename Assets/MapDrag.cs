using UnityEngine;

public class MapDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 initialPosition;

    public Transform objectToDrag; // ������ ��� ��������������
    public Vector3 minPosition;
    public Vector3 maxPosition;
    public float zoomSpeed = 1.0f; // �������� �����������/��������� ������
    public float minZoom = 2.0f; // ����������� ���
    public float maxZoom = 10.0f; // ������������ ���

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

        // �����������/��������� ������ � �������������� ������ ����
        float zoomAmount = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - zoomAmount, minZoom, maxZoom);
    }
}
