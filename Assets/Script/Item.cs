using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Item : MonoBehaviour
{
    public ItemType type;
    Rigidbody2D itemRig;
    BoxCollider2D col;

    [Header("Player")]
    public PlayerController player;

    [Header("Target")]
    public ItemType target = ItemType.None;
    public GameObject[] InstantiateObj;
    public GameObject targetObj;

    [Header("Single")]
    public bool isCatched;
    public bool isThrow;
    public bool isNeedToReactionWithAnother;
    public bool isNeedToReactionWithPlayer;

    [Header("Action")]
    public Vector2 force = new Vector2(5, 3);

    [Header("Check")]
    public float radius = 3f;
    public LayerMask layer;

    private void Start()
    {
        itemRig = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        target = ItemType.None;
        SetType();
    }

    private void Update()
    {
        if (itemRig.velocity.y < 0)
        {
            itemRig.velocity += Vector2.up * Physics2D.gravity.y * (2.5f - 1) * Time.deltaTime;
        }
        if (isNeedToReactionWithAnother)
        {
            ReactionWithAnotherItem();
        }
        if (isNeedToReactionWithPlayer)
        {
            ReactionWithPlayer();
        }
    }

    public void Catched(Transform parent)
    {
        transform.SetParent(null);
        isThrow = false;
        isNeedToReactionWithAnother = false;
        col.enabled = false;
        itemRig.bodyType = RigidbodyType2D.Kinematic;
        transform.SetParent(parent);;
        transform.localPosition = new Vector3(0, 0, 0);//更改为在固定位置生成
        transform.rotation = parent.parent.transform.rotation;
      
        isNeedToReactionWithPlayer = true;
    }

    public virtual void Throw()
    {
        col.enabled = true;
        isNeedToReactionWithPlayer = false;
        itemRig.bodyType = RigidbodyType2D.Dynamic;
        itemRig.AddForce(new Vector2(force.x * (transform.right == new Vector3(1, 0, 0) ? 1 : -1) * 100, force.y * 100));
        transform.SetParent(null);
        isNeedToReactionWithAnother = true;
    }
    
    public virtual void ReactionWithAnotherItem()
    {
        Collider2D hit = Physics2D.OverlapCircle((Vector2)transform.position, radius,layer);
        if(hit != null && hit.GetComponent<Item>() != null)
        {
            target = hit.transform.GetComponent<Item>().type;
            targetObj = hit.transform.gameObject;
        }
    }

    public virtual void ReactionWithPlayer()
    {
        Collider2D hit = Physics2D.OverlapCircle((Vector2)transform.position, radius, layer);
        if (hit != null && hit.GetComponent<PlayerController>() != null)
        {
            player = hit.transform.GetComponent<PlayerController>();
        }
    }

    protected virtual void SetType()
    {

    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    [SerializeField]
    public enum ItemType
    {
        H = 0,
        O = 1,
        Na = 2,
        Cl = 3,
        Fe = 4,
        H2O = 5,
        NaCl = 6,
        HCl = 7,
        H2 = 8,
        None = 9,
        C = 10,
        O2 = 11
    }
}
