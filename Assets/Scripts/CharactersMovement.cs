
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersMovement : MonoBehaviour
{
    //animator & animation pour que les perso s'arr?tent ? la collision (idle animation)
    Animator m_Animator;


    private List<List<Transform>> waypoints;
    public bool stop = false;
    [SerializeField] SpriteRenderer _characterSprite;

    public bool etatCan = true;
    public bool etatBandage = true;
    public bool etatGun = true;
    public bool etatShield = true;

    public int current;

    public float currentMoveSpeed;
    [SerializeField] public float standardMoveSpeed;
    int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();

        
        
    }

    public void Init(List<Transform> waypointsWater, List<Transform> waypointsCan, List<Transform> waypointsBandage, List<Transform> waypointsGun, List<Transform> waypointsShield, bool canAvailable, bool bandageAvailable, bool gunAvailable, bool shieldAvailable)
    {
        waypoints = new List<List<Transform>>();
        waypoints.Add(waypointsWater);
        if (canAvailable)
        {
            waypoints.Add(waypointsCan);
        }
        if (bandageAvailable)
        {
            waypoints.Add(waypointsBandage);
        }
        if (gunAvailable)
        {
            waypoints.Add(waypointsGun);
        }
        if (shieldAvailable)
        {
            waypoints.Add(waypointsShield);
        }

        // ici pour le militaire faut dire que "si le client == MilitairePrefab" alors il faut passer ? "Random.Range(3,5)" ou alors garder en compte que les "waypoints de Gun & Shield"
        current = Random.Range(0, waypoints.Count);
        transform.position = waypoints[current][waypointIndex].transform.position;
        currentMoveSpeed = standardMoveSpeed;

        
    }
    
    


    internal void Play()
    {
        currentMoveSpeed = standardMoveSpeed;
        _characterSprite.sortingOrder = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
        Move();
    }

    public void Move()
    {
        

        transform.position = Vector2.MoveTowards(transform.position, waypoints[current][waypointIndex].transform.position, currentMoveSpeed * Time.deltaTime);

        if (transform.position == waypoints[current][waypointIndex].transform.position)
        {
            m_Animator.SetBool("IsWalkingRight", true);
            waypointIndex += 1;
        }

        if (waypointIndex == waypoints[current].Count)
        {
            m_Animator.SetBool("IsWalkingRight", true);
            Destroy(gameObject);
        }
        
    }

    public void Stop()
    {
        m_Animator.SetBool("IsWalkingRight", false);
        currentMoveSpeed = 0;
        _characterSprite.sortingOrder = 9;
        
    }
}
