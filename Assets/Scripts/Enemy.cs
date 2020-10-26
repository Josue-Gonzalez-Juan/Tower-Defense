using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public Waypoint currentDestination;
  public WaypointManager waypointManager;
  public PurseManager purseManager;
  private int currentIndexWaypoint = 0;
  public float speed = 1;
  public int deathWorth;
  public int health = 0;

  public void Initialize(WaypointManager waypointManager, PurseManager purseManager)
  {
    this.waypointManager = waypointManager;
    this.purseManager = purseManager;
    GetNextWaypoint();
    transform.position = currentDestination.transform.position; // Move to WP0
    GetNextWaypoint();
  }

  void Update()
  {
    Vector3 direction = currentDestination.transform.position - transform.position;
    if (direction.magnitude < .2f)
    {
      GetNextWaypoint();
    }
    if (health <= 0)
    {
      purseManager.coins += deathWorth;
      Destroy(gameObject);
    }
    transform.Translate(direction.normalized * speed * Time.deltaTime);
  }

  private void GetNextWaypoint()
  {
    currentDestination = waypointManager.GetNeWaypoint(currentIndexWaypoint);
    currentIndexWaypoint++;
  }

  public void takeDamage(int damage)
  {
    health += -damage;
  }
}
