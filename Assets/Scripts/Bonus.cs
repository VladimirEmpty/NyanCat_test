using UnityEngine;

public class Bonus : MonoBehaviour
{
    public float speed;

    private Transform _target;

    private void Update()
    {
        if(_target != null) 
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.position, speed * Time.deltaTime);
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _target = collision.transform;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _target = null;
        }
        
    }
}
