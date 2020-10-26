using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Reflection;

public class Raycast : MonoBehaviour
{
    public float rayLength;
    public int damage;
    public int health;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 1000f, Color.red);
            if (Physics.Raycast(ray, out hit, rayLength))
            {
                print(hit.collider.gameObject.transform.parent.gameObject.name);
                hit.collider.gameObject.transform.parent.gameObject.GetComponent<Enemy>().takeDamage(damage);
            }
            else
            {
                print("hit nothing");
            }
        }
    }
}
