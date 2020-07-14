using UnityEngine;

public class Wrapping : MonoBehaviour
{
    //screen wrapping support
    private float _colliderRadius;

    private void Start()
    {
        _colliderRadius = GetComponent<CircleCollider2D>().radius;
    }

    /// <summary>
    /// Called when the game object becomes invisible to the camera
    /// </summary>
    private void OnBecameInvisible()
    {
        Vector2 position = transform.position;

        // check left, right, top, and bottom sides
        if (position.x + _colliderRadius < ScreenUtils.ScreenLeft ||
            position.x - _colliderRadius > ScreenUtils.ScreenRight)
        {
            position.x *= -1;
        }

        if (position.y - _colliderRadius > ScreenUtils.ScreenTop ||
            position.y + _colliderRadius < ScreenUtils.ScreenBottom)
        {
            position.y *= -1;
        }

        // move ship
        transform.position = position;
    }
}
