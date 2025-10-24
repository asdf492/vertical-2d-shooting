using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Animator ani;
    public GameObject bullet;
    public GameObject boom;
    public Transform shotPoint;
    public Transform boomPoint;
    
    public int life = 3;
    public Action onGameOver;
    public Action onResetPosition;

    private float delta = 0;
    private float span = 0.1f;
    private float boomDelta = 0;
    private float boomSpan = 9f;
    private bool isInvinciblility = false;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Shoot();
        Reload();
        Boom();
    }

    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        //Debug.Log(x + " 0 " + y);

        Vector2 dir = new Vector2(x, y).normalized;
        //Debug.Log(dir);

        ani.SetInteger("Turn", Convert.ToInt32(x));
        
        // if (x == 0 && y == 0)
        // {
        //     ani.SetInteger("Turn", 0);
        // }
        // else if (x == -1)
        // {
        //     ani.SetInteger("Turn", 1);
        // }
        // else if (x == 1)
        // {
        //     ani.SetInteger("Turn", 2);
        // }
        
        transform.Translate(dir * speed * Time.deltaTime);
        
        float clampX = Mathf.Clamp(this.transform.position.x, -2.31f, 2.31f);
        float clampY = Mathf.Clamp(this.transform.position.y, -4.5f, 4.5f);
        this.transform.position = new Vector3(clampX, clampY, this.transform.position.z);
    }

    public void Shoot()
    {
        if (!Input.GetButton("Fire1"))
            return;

        if (delta < span)
            return;
        
        Instantiate(bullet, shotPoint.position, shotPoint.rotation);
        
        delta = 0;
    }

    public void Reload()
    {
        delta += Time.deltaTime;
        boomDelta += Time.deltaTime;
    }

    public void Boom()
    {
        if (boomSpan == 9)
        {
            boomSpan = 0;
        }
        
        if (!Input.GetButton("Fire2"))
            return;
        
        if (boomDelta < boomSpan)
            return;
        
        Instantiate(boom, boomPoint.position, boomPoint.rotation);

        boomDelta = 0;

        if (boomSpan == 0)
        {
            boomSpan = 10f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isInvinciblility)
            return;
        
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet"))
        {
            this.life -= 1;
            
            Debug.Log($"===> life : {this.life} <===");
    
            if (this.life < 0)
            {
                Debug.Log("==== GameOver ====");
                onGameOver();
            }
            else
            {
                Invoke("ResetPosition", 1f);
            }
            
            this.gameObject.SetActive(false);
            
            if (other.gameObject.CompareTag("EnemyBullet"))
            {
                Destroy(other.gameObject);
                Debug.Log("적 총알 파괴됨");
            }
        }
    }
    
    private void ResetPosition()
    {
        this.transform.position = new Vector3(0, -3, 0);
        this.gameObject.SetActive(true);
    
        onResetPosition();
    }
    
    private float deltaInvincibility = 0;
    
    public IEnumerator Invincibility()
    {
        isInvinciblility = true;
        Debug.Log("무적 상태 시작");
    
        while (true)
        {
            deltaInvincibility += Time.deltaTime;
            
            gameObject.SetActive(!gameObject.activeSelf);
    
            if (deltaInvincibility >= 0.5f)
            {
                deltaInvincibility = 0;
                break;
            }
            
            yield return new WaitForSeconds(0.1f);
        }
        
        Debug.Log("무적 상태 종료");
        isInvinciblility = false;
        gameObject.SetActive(true);
    }
}
