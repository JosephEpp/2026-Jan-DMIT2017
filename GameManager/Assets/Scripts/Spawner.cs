using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public List<Enemy> activeEnemies = new List<Enemy>();

    [ContextMenu("Spawn Enemy")]
    public void Spawn(EnemyState enemy)
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject tmp = Instantiate(enemy.enemyData.prefab, spawnPoint.position, Quaternion.identity);
        Enemy e = tmp.GetComponent<Enemy>();
        e.HP = enemy.currentHP;
        e.DEF = enemy.enemyData.DEF;
        e.ATK = enemy.enemyData.ATK;
        e.enemyID = enemy.enemyID;
        activeEnemies.Add(e);
    }
}
