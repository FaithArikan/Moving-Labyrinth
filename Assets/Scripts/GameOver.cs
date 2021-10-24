using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text gameOverText;
    private void Awake()
    {
        gameOverText.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameOverText.enabled = true;
            Debug.Log("Game Over");

            PlayerController.Instance.CancelInvoke();
        }
    }
}
