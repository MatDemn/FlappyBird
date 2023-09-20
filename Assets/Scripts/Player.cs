using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Action onFlapEvent;

    [SerializeField]
    Rigidbody2D rBody;

    [SerializeField]
    float jumpSpeed;

    [SerializeField]
    Animator animatorComponent;

    float rotateAmount = 2f;

    bool canMove;

    [SerializeField]
    Collider2D birdCollider;

    Coroutine _swayCoroutine;

    [SerializeField]
    float swayAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        if(Input.GetAxis("Fire1") > 0)
        {
            // jump
            if(canMove)
            {
                rBody.velocity = new Vector2(rBody.velocity.x, jumpSpeed);
                transform.Rotate(Vector3.forward * rotateAmount * 180f * Time.deltaTime);
            }
            animatorComponent.SetBool("Flying", true);
            onFlapEvent?.Invoke();
        }
        else
        {
            animatorComponent.SetBool("Flying", false);
            if(rBody.velocity.y < 0)
            {
                transform.Rotate(-Vector3.forward * rotateAmount * 40f * Time.deltaTime);
            }
                
        }
        Vector3 tempEulerEngles = transform.eulerAngles;

        tempEulerEngles.z = ((tempEulerEngles.z + 540)%360)-180;
        if(Mathf.Abs(tempEulerEngles.z) > 30)
        {
            tempEulerEngles.z = 30 * Mathf.Sign(tempEulerEngles.z);
        }
        transform.eulerAngles = tempEulerEngles;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canMove = false;
        birdCollider.enabled = false;
        rBody.velocity = Vector3.zero;
        rBody.AddForce(Vector3.down * 15f);
        GManager.Instance.GameOver();
    }

    public void RunGame()
    {
        rBody.simulated = true;
        canMove = true;
        //rBody.velocity = new Vector2(2, 0);
    }

    public void StartPlayerSway()
    {
        //_swayCoroutine = StartCoroutine();
    }

    public void StopPlayerSway()
    {

    }

    IEnumerator PlayerSway()
    {
        float swayMax = transform.position.y + swayAmount;
        float swayMin = transform.position.y - swayAmount;
        while (true)
        {
            
            yield return null;
        }
    }
}
