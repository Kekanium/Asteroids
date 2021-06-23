using UnityEngine;

public class Asteroids : MonoBehaviour
{
    private const float MinImpulseForce = 3f;

    private const float MaxImpulseForce = 5f;
    private void Start()
    {
        
        float angle = Random.Range(0f, 2*Mathf.PI);
        Vector2 direction;
        direction=new Vector2(Mathf.Cos(angle),Mathf.Sin(angle));
        float magnitude;
        magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(direction*magnitude,ForceMode2D.Impulse);

    }
}
