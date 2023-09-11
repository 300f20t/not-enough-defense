using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] prefabArray; // Массив с префабами
    public int mapWidth = 10; // Ширина карты
    public int mapHeight = 10; // Высота карты
    public Transform parentObject; // Родительский объект для дочерних объектов

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        // Рассчитайте смещение центра карты
        float offsetX = -mapWidth / 2.0f + 0.5f;
        float offsetY = -mapHeight / 2.0f + 0.5f;

        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                // Выберите случайный префаб из массива
                GameObject selectedPrefab = prefabArray[Random.Range(0, prefabArray.Length)];

                // Создайте экземпляр выбранного префаба в центре (x, y) с учетом смещения
                Vector3 spawnPosition = new Vector3(x + offsetX, y + offsetY, 0);
                GameObject spawnedObject = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

                // Установите созданный объект как дочерний для родительского объекта
                if (parentObject != null)
                {
                    spawnedObject.transform.SetParent(parentObject);
                }

                // Активируйте созданный объект
                spawnedObject.SetActive(true);
            }
        }
    }
}
