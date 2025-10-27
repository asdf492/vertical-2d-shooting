using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    
    void Update()
    {
        this.transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (this.transform.position.y > 5.5f)
        {
            //Destroy(this.gameObject);
            ObjectPool.Instance.ReleasePlayerBullet0Go(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(1);
            
            //Destroy(this.gameObject);
            ObjectPool.Instance.ReleasePlayerBullet0Go(this.gameObject);
        }
    }
}
