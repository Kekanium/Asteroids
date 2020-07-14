using UnityEngine;

public class Asteroids : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;
    [Header("Min/Max Impulse force(Min<Max)")]
    private const float minImpulseForce = 3f;

    private const float maxImpulseForce = 5f;
    private void Start()
    {
        
        float angle = Random.Range(0f, 2*Mathf.PI);
        Vector2 direction;
        direction=new Vector2(Mathf.Cos(angle),Mathf.Sin(angle));
        float magnitude;
        magnitude = Random.Range(minImpulseForce, maxImpulseForce);
        (_rigidBody2D = GetComponent<Rigidbody2D>()).AddForce(direction*magnitude,ForceMode2D.Impulse);

    }
}
