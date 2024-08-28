using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbody;
    [SerializeField]
    private Animator animator;

    [Space(13)]
    
    [SerializeField]
    private float normalSpeed;
    private float speed;
    private Vector2 moveDirection;
    
    [Space(13)]
    
    private bool isMovement = false;
    private bool isFire = false;

    [Space(13)] 
    
    [SerializeField]
    private float attackDelay = .4f;
    [SerializeField] 
    private GameObject bulletPrefab;

    private void Start()
    {
        speed = 0;
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, speed);
    }

    public void MovePlayerUp()
    {
        isMovement = true;
        
        animator.SetBool("isMovement", isMovement);
        
        if (speed <= 0f)
        {
            speed = normalSpeed;
        }
    }

    public void MovePlayerDown()
    {
        isMovement = true;
        
        animator.SetBool("isMovement", isMovement);
        
        if (speed >= 0f)
        {
            speed = -normalSpeed;
        }
    }

    public void ResetMovement()
    {
        isMovement = false;
        animator.SetBool("isMovement", isMovement);
        speed = 0f;
    }

    public void Attack()
    {
        if (!isFire)
        {
            StartCoroutine(AttackCO());

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }

    private IEnumerator AttackCO()
    {
        isFire = true;
        animator.SetBool("isFire", isFire);

        yield return new WaitForSeconds(attackDelay);

        isFire = false;
        animator.SetBool("isFire", isFire);
    }
}
