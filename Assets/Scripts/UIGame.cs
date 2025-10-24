using UnityEngine;
using TMPro;

public class UIGame : MonoBehaviour
{
    public GameObject[] livesGo;
    public GameObject[] boomsGo;
    public TMP_Text scoreText;
    
    void Start()
    {
        
    }

    public void UpdateLivesGo(int lives)
    {
        // 모두 안보여준다
        foreach(GameObject liveGo in livesGo)
            liveGo.SetActive(false);
        
        // for문으로 보여준다
        for (int i = 0; i < lives; i++)
        {
            livesGo[i].SetActive(true);
        }
        
        // 생명력이 3일경우 0, 1, 2 보여준다
        // 생명력이 2일경우 0, 1 보여준다
        // 생명력이 1일경우 0 보여준다
        // 생명력이 0일경우 안 보여준다
    }

    public void UpdateBoomsItemGo(int booms)
    {
        // 모두 안보여준다
        foreach(GameObject boomGo in boomsGo)
            boomGo.SetActive(false);
        
        // for문으로 보여준다
        for (int i = 0; i < booms; i++)
        {
            Debug.Log($"{boomsGo[i]} 활성화 됨");
            boomsGo[i].SetActive(true);
        }
        
        // booms이 3일경우 0, 1, 2 보여준다
        // booms이 2일경우 0, 1 보여준다
        // booms이 1일경우 0 보여준다
        // booms이 0일경우 안 보여준다
    }
    
    public void UpdateScoreText()
    {
        this.scoreText.text = GameManager.Instance.score.ToString();
    }
}
