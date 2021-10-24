using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    static float[] line = {(float)-8.5, (float)-7.5, (float)-6.5, (float)-5.5, (float)-4.5, (float)-3.5, (float)-2.5, 
        (float)-1.5, (float)0.5, (float)1.5, (float)2.5, (float)3.5, (float)4.5 , (float)5.5, (float)6.5, (float)7.5, (float)8.5, 
        (float)9.5};

    static float[] column = { (float)-4.5, (float)-3.5, (float)-2.5, (float)-1.5, 
        (float)0.5, (float)1.5, (float)2.5, (float)3.5, (float)4.5 };

    public float speed = 5f;
    public Transform movePoint;
    private Vector3[] positionsArray;

    public float time = 1f;

    public LayerMask whatStopMovement;

    private void Start()
    {
        movePoint.parent = null;

        int whichLine = Random.Range(0, line.Length);
        int whichColumn = Random.Range(0, column.Length);

        movePoint.position = new Vector3(line[whichLine], column[whichColumn], 0);

        InvokeRepeating("Move", time, 1f);
    }
    private void Update()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        int someValue = Random.Range(0, 2) * 2 - 1;

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Mathf.Abs(horizontalInput) == 1f || Mathf.Abs(verticalInput) == 1f )
            {
                Vector3 normal = new Vector3(horizontalInput * someValue, verticalInput * someValue, 0);
                Vector3 aNormal = new Vector3(verticalInput * someValue, horizontalInput * someValue, 0);

                positionsArray = new Vector3[2];
                positionsArray[0] = normal;
                positionsArray[1] = aNormal;
            }
        }
    }
    public void Move()
    {
        movePoint.position += positionsArray[Random.Range(0, 2)];
    }
}
