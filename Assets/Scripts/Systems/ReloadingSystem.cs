using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadingSystem : IEcsRunSystem
{
    private EcsFilter<TryReload, AnimatorRef>.Exclude<Reloading> _tryReloadFilter;
    private EcsFilter<Weapon, ReloadingFinished> _reloadingFinishedFilter;
    private UI _ui;

    public void Run()
    {
        foreach (var i in _tryReloadFilter)
        {
            ref var animatorRef = ref _tryReloadFilter.Get2(i);

            animatorRef.animator.SetTrigger("Reload");

            ref var entity = ref _tryReloadFilter.GetEntity(i);
            entity.Get<Reloading>();
        }

        foreach (var i in _reloadingFinishedFilter)
        {
            ref var weapon = ref _reloadingFinishedFilter.Get1(i);

            var needAmmo = weapon.maxInMagazine - weapon.currentInMagazine;
            weapon.currentInMagazine = (weapon.totalAmmo >= needAmmo)
                ? weapon.maxInMagazine
                : weapon.currentInMagazine + weapon.totalAmmo;
            weapon.totalAmmo -= needAmmo;
            weapon.totalAmmo = weapon.totalAmmo < 0
                ? 0
                : weapon.totalAmmo;

            ref var entity = ref _reloadingFinishedFilter.GetEntity(i);
            if (weapon.owner.Has<Player>())
            {
                _ui.gameScreen.SetAmmo(weapon.currentInMagazine, weapon.totalAmmo);
            }
            weapon.owner.Del<Reloading>();
            entity.Del<ReloadingFinished>();
        }
    }
}
