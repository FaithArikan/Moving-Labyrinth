using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    public Transform movePoint;
    [SerializeField] Transform startPoint;
    public float moveSpeed = 5f;
    public float time = 1f;

    public Text moveableText;

    public bool allowMove = false;

    public LayerMask whatStopMovement;

    void Start()
    {
        Instance = this;
        transform.position = startPoint.position;
        movePoint.parent = null;
        moveableText.enabled = true;

        InvokeRepeating("Switch", time, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        moveableText.enabled = false;

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f && allowMove)
        {
            moveableText.enabled = true;

            if (Mathf.Abs(horizontalInput) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(horizontalInput, 0f, 0f), .2f, whatStopMovement))
                {
                    movePoint.position += new Vector3(horizontalInput, 0, 0);
                    allowMove = false;
                }
            }
            else if (Mathf.Abs(verticalInput) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, verticalInput, 0f), .2f, whatStopMovement))
                {
                    movePoint.position += new Vector3(0, verticalInput, 0);
                    allowMove = false;
                }
            }
        }
    }
    public void Switch()
    {
        allowMove = !allowMove;
    }
}
