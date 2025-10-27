using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // static 인스턴스로 접근하지 않고 형식으로 접근함
    public static ObjectPool Instance;
    
    public GameObject playerBullet0Prefab;
    public GameObject playerBullet1Prefab;
    public GameObject playerBullet2Prefab;
    
    private List<GameObject> playerBullet0List = new List<GameObject>();
    private List<GameObject> playerBullet1List = new List<GameObject>();
    private List<GameObject> playerBullet2List = new List<GameObject>();

    private void Awake()
    {
        Instance = this;

        Generate();
    }

    void Generate()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject playerBullet0Go = Instantiate(playerBullet0Prefab, this.transform);
            playerBullet0Go.SetActive((false));
            playerBullet0List.Add(playerBullet0Go);
            
            // GameObject playerBullet1Go = Instantiate(playerBullet1Prefab, this.transform);
            // playerBullet1Go.SetActive((false));
            // playerBullet1List.Add(playerBullet1Go);
            //
            // GameObject playerBullet2Go = Instantiate(playerBullet2Prefab, this.transform);
            // playerBullet2Go.SetActive((false));
            // playerBullet2List.Add(playerBullet2Go);
        }
    }

    public GameObject GetPlayerBullet0()
    {
        GameObject foundPlayerBullet0Go = null;
        bool isAvailableBullet0 = false;
        
        // playerBullet0List 를 순회하면서 사용 가능한 총알이 있는지 검사
        for (int i = 0; i < playerBullet0List.Count; i++)
        {
            GameObject playerBullet0Go = playerBullet0List[i];
            if (!playerBullet0Go.activeSelf)
            {
                isAvailableBullet0 = true;
                break;
            }
        }
        
        // 만약에 사용할수있는 총알이 없다면 만들어서 playerBullet0List 에 추가 한다
        if (isAvailableBullet0 == false)
        {
            GameObject go = Instantiate(playerBullet0Prefab, this.transform);
            go.SetActive(false);
            playerBullet0List.Add(go);
        }
        
        // playerBullet0List 를 순회하면서 사용 가능한 총알이 있는지 검사
        for (int i = 0; i < playerBullet0List.Count; i++)
        {
            GameObject playerBullet0Go = playerBullet0List[i];
            if (!playerBullet0Go.activeSelf)
            {
                playerBullet0Go.SetActive(true);
                return playerBullet0Go;
            }
        }
        
        // for (int i = 0; i < playerBullet0List.Count; i++)
        // {
        //     GameObject playerBullet0Go = playerBullet0List[i];
        //     if (!playerBullet0Go.activeSelf)
        //     {
        //         foundPlayerBullet0Go =  playerBullet0Go;
        //         foundPlayerBullet0Go.SetActive(true);
        //     }
        // }

        if (foundPlayerBullet0Go == null)
        {
            foundPlayerBullet0Go = Instantiate(playerBullet0Prefab, this.transform);
            //foundPlayerBullet0Go.transform.SetParent(this.transform);
            foundPlayerBullet0Go.SetActive(true);
            playerBullet0List.Add(foundPlayerBullet0Go);
        }

        return foundPlayerBullet0Go;
    }

    public void ReleasePlayerBullet0Go(GameObject playerBullet0Go)
    {
        playerBullet0Go.SetActive(false);
        playerBullet0Go.transform.localPosition = Vector3.zero;
    }
    
    void Start()
    {
        
    }
}
