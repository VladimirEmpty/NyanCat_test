using UnityEngine;
using UnityEngine.SceneManagement;

public class Cat : MonoBehaviour
{
    public GameUI gameUI;
    public Generator generator;
    public Rigidbody2D rigidbody;
    public float force;
    public float speed;
    private bool _isRun;

    // Start is called before the first frame update
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();    
        rigidbody.simulated = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if(!_isRun && Input.GetKey(KeyCode.Space) | Input.GetMouseButton(0))
        {
            gameUI.StartGame();
            generator.StartGame();

            rigidbody.simulated = true;
            _isRun = true;
        }

        if (Input.GetKey(KeyCode.Space) | Input.GetMouseButton(0))
        {
            rigidbody.AddForce(Vector2.up * force, ForceMode2D.Force);
        }

        if (_isRun)
        {
            Vector2 move = rigidbody.velocity;
            move.x = speed;

            rigidbody.velocity = move;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            SceneManager.LoadScene(0);
        }

        if (collision.CompareTag("Bonus"))
        {
            gameUI.AddScore();
            Destroy(collision.transform.parent.gameObject);
        }
    }
}
