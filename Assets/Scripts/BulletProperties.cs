using UnityEngine;

public class BulletProperties : MonoBehaviour
{
    public float speed = 40.0f;
    private float topBound = 15f;

    // Update is called once per frame
    void Update()
    {
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
