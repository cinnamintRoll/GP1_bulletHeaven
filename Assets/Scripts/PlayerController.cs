using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 100.0f;
    private Rigidbody playerRb;
    private float zBound = 7;
    public GameObject projectilePrefab;

    //Player Health Variables - DORADO

    public int maxHealth = 100;
    public int currenHealth;
    public HealthBar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        //Player Health

        currenHealth = maxHealth;
        healthbar.setMaxH(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
        ShootBullets();
        
        // Player Health Damage Tester
         if (Input.GetKeyDown(KeyCode.Space))
            {
                TakeDamage(15);
            }
    }

    void TakeDamage(int damage)
    {
        currenHealth -= damage;
        healthbar.setHealth(currenHealth);
    }
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    void ConstrainPlayerPosition()
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
    }

    void ShootBullets()
    {

        // No longer necessary to Instantiate prefabs
        // Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

        // Get an object object from the pool
        GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
        if (pooledProjectile != null)
        {
            pooledProjectile.SetActive(true); // activate it
            pooledProjectile.transform.position = transform.position; // position it at player
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collided with enemy.");
            TakeDamage(15);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
    }
}
