using System;
using System.Collections;
using Mono.Cecil;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyType
    {
        A,
        B,
        C
    }

    public EnemyType enemyType;
    public float speed = 1;
    public int health;
    public Sprite[] sprites;
    public SpriteRenderer renderer;
    public GameObject enemyBulletPrefab;
    private Coroutine coroutine;
    private float delta = 0;
    private float span = 1;

    private Player player;
    public void Init(Player player)
    {
        this.player = player;
    }

    private void Awake()
    {
        renderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (this.transform.position.y < -5.5f)
        {
            Destroy(this.gameObject);
        }

        Fire();
    }

    public void Fire()
    {
        // if (enemyType != EnemyType.C)
        //     return;
        
        delta += Time.deltaTime;
        if (delta >= span)
        {
            CreateEnemyBullet();
            delta = 0;
        }
    }

    public void CreateEnemyBullet()//
    {
        GameObject go = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);  // Quaternion.identity : 회전 안 시키려면 작성. 회전 없음
        EnemyBullet enemyBullet = go.GetComponent<EnemyBullet>();
        Vector3 dir = player.transform.position - this.transform.position;

        enemyBullet.Init(dir);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("PlayerBullet"))
            return;
        
        TakeDamage(1);

        if (coroutine != null)
        {
            StopCoroutine(Shoted());
        }

        coroutine = StartCoroutine(Shoted());
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        
        renderer.sprite = sprites[1];
    }

    IEnumerator Shoted()  // ReturnSprite가 더 맞는듯
    {
        yield return new WaitForSeconds(0.1f);
        
        renderer.sprite = sprites[0];
        
        if (health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("적 처치");
        }
    }
}
