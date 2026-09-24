using UnityEngine;

public class AttackBehavior
{
    int Delay;

    Projectile Attack;

    Enemy Source;
    Player Target;

    public void Initialize( Enemy e, Player p, Projectile Attack )
    {
        this.Attack = Attack;
        Delay = Attack.Cooldown;

        Source = e;
        Target = p;
    }

    public void AttackTarget()
    {
        if( Vector2.Distance( Source.transform.position, Target.transform.position ) < Source.AggroRange )
        {
            Delay--;
            if( Delay < 0 )
            {
                Delay = Source.Cooldown;
                //create projectile
            }
        }
    }
}
