using System;
using UnityEngine;

public class Car : MonoBehaviour
{
    public static Car Instance; 

    [SerializeField] GameObject adButton;
    [SerializeField] GameObject retryButton;
    [SerializeField] GameObject score;
    [SerializeField] GameObject destroyer;

    private void Awake()
    {
        Instance = this;    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {
            if (LevelManager.Instance.adCount == 0)
            {
                adButton.SetActive(true);
                score.SetActive(false);
                Time.timeScale = 0;
            }
            else
            {
                retryButton.SetActive(true);
                score.SetActive(false);
                Time.timeScale = 0;
            }
        }
    }

    public void Continue()
    {
        destroyer.gameObject.SetActive(true);
        adButton.SetActive(false);
        score.SetActive(true);
        Time.timeScale = 1;
        Invoke(nameof(CloseDestroyer), 1f);
    }

    private void CloseDestroyer()
    {
        destroyer.gameObject.SetActive(false);
    }
}
