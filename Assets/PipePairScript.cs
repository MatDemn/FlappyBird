using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePairScript : MonoBehaviour
{
    public int pointsAmount;

    [SerializeField]
    bool isMovableV;

    [SerializeField]
    bool isMovableH;

    [SerializeField]
    SpriteRenderer[] pairSpriteRenderers;

    [SerializeField]
    Sprite normalPipe;
    [SerializeField]
    Sprite goldPipe;

    Coroutine moveCoroutineV;
    Coroutine moveCoroutineH;

    Vector3 finalPosition;

    [SerializeField]
    float moveSpeedV;

    [SerializeField]
    float moveSpeedH;

    Vector2 _minMove = new Vector2(-1.5f, -2.5f);
    Vector2 _maxMove = new Vector2(1.5f,2f);

    public void ResetState(Vector3 position)
    {
        if (moveCoroutineV != null)
            StopCoroutine(moveCoroutineV);
        if (moveCoroutineH != null)
            StopCoroutine(moveCoroutineH);

        if (Random.Range(1, 11) == 1)
        {
            pointsAmount = 5;
            foreach (SpriteRenderer sprite in pairSpriteRenderers)
            {
                sprite.sprite = goldPipe;
            }
        }
        else
        {
            pointsAmount = 1;
            foreach (SpriteRenderer sprite in pairSpriteRenderers)
            {
                sprite.sprite = normalPipe;
            }
        }
        int randomResult = Random.Range(1, 4);
        if (randomResult == 1)
        {
            moveCoroutineV = StartCoroutine(MovePipesV());
            moveSpeedV = Random.Range(2f, 3f);
        }
        else if (randomResult == 2)
        {
            moveCoroutineH = StartCoroutine(MovePipesH());
            moveSpeedH = Random.Range(2f, 3f);
        }
        transform.position = position;
    }

    IEnumerator MovePipesV()
    {
        float shiftDone = 0f;
        while (true)
        {
            // Move Up
            while(transform.position.y < _maxMove.y)
            {
                shiftDone += moveSpeedV * Time.deltaTime;
                transform.position += Vector3.up * moveSpeedV * Time.deltaTime;
                yield return null;
            }
            //transform.position = new Vector3(transform.position.x, _maxMove.y, transform.position.z);
            yield return null;
            // Move Down
            while (transform.position.y > _minMove.y)
            {
                shiftDone -= moveSpeedV * Time.deltaTime;
                transform.position += Vector3.down * moveSpeedV * Time.deltaTime;
                yield return null;
            }
            //transform.position = new Vector3(transform.position.x, _minMove.y, transform.position.z);
            yield return null;
        }
    }

    IEnumerator MovePipesH()
    {
        float shiftDone = 0f;
        while (true)
        {
            // Move right
            while (shiftDone < _maxMove.x)
            {
                shiftDone += moveSpeedH * Time.deltaTime;
                transform.position += Vector3.right * moveSpeedH * Time.deltaTime;
                yield return null;
            }
            //transform.position = new Vector3(_maxMove.x, transform.position.y, transform.position.z);
            yield return null;
            // Move left
            while (shiftDone > _minMove.x)
            {
                shiftDone -= moveSpeedH * Time.deltaTime;
                transform.position += Vector3.left * moveSpeedH * Time.deltaTime;
                yield return null;
            }
            //transform.position = new Vector3(_minMove.x, transform.position.y, transform.position.z);
            yield return null;
        }
    }
}
