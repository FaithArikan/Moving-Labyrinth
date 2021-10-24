using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleCollider : MonoBehaviour
{
    public Text youLostText;

    private void Awake()
    {
        youLostText.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            youLostText.enabled = true;
            Debug.Log("You Lost");

            PlayerController.Instance.CancelInvoke();
        }
    }
}
