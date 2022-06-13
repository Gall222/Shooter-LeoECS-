using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Projectile 
{
    public Vector3 direction;
    public Vector3 previousPos;
    public float speed;
    public float radius;
    public int damage;
    public GameObject projectileGO;

}
