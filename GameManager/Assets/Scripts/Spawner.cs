using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public List<Enemy> activeEnemies = new List<Enemy>();
    public EnemyDB enemyDatabase;

    [ContextMenu("Spawn Enemy")]
    public void Spawn(int enemyID, int hp)
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        EnemySO enemySO = enemyDatabase.Get(enemyID);
        GameObject tmp = Instantiate(enemySO.prefab, spawnPoint.position, Quaternion.identity);

        Enemy e = tmp.GetComponent<Enemy>();
        e.HP = hp;
        e.DEF = enemySO.DEF;
        e.ATK = enemySO.ATK;
        e.enemyID = enemyID;
        activeEnemies.Add(e);
    }

    public void ClearEnemies()
    {
        foreach (Enemy e in activeEnemies)
        {
            Destroy(e.gameObject);
        }
        activeEnemies.Clear();
    }
}
