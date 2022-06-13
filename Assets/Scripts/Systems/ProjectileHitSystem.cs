using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHitSystem : IEcsRunSystem
{
    private EcsFilter<Projectile, ProjectileHit> filter;
    private EcsWorld ecsWorld;

    public void Run()
    {
        foreach (var i in filter)
        {
            ref var projectile = ref filter.Get1(i);
            ref var hit = ref filter.Get2(i);

            if (hit.raycastHit.collider.gameObject.TryGetComponent(out EnemyView enemyView))
            {
                if (enemyView.entity.IsAlive())
                {
                    ref var e = ref ecsWorld.NewEntity().Get<DamageEvent>();
                    e.target = enemyView.entity;
                    e.value = projectile.damage;
                }
            }

            projectile.projectileGO.SetActive(false);
            filter.GetEntity(i).Destroy();
        }
    }
}
