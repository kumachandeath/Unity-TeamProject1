using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoom : SkillBase
{
    public override void SetData(int id)
    {
        base.SetData(id);
    }

    public override void DoCast()
    {
        base.DoCast();

        Vector3 dist = new Vector3(_skillData.Range, 0, 0);
        _castPos = StartPos.position + dist;

        _castEffectInstance.transform.position = _castPos;

        _castEffectInstance.Play();
    }

    public override void DoSkill(float attackPoint)
    {
        Vector3 dist = new Vector3(_skillData.Range, 0, 0);
        AreaProjectile projectile = Instantiate(projectilePrefab, _castPos, Quaternion.identity) as AreaProjectile;
        projectile.SetDamage(_skillData.Damage * attackPoint);
        projectile.EnableTrigger();
        base.DoSkill(attackPoint);
    }
}
