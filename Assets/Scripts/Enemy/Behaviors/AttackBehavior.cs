using UnityEngine;

public class AttackBehavior
{
    int Delay;

    Projectile Attack;

    Enemy Source;
    GameObject Target;

    public void Initialize(Enemy s, GameObject t, Projectile Attack)
    {
        Source = s;
        Target = t;

        this.Attack = Attack;
        Delay = Attack.Cooldown;
    }

    //public void Initialize(Enemy s, Player t, Projectile Attack )
    //{
    //    this.Attack = Attack;
    //    Delay = Attack.Cooldown;

    //    Source = s;
    //    Target = t;
    //}

    public void AttackTarget()
    {
        if( Vector2.Distance( Source.transform.position, Target.transform.position ) < Source.AggroRange )
        {
            Delay--;
            if( Delay < 0 )
            {
                Delay = Attack.Cooldown;

                Projectile newProjectile = Object.Instantiate(Attack, Source.transform.position, Quaternion.identity);
            }
        }
    }
}
