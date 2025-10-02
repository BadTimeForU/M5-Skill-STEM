using UnityEngine;

public class Parabola : MonoBehaviour
{
    [SerializeField] Point point;
    int NumberOfPoints = 100000;
    Vector2 minScreen, maxScreen;

    QuadraticFunction f;

    [SerializeField] public float a = 1;
    [SerializeField] public float b = 2;
    [SerializeField] public float c = -3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minScreen = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maxScreen = Camera.main.ScreenToWorldPoint (new Vector2(Screen.width, Screen.height));

        float dx = (maxScreen.x - minScreen.x) /NumberOfPoints;

        f = new QuadraticFunction(a, b, c);

        for (int i = 0; i <= NumberOfPoints; i++)
        {
            float x_pos = minScreen.x + i*dx;
            float y_pos = f.getY(x_pos);
            Point copyOfPoint = Instantiate(point);
            copyOfPoint.transform.position = new Vector3(x_pos, y_pos, 0);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
