using UnityEngine;

public class MapDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 dragOrigin;

    public float scrollSpeed = 2.0f; // �������� ��������� �������� ����
    public float minZoom = 2.0f; // ����������� ���
    public float maxZoom = 10.0f; // ������������ ���
    public float maxX = 10.0f; // ������������ ��������� ����������� �� x
    public float minX = -10.0f; // ����������� ��������� ����������� �� x
    public float maxY = 10.0f; // ������������ ��������� ����������� �� y
    public float minY = -10.0f; // ����������� ��������� ����������� �� y

    private void Update()
    {
        // �����������/��������� ������ � �������������� ������ ����
        float zoomAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - zoomAmount, minZoom, maxZoom);

        // ����������� ������
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

            // ����������� �� ���������
            float distanceX = Mathf.Clamp(newPosition.x, minX, maxX);
            float distanceY = Mathf.Clamp(newPosition.y, minY, maxY);

            Camera.main.transform.position = new Vector3(distanceX, distanceY, Camera.main.transform.position.z);
        }
    }
}
