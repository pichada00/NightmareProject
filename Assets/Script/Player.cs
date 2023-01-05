using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private Transform cameraTransform;
    private Animator animator;
    private PlayerInput playerInput;
    private InputActionAsset assets;
    private bool chrouch = false;
    public bool YouOK;
    public static Move instance;

    public AudioSource audioSource;


    public Transform groundCheck;
    public bool ground = true;
    public float GroundedOffset = -0.14f;
    public float groundDistance = 0.4f;
    public float GroundedRadius = 0.5f;
    public LayerMask groundMask;
    public GameObject BP;
    public bool open;
    //public Item item;
    Inventory inventory;




    private void Start()
    {
        cameraTransform = Camera.main.transform;
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
    }


    void Update()
    {

        groundedPlayer = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 input = playerInput.actions["MOVE"].ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = move.x * cameraTransform.right + move.z * cameraTransform.forward;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);
        if (input.sqrMagnitude != 0)
        {
            if (!audioSource.isPlaying)
            {
                //SoundManager.Instance.Play(audioSource, SoundManager.Sound.PlayerWalked);
            }
        }
        if (input.sqrMagnitude == 0)
        {
            audioSource.Stop();

        }

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;

            //animator.SetFloat("walk", 1f);
        }
        /*if (playerInput.actions["Chrouch"].triggered && groundedPlayer)
        {
            if (!chrouch)
            {
                animator.SetBool("chrouch", true);
                animator.SetBool("Idle", false);
                chrouch = true;
            }
            else
            {
                animator.SetBool("chrouch", false);
                animator.SetBool("Idle", true);
                chrouch = false;
            }
        }*/
        if (Input.GetKeyDown(KeyCode.B))
        {
            OpenBP();
        }

        // Changes the height position of the player..
        /* (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }*/


        //playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        //Backpack.instance.checkItem(item);

    }

    private void CheckQuest()
    {

    }

    void walked()
    {
        if (!YouOK)
        {
            if (!audioSource.isPlaying)
            {

                //SoundManager.Instance.Play(audioSource, SoundManager.Sound.PlayerWalked);
                YouOK = false;
                Debug.Log(YouOK);
            }
            else
            {
                audioSource.Stop();
                YouOK = true;

            }
        }
    }

    void openSound()
    {

    }

    void OpenBP()
    {
        open = !open;
        BP.SetActive(open);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Option"))
        {
            Destroy(other.gameObject);
        }
    }
    /*public void Chrouch()
    {
        chrouch = true;
        if (chrouch = true)
        {
            animator.SetBool("chrouch", true);
            animator.SetBool("Idle", false);
        }
        else
        {
            animator.SetBool("chrouch", false);
            animator.SetBool("Idle", true);
            Debug.Log("Idle");
        }
        
        
    }*/
}
