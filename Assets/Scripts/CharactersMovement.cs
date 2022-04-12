
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersMovement : MonoBehaviour
{
    private List<List<Transform>> waypoints;

    [SerializeField] List<Transform> waypointsWater;
    [SerializeField] List<Transform> waypointsCan;
    [SerializeField] List<Transform> waypointsBandage;
    [SerializeField] List<Transform> waypointsGun;
    [SerializeField] List<Transform> waypointsShield;



    public int current;

    [SerializeField] float moveSpeed = 2f;

    int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
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
