using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector3 velocity = new Vector3(1, 1, 0);
    [SerializeField] private Vector3 acceleration = new Vector3(0, -1, 0);

    private Vector2 minScreen, maxScreen;

    public Vector3 Velocity
    {
        get { return velocity; }
        set { velocity = value; }
    }

    public Vector3 Acceleration
    {
        get { return acceleration; }
        set { acceleration = value; }
    }

    void Start()
    {
        minScreen = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maxScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    void Update()
    {
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        Vector3 temp = transform.position;

        if (temp.y > maxScreen.y)
        {
            velocity.y = -Mathf.Abs(velocity.y);
        }

        if (temp.x > maxScreen.y)
        {
            velocity.x = -Mathf.Abs(velocity.x);
        }

        if (temp.y < minScreen.y)
        {
            velocity.y = Mathf.Abs(velocity.y);
        }

        if (temp.x < minScreen.x)
        {
            velocity.x = Mathf.Abs(velocity.x);
        }
    }
}