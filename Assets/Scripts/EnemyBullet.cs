using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 1;
    private Vector3 dir;

    public void Init(Vector3 dir)
    {
        this.dir = dir;

        //Debug.Log("Init");
        //DrawArrow.ForDebug2D(this.transform.position, dir,2000,Color.red);
    }
    
    void Update()
    {
        // 콘솔창에 Error Pause를 누르면 디버그창이 뜰 때 멈춤
        //Debug.LogError("Update");
        transform.Translate(dir.normalized * speed * Time.deltaTime);
        if (this.transform.position.y > 5.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
