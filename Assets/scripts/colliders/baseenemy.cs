using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public int Life;
    public int Power;
    public SeekPlayer agent;

    public void Set(int _life, int _power, GameObject target)
    {
        Life = _life;
        Power = _power;
        agent.target = target.transform;
    }
    void Start()
    {

    }
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<playermoved>().TakeDamage();

            Destroy(gameObject);
        }
    }

}
