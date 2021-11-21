using Managers;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 pos;

    [SerializeField] private int score;
    [SerializeField] private float speed = 5f;

    private void FixedUpdate() 
    {
        pos = this.transform.position;
        pos.x -= speed * Time.deltaTime;
        this.transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            ScoreManager.Instance.score += score;
            Destroy(this.gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}