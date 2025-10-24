using System;
using System.Collections;
using UnityEngine;

public class Boom : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(End());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);   
        }
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(0.5f);
        
        Destroy(this.gameObject);
    }
}
