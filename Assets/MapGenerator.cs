using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] prefabArray; // ������ � ���������
    public int mapWidth = 10; // ������ �����
    public int mapHeight = 10; // ������ �����
    public Transform parentObject; // ������������ ������ ��� �������� ��������

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        // ����������� �������� ������ �����
        float offsetX = -mapWidth / 2.0f + 0.5f;
        float offsetY = -mapHeight / 2.0f + 0.5f;

        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                // �������� ��������� ������ �� �������
                GameObject selectedPrefab = prefabArray[Random.Range(0, prefabArray.Length)];

                // �������� ��������� ���������� ������� � ������ (x, y) � ������ ��������
                Vector3 spawnPosition = new Vector3(x + offsetX, y + offsetY, 0);
                GameObject spawnedObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

                // ���������� ��������� ������ ��� �������� ��� ������������� �������
                if (parentObject != null)
                {
                    spawnedObject.transform.SetParent(parentObject);
                }

                // ����������� ��������� ������
                spawnedObject.SetActive(true);
            }
        }
    }
}
