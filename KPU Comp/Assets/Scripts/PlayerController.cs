using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Animator playeranimator;
    private Rigidbody2D playerrb;

    public float moveSpeed = 2f;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        playeranimator = gameObject.GetComponent<Animator>();
        playerrb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //testing only
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        playeranimator.SetFloat("Horizontal", movement.x);
        playeranimator.SetFloat("Vertical", movement.y);
        playeranimator.SetFloat("Speed", movement.sqrMagnitude);

    }

    public void FixedUpdate()
    {
        playerrb.MovePosition(playerrb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
