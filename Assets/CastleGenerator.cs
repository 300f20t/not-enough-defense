using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleGenerator : MonoBehaviour
{
    public GameObject[] castlePrefabs; // Массив с префабами замков
    public Vector3 playerCastlePosition = new Vector3(0, 0, 0); // Позиция для заспавна замка игрока
    public Vector3 enemyCastlePosition = new Vector3(10, 0, 0); // Позиция для заспавна замка противника
    public Transform gameMap; // Ссылка на объект GameMap

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

        // Заспавним замок игрока
        SpawnCastle(playerCastlePosition, castlePrefabs[0]); // Предположим, что замок игрока находится в первом слоте массива

        // Заспавним замок противника
        SpawnCastle(enemyCastlePosition, castlePrefabs[1]); // Предположим, что замок противника находится во втором слоте массива
    }

    // Метод для заспавна замка на указанной позиции и привязки его к объекту GameMap
    void SpawnCastle(Vector3 spawnPosition, GameObject castlePrefab)
    {
        if (castlePrefab == null)
        {
            Debug.LogError("Castle prefab is null!");
            return;
        }

        GameObject spawnedCastle = Instantiate(castlePrefab, spawnPosition, Quaternion.identity);

        // Привязать созданный объект замка к объекту GameMap
        spawnedCastle.transform.SetParent(gameMap);

        // Вы можете добавить дополнительные настройки, если необходимо

        // Активируйте созданный замок
        spawnedCastle.SetActive(true);
    }
}
