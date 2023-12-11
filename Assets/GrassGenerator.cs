using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGenerator : MonoBehaviour
{
    public GameObject[] grassPrefabs; // ������ � ��������� �����
    public float[] spawnProbabilities; // ����������� ��������� ��� ������� ������� �����
    public int mapWidth = 10; // ������ �����
    public int mapHeight = 10; // ������ �����
    public Transform parentObject; // ������������ ������ ��� �������� ��������
    public int randomSeed = 42; // Seed ��� ���������� ��������� �����

    void Start()
    {
        GenerateGrass();
    }

    void GenerateGrass()
    {
        Random.InitState(randomSeed);

        if (grassPrefabs == null || grassPrefabs.Length == 0)
        {
            Debug.LogError("Grass prefabs array is not set or empty!");
            return;
        }

        if (spawnProbabilities == null || spawnProbabilities.Length != grassPrefabs.Length)
        {
            Debug.LogError("Spawn probabilities are not set correctly!");
            return;
        }

        // ����������� �������� ������ �����
        float offsetX = -mapWidth / 2.0f + 0.5f;
        float offsetY = -mapHeight / 2.0f + 0.5f;

        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                // �������� ��������� ������ ������� ����� � ������ ������������
                int prefabIndex = ChooseRandomGrassPrefabIndex();

                // �������� ��������� ���������� ������� ����� � ������ (x, y) � ������ ��������
                Vector3 spawnPosition = new Vector3(x + offsetX, y + offsetY, 0);
                GameObject spawnedGrass = Instantiate(grassPrefabs[prefabIndex], spawnPosition, Quaternion.identity);

                // ���������� ��������� ������ ����� ��� �������� ��� ������������� �������
                if (parentObject != null)
                {
                    spawnedGrass.transform.SetParent(parentObject);
                }

                // ����������� ��������� ������ �����
                spawnedGrass.SetActive(true);
            }
        }
    }

    // ����� ���������� ������� ������� ����� � ������ ������������
    int ChooseRandomGrassPrefabIndex()
    {
        float totalProbability = 0f;
        float randomValue = Random.value;

        for (int i = 0; i < spawnProbabilities.Length; i++)
        {
            totalProbability += spawnProbabilities[i];

            if (randomValue <= totalProbability)
            {
                return i;
            }
        }

        // ������� ��������� ������ �����, ���� ���-�� ����� �� ���
        return spawnProbabilities.Length - 1;
    }
}
