using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody2D rigidbody;
    [SerializeField] 
    private float speed;

    [SerializeField]
    private int hitPoint;

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Lose"))
        {
            GameManager.Instance.LoseGame();
        }

        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.LoseGame();
        }
    }

    public void Damage(int damage)
    {
        hitPoint -= damage;

        if (hitPoint <= 0)
        {
            Destroy(this.gameObject);
            CoinManager.Instance.AddCoin();
        }
    }
}
