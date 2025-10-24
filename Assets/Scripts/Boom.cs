using System;
using System.Collections;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public Action onFinishBoom;

    IEnumerator Start()
    {
        Enemy[] enemies = GameObject.FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        EnemyBullet[] enemyBullets= GameObject.FindObjectsByType<EnemyBullet>(FindObjectsSortMode.None);

        for (int i = 0; i < enemies.Length; i++)
        {
            Enemy enemy = enemies[i];
            //enemy.TakeDamage(1000);
            Destroy(enemy.gameObject);
        }

        for (int i = 0; i < enemyBullets.Length; i++)
        {
            EnemyBullet enemyBullet = enemyBullets[i];
            Destroy(enemyBullet.gameObject);
        }
        
        yield return new WaitForSeconds(1f);
        
        
        onFinishBoom?.Invoke();
        // if (onFinishBoom != null)
        // {
        //     onFinishBoom();  위에거랑 같은 코드
        // }
    }

    public void Init()
    {
        
    }
}
