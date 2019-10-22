using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int ScorePerHit = 1;
    [SerializeField] int hitpoints = 1;
    Collider boxCollider;
    ScoreBoard scoreboard;
    // Start is called before the first frame update
    void Start()
    {
        //add box collider
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;

        //add ref to scoreboard
        scoreboard = FindObjectOfType<ScoreBoard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        //update score
        scoreboard.addScore(ScorePerHit);

        //subtract hitpoints and check death
        hitpoints--;

        if(hitpoints < 1)
        {
            Die();
        }
        else
        {
            //play effect?
        }
    }

    private void Die()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
