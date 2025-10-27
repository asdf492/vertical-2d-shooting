using System;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float speed;
    public int startIndex;
    public int endIndex;
    public Transform[] sprites;

    private float viewHeight;
    private void Start()
    {
        this.viewHeight = Camera.main.orthographicSize * 2;

        // for (int i = 0; i < 10; i++)
        // {
        //     int idx = i % 3;
        // }
    }

    private void Move()
    {
        Vector3 currentPos = this.transform.position;
        Vector3 nextPos = Vector3.down * this.speed * Time.deltaTime;
        this.transform.position = currentPos + nextPos;   
    }
    
    private void Scrolling()
    {
        if (sprites[endIndex].position.y < -viewHeight)
        {
            Vector3 backSpritePos = sprites[startIndex].localPosition;
            //Vector3 frontSpritePos = sprites[endIndex].transform.localPosition;
        
            sprites[endIndex].localPosition = backSpritePos + Vector3.up * viewHeight;  // position을 사용하면 오차가 생길수도 있음. Translate 쓰는게 좋음
            
            startIndex = endIndex;
            endIndex = (startIndex + 1) % sprites.Length;
        }
        //
        // int startIndexSave = startIndex;
        // startIndex = endIndex;
        //
        // //endIndex = (startIndexSave -1 == -1) ? sprites.Length - 1 : startIndexSave - 1;
        // if (startIndexSave - 1 == -1)
        // {
        //     endIndex = sprites.Length - 1;
        // }
        // else
        // {
        //     endIndex = startIndexSave - 1;
        // }
        //
        // Debug.LogError("");
    }
    
    void Update()
    {
        Move();
        Scrolling();
    }
}
