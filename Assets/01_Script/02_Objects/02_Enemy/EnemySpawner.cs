using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Queue<EnemyBody> _enemyBodyQueue;
    private Transform _offScreeanPoition;

    public void Initialize()
    {
        _offScreeanPoition = transform.GetChild(0);

        int count = transform.GetChild(1).childCount;

        _enemyBodyQueue = new Queue<EnemyBody>();

        for (int i = 0; i < count; i++)
        {
            EnemyBody enemy = transform.GetChild(1).GetChild(i).GetComponent<EnemyBody>();

            enemy.Initialize();
            
            enemy.transform.position = _offScreeanPoition.position;

            _enemyBodyQueue.Enqueue(enemy);

        }
    }


    public List<EnemyBody> SpawnEnemy(int count)
    {
        List<EnemyBody> list = new List<EnemyBody>();

        if (count > _enemyBodyQueue.Count) 
        {
            count = _enemyBodyQueue.Count;
        }

        for (int i = 0; i < count; i++) 
        {
            float x = Random.Range(-8.0f, 8.0f);
            float y = Random.Range(6.0f, 10.0f);
            float z = 0;

            Vector3 pop = new Vector3(x,y,z);

            EnemyBody temp =  _enemyBodyQueue.Dequeue();

            temp.transform.position = pop;

            temp.gameObject.SetActive(true);

            list.Add(temp);
        }

        return list;
    }

    public void PutEnemyBackToSleep(EnemyBody enemy)
    {
        enemy.RemoveObject();

        enemy.transform.position = _offScreeanPoition.position;

        _enemyBodyQueue.Enqueue(enemy);
    }
}
