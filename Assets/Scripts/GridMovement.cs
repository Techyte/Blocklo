using System.Collections;
using UnityEngine;
using TMPro;

public class GridMovement : MonoBehaviour
{
    public bool isMoving;
    public bool canMove = true;
    private Vector3 orignPos, targetPos;
    private float timeToMove = 0.2f;
    public AudioSource jump;

    public TextMeshProUGUI scoreDisplay;

    public TouchReporter up, down, left, right;

    void Update()
    {
        /*
        if (right.isTouched || Input.GetKey(KeyCode.W) && !isMoving && canMove)
        {
            StartCoroutine(MovePlayer(Vector3.up));
        }

        if (left.isTouched || Input.GetKey(KeyCode.A) && !isMoving && canMove)
        {
            StartCoroutine(MovePlayer(Vector3.left));
        }

        if (down.isTouched || Input.GetKey(KeyCode.S) && !isMoving && canMove)
        {
            StartCoroutine(MovePlayer(Vector3.down));
        }

        if (up.isTouched || Input.GetKey(KeyCode.D) && !isMoving && canMove)
        {
            StartCoroutine(MovePlayer(Vector3.right));
        }
        */

        if (right.isTouched && !isMoving && canMove)
        {
            StartCoroutine(MovePlayer(Vector3.up));
        }else if(Input.GetKey(KeyCode.W) && !isMoving && canMove)
        {
            StartCoroutine(MovePlayer(Vector3.up));
        }

        if (left.isTouched && !isMoving && canMove)
        {
            StartCoroutine(MovePlayer(Vector3.left));
        }
        else if (Input.GetKey(KeyCode.A) && !isMoving && canMove)
        {
            StartCoroutine(MovePlayer(Vector3.left));
        }

        if (down.isTouched && !isMoving && canMove)
        {
            StartCoroutine(MovePlayer(Vector3.down));
        }
        else if (Input.GetKey(KeyCode.S) && !isMoving && canMove)
        {
            StartCoroutine(MovePlayer(Vector3.down));
        }

        if (up.isTouched && !isMoving && canMove)
        {
            StartCoroutine(MovePlayer(Vector3.right));
        }
        else if (Input.GetKey(KeyCode.D) && !isMoving && canMove)
        {
            StartCoroutine(MovePlayer(Vector3.right));
        }
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;
        jump.Play();

        float elapsedTime = 0;

        orignPos = transform.position;
        targetPos = orignPos + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(orignPos, targetPos, elapsedTime / timeToMove);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }
}
