using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float maxHealth = 100f;
    //private float _currentHealth = 0f;
    public int Degats = 1;


    // Use this for initialization
    void Start ()
    {

        //_currentHealth = maxHealth;

	}


    public void TakeDamage(float damage)
    {
        Destroy(this.gameObject);
	}

    /*void OnCollisionEnter(Collision other)
    {
       
        ITakeDamage Obstacles = other.gameObject.GetComponentInParent<ITakeDamage>();
        Debug.Log(Obstacles);

        if (Obstacles != null)
        {

            Obstacles.TakeDamage(Degats);

        }
        Destroy(this.gameObject);

    }*/
}
