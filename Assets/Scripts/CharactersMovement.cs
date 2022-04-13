
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersMovement : MonoBehaviour
{
    private List<List<Transform>> waypoints;

    



    public int current;

    [SerializeField] float moveSpeed;

    int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {


        
        
    }

    public void Init(List<Transform> waypointsWater, List<Transform> waypointsCan, List<Transform> waypointsBandage, List<Transform> waypointsGun, List<Transform> waypointsShield)
    {
        waypoints = new List<List<Transform>>();
        waypoints.Add(waypointsWater);
        waypoints.Add(waypointsCan);
        waypoints.Add(waypointsBandage);
        waypoints.Add(waypointsGun);
        waypoints.Add(waypointsShield);


        current = Random.Range(0, 5);
        transform.position = waypoints[current][waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        

        transform.position = Vector2.MoveTowards(transform.position, waypoints[current][waypointIndex].transform.position, moveSpeed * Time.deltaTime);

        if (transform.position == waypoints[current][waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }

        if (waypointIndex == waypoints[current].Count)
        {
            Destroy(gameObject);
        }
        
    }
}
