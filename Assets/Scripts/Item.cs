using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        Boom,
        Coin,
        Power
    }

    public ItemType itemType;
    public float speed = 1;

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -6f)
        {
            Destroy(this.gameObject);
        }
    }
}
