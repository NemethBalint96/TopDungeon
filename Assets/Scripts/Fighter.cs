using UnityEngine;

public class Fighter : MonoBehaviour
{
    // Public fields
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float pushRevocerySpeed = 0.2f;

    // Immunity
    protected float imuneTime = 1.0f;
    protected float lastImmune;

    // Push
    protected Vector3 pushDirection;

    // All fighters can ReciveDamage / Die
    protected virtual void ReciveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > imuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f);

            if (hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death()
    {

    }
}
