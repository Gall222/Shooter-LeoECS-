using UnityEngine;
using UnityEngine.AI;

public struct Enemy
{
    public NavMeshAgent navMeshAgent;
    public Animator animator;
    public Transform transform;
    public float meleeAttackDistance;
    public float triggerDistance;
    public float meleeAttackInterval;
    public int damage;
}
