using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public List<EnemySO> spawnPool = new List<EnemySO>();

    [ContextMenu("Spawn Enemy")]
    public void Spawn()
    {
        //Choose a spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        //Choose an enemy
        EnemySO enemyToSpawn = spawnPool[Random.Range(0, spawnPool.Count)];

        //Set initial enemy stats
        GameObject tmp = Instantiate(enemyToSpawn.prefab, spawnPoint.position, Quaternion.identity);
        Enemy e = tmp.GetComponent<Enemy>();
        e.HP = enemyToSpawn.HP;
        e.ATK = enemyToSpawn.ATK;
        e.DEF = enemyToSpawn.DEF;
    }

    public void Spawn(EnemySO enemy, int hp)
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject tmp = Instantiate(enemy.prefab, spawnPoint.position, Quaternion.identity);
        Enemy e = tmp.GetComponent<Enemy>();
        e.HP = hp;
        e.DEF = enemy.DEF;
        e.ATK = enemy.ATK;
    }
}
