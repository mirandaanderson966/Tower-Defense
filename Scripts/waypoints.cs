using UnityEngine;

public class waypoints : MonoBehaviour {

    public static Transform[] points;

    void Awake()
    {
        points = new Transform[transform.childCount];//create 5 places in array
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
