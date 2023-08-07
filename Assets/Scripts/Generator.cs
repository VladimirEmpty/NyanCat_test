using UnityEngine;

public class Generator : MonoBehaviour
{
    public Trap trapPrefab;
    public GameObject bonusPrefab;
    public Transform topPoint;
    public Transform bottomPoint;

    public float createTrapTime;
    public float createBonusTime;

    public void StartGame()
    {
        InvokeRepeating("GenerateTrap", 0, createTrapTime);
        InvokeRepeating("GenerateBonus", 0, createBonusTime);
    }

    private void GenerateTrap()
    {
        int trapCount = Random.Range(1, 3);
        Vector3 createPosition = Vector3.zero;

        for (int i = 0; i < trapCount; i++)
        {
            createPosition.x = transform.position.x;
            createPosition.y = Random.Range(topPoint.position.y, bottomPoint.position.y);

            Trap trap = Instantiate(trapPrefab);
            trap.transform.position = createPosition;

            Destroy(trap.gameObject, 7);
        }
    }

    private void GenerateBonus()
    {
        if(Random.value >= 0.5f)
        {
            Vector3 createPositon = transform.position;
            createPositon.y = Random.Range(topPoint.position.y, bottomPoint.position.y);

            GameObject bonus = Instantiate(bonusPrefab);
            bonus.transform.position = createPositon;

            Destroy(bonus.gameObject, 7);
        }
    }
}
