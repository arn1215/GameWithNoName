using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 100;

    public PlebHealth plebHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pleb")
        {
            plebHealth.TakeDamage (damage);
        }
    }
}
