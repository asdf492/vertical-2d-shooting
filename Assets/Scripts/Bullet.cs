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
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);   
        }
    }
}
