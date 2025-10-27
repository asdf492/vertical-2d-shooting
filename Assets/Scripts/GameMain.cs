using UnityEngine;

public class GameMain : MonoBehaviour
{
    public Player player;
    public UIGame uiGame;
    public UIGameOver uiGameOver;
    public GameObject boomPrefab;
    
    void Start()
    {
        player.onHit = () =>
        {
            uiGame.UpdateLivesGo(player.life);
        };
        player.onGetBoomItem = () =>
        {
            uiGame.UpdateBoomsItemGo(player.boom);
        };
        player.onBoom = () =>
        {
            uiGame.UpdateBoomsItemGo(player.boom);
            
            GameObject boomGo = Instantiate(boomPrefab);
            Boom boom = boomGo.GetComponent<Boom>();
            boom.onFinishBoom = () =>
            {
                Destroy(boomGo);
                player.isBoom = false;
            };
        };
        
        player.onResetPosition = () =>
        {
            if (GameManager.Instance.isGameOver == false)
            {
                StartCoroutine(this.player.Invincibility());
            }
        };
        player.onGameOver = () =>
        {
            GameManager.Instance.isGameOver = true;
            uiGameOver.Show();
        };

        GameManager.Instance.onScore = () =>
        {
            uiGame.UpdateScoreText();
        };
        GameManager.Instance.onCreateEnemy = (enemy) =>
        {
            enemy.Init(player);
        };
    }
}
