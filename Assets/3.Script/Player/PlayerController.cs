using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public AudioClip deathClip;
    public AudioClip jumpClip;

    private bool isDead = false;

    private Rigidbody playerRigid;
    private Animator animator;
    private AudioSource playerAudio;
    private int jumpCount = 0;
    

    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        //���콺�� Ŭ���Ҷ����� y������ AddForce ����Ǿ� ����
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerRigid.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            transform.Rotate(new Vector3(10, 0, 0));
            jumpCount++;

            if (jumpCount >= 2)
            {
                transform.Rotate(new Vector3(-20, 0, 0));
                jumpCount = 0;
            }
        }

        //���콺�� ���� ���� �ӵ��� y���� ������ �ӵ��� �������� => �����غ��� �ʹ� ������ �������µ��� ����
        else if (Input.GetKeyUp(KeyCode.Mouse0) && playerRigid.velocity.y > 0)
        {
            playerRigid.velocity = playerRigid.velocity * 0.5f;
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Tube"))
        {
            Die();
        }
        if (coll.gameObject.CompareTag("Ground"))
        {
            Die();
        }
    }

    private void Die()
    {
        playerAudio.clip = deathClip;
        playerAudio.Play();
        playerRigid.velocity = Vector3.zero;
        isDead = true;

    }
}
