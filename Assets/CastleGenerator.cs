using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleGenerator : MonoBehaviour
{
    public GameObject[] castlePrefabs; // ������ � ��������� ������
    public Vector3 playerCastlePosition = new Vector3(0, 0, 0); // ������� ��� �������� ����� ������
    public Vector3 enemyCastlePosition = new Vector3(10, 0, 0); // ������� ��� �������� ����� ����������
    public Transform gameMap; // ������ �� ������ GameMap

    void Start()
    {
        GenerateCastles();
    }

    void GenerateCastles()
    {
        if (castlePrefabs == null || castlePrefabs.Length < 2)
        {
            Debug.LogError("Castle prefabs array is not set or doesn't have enough prefabs!");
            return;
        }

        if (gameMap == null)
        {
            Debug.LogError("GameMap is not assigned!");
            return;
        }

        // ��������� ����� ������
        SpawnCastle(playerCastlePosition, castlePrefabs[0]); // �����������, ��� ����� ������ ��������� � ������ ����� �������

        // ��������� ����� ����������
        SpawnCastle(enemyCastlePosition, castlePrefabs[1]); // �����������, ��� ����� ���������� ��������� �� ������ ����� �������
    }

    // ����� ��� �������� ����� �� ��������� ������� � �������� ��� � ������� GameMap
    void SpawnCastle(Vector3 spawnPosition, GameObject castlePrefab)
    {
        if (castlePrefab == null)
        {
            Debug.LogError("Castle prefab is null!");
            return;
        }

        GameObject spawnedCastle = Instantiate(castlePrefab, spawnPosition, Quaternion.identity);

        // ��������� ��������� ������ ����� � ������� GameMap
        spawnedCastle.transform.SetParent(gameMap);

        // �� ������ �������� �������������� ���������, ���� ����������

        // ����������� ��������� �����
        spawnedCastle.SetActive(true);
    }
}
