using UnityEngine;

public class BulletProperties : MonoBehaviour
{
    public float speed = 40.0f;
    private float topBound = 15f;
    public ScoreManager score;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit; 
        Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit, 1.5f, LayerMask.GetMask("Enemy"));

        if (hit.collider)
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 10);
            Destroy(hit.collider.gameObject);
        }
        MoveForward();
        DestroyOutofBounds();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void DestroyOutofBounds()
    {
        if (transform.position.z > topBound)
        {
            // Instead of destroying the projectile when it leaves the screen
            //Destroy(gameObject);

            // Just deactivate it
            gameObject.SetActive(false);

        }
    }

}
