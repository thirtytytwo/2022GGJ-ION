using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    //Self
    Animator playerAnim;
    public Rigidbody2D playerRig;
    public PlayerType type;
    //ItemParent
    public Transform parent;
    //Item
    public Transform item;
    //Scene
    public int playerCurrentState;
    public Vector3[] rebornPoint;

    [Header("Action")]
    public float speed;
    public float jumpForce = 20f;
    public float fallMulti = 2.5f;

    [Header("Single")]
    public bool isOnGround;
    public bool isCatched;
    public bool canMove;

    [Header("AboutSingle")]
    public LayerMask groundLayer;
    public Vector2 groundCheckOffset;
    public float groundCheckRadius;
    public Vector3 rayOffset;

    private void Start()
    {
        print(GameManager.instance.current);
        transform.position = rebornPoint[GameManager.instance.current];
        //instantiate components
        playerRig = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        parent = transform.GetChild(0);
        type = PlayerType.Fire;
        canMove = true;
    }

    private void Update()
    {
        //Check
        isOnGround = Physics2D.OverlapCircle((Vector2)transform.position + groundCheckOffset, groundCheckRadius, groundLayer);
        if (isOnGround)
        {
            canMove = true;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameManager.instance.PlayerDie();
        }
        #region ChangeType
        if (Input.GetButtonDown("Change"))
        {
            if(type == PlayerType.Fire)
            {
                AudioManager.instance.ChangeL();
                playerAnim.SetBool("FtoL", true);
                type = PlayerType.lightning;
            }
            else if(type == PlayerType.lightning)
            {
                AudioManager.instance.ChangeF();
                playerAnim.SetBool("FtoL", false);
                type = PlayerType.Fire;
            }
        }
        #endregion
        #region Action
        Movement();
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if (playerRig.velocity.y < 0)
        {
            playerRig.velocity += Vector2.up * Physics2D.gravity.y * (fallMulti - 1) * Time.deltaTime;
        }
        if (Input.GetButtonDown("Catch") && !isCatched)
        {
            CatchItem();
        }
        else if(Input.GetButtonDown("Catch") && isCatched)
        {
            ThrowItem();
        }
        #endregion
    }

    private void Movement()
    {
        if (!canMove)
        {
            return;
        }
        print(Input.GetAxis("Horizontal"));
        playerRig.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRig.velocity.y);
        if(Input.GetAxisRaw("Horizontal") == 1)
        {
            AudioManager.instance.PlayWakeStep();
            transform.rotation = new Quaternion(0, 0, 0, 0);
            rayOffset = new Vector3(1f, 0, 0);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            AudioManager.instance.PlayWakeStep();
            transform.rotation = new Quaternion(0, 180, 0, 0);
            rayOffset = new Vector3(-1f, 0, 0);
        }
    }

    private void Jump()
    {
        if (!isOnGround)
        {
            return;
        }
        AudioManager.instance.PlayJumpStep();
        playerRig.velocity = new Vector2(playerRig.velocity.x, 0);
        playerRig.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
    }

    private void CatchItem()
    {
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + (Vector2)rayOffset, (Vector2)transform.right, 3f);
        if (hit && hit.transform.CompareTag("Item")){
            AudioManager.instance.CatchAudio();
            isCatched = true;
            item = hit.transform;
            hit.transform.GetComponent<Item>().Catched(parent);
            hit.transform.GetComponent<Item>().isCatched = true;
        }
    }

    private void ThrowItem()
    {
        AudioManager.instance.ThrowAudio();
        isCatched = false;
        item.GetComponent<Item>().isCatched = false;
        item.GetComponent<Item>().isThrow = true;
        item.GetComponent<Item>().Throw();
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere((Vector2)transform.position + groundCheckOffset, groundCheckRadius);
        Ray ray = new Ray(transform.position + rayOffset, transform.right); ;
        Gizmos.DrawRay(ray);
    }

    [SerializeField]
    public enum PlayerType
    {
        Fire = 0,
        lightning = 1
    }
}
