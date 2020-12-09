using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

   // public GameObject floatingDamage;

    public void TakeDamage(float amount)
    {
        health -= amount;
       // GameObject points =  Instantiate(floatingDamage, transform.position + new Vector3(0, .5f, 0), Quaternion.identity) as GameObject;
        //points.transform.GetChild(0).GetComponent<TextMesh>().text = "" + amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die() 
    {
        Destroy(gameObject);
    }
}
