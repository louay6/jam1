using UnityEngine;

public class TimeBasedPuzzle : MonoBehaviour
{
    public GameObject lever1;
    public GameObject lever2;
    public GameObject keyPrefab;
    public Transform keySpawnPoint;
    private bool lever1Activated = false;
    private bool lever2Activated = false;
    private bool puzzleCompleted = false;
    private float timer = 0f;
    private float timeLimit = 10f;

    void Update()
    {
        if (!puzzleCompleted)
        {
            // Check for player interaction with levers
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (lever1.GetComponent<Collider2D>().bounds.Intersects(lever2.GetComponent<Collider2D>().bounds))
                {
                    lever1Activated = true;
                    if (lever2Activated)
                    {
                        CompletePuzzle();
                    }
                    else
                    {
                        StartTimer();
                    }
                }
                if (lever2.GetComponent<Collider2D>().bounds.Intersects(lever1.GetComponent<Collider2D>().bounds))
                {
                    lever2Activated = true;
                    if (lever1Activated)
                    {
                        CompletePuzzle();
                    }
                    else
                    {
                        StartTimer();
                    }
                }
            }
            // Check timer expiration
            if (timer > timeLimit)
            {
                ResetPuzzle();
            }
        }
    }

    void StartTimer()
    {
        // Start the timer
        timer += Time.deltaTime;
    }

    void CompletePuzzle()
    {
        // Puzzle completed, spawn key
        Instantiate(keyPrefab, keySpawnPoint.position, Quaternion.identity);
        puzzleCompleted = true;
    }

    void ResetPuzzle()
    {
        // Reset puzzle state
        lever1Activated = false;
        lever2Activated = false;
        timer = 0f;
    }
}
