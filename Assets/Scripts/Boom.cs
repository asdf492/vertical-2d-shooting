using System;
using System.Collections;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public Action onFinishBoom;

    IEnumerator Start()
    {
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
