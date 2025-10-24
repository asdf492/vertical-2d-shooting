using UnityEngine;
using TMPro;

public class UIGame : MonoBehaviour
{
    public GameObject[] livesGo;
    public TMP_Text scoreText;
    
    void Start()
    {
        
    }

    public void UpdateLivesGo()
    {
        // 생명력이 3일경우 0, 1, 2 보여준다
        // 생명력이 2일경우 0, 1 보여준다
        // 생명력이 1일경우 0 보여준다
        // 생명력이 0일경우 안 보여준다
    }

    public void UpdateScoreText()
    {
        
    }
}
