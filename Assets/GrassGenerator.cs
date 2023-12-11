using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGenerator : MonoBehaviour
{
    public GameObject[] grassPrefabs; // Массив с префабами травы
    public float[] spawnProbabilities; // Вероятности появления для каждого префаба травы
    public int mapWidth = 10; // Ширина карты
    public int mapHeight = 10; // Высота карты
    public Transform parentObject; // Родительский объект для дочерних объектов
    public int randomSeed = 42; // Seed для генератора случайных чисел

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

        // Рассчитайте смещение центра карты
        float offsetX = -mapWidth / 2.0f + 0.5f;
        float offsetY = -mapHeight / 2.0f + 0.5f;

        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                // Выберите случайный индекс префаба травы с учетом вероятностей
                int prefabIndex = ChooseRandomGrassPrefabIndex();

                // Создайте экземпляр выбранного префаба травы в центре (x, y) с учетом смещения
                Vector3 spawnPosition = new Vector3(x + offsetX, y + offsetY, 0);
                GameObject spawnedGrass = Instantiate(grassPrefabs[prefabIndex], spawnPosition, Quaternion.identity);

                // Установите созданный объект травы как дочерний для родительского объекта
                if (parentObject != null)
                {
                    spawnedGrass.transform.SetParent(parentObject);
                }

                // Активируйте созданный объект травы
                spawnedGrass.SetActive(true);
            }
        }
    }

    // Выбор случайного индекса префаба травы с учетом вероятностей
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

        // Вернуть последний префаб травы, если что-то пошло не так
        return spawnProbabilities.Length - 1;
    }
}
