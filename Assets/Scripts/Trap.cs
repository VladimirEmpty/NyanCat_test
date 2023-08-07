using UnityEngine;

public class Trap : MonoBehaviour
{
    private float _speed;
    private float _randomMoveTime;
    private float _moveTime;

    private void Start()
    {
        _speed = Random.Range(0, 2f);
        _randomMoveTime = Random.Range(0.5f, 3f);
        _moveTime = _randomMoveTime + Time.time;
    }

    private void Update()
    {
        if (_moveTime >= Time.time)
        {
            transform.Translate(Vector2.up * _speed * Time.deltaTime);            
        }
        else
        {
            RevertMove();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            RevertMove();
        }
    }

    private void RevertMove()
    {
        _speed *= -1;
        _moveTime = _randomMoveTime + Time.time;
    }
}
