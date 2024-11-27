using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeRoom : MonoBehaviour
{
    private Rigidbody2D player;
    private BoxCollider2D doorKnob;
    [SerializeField] public string sceneToLoad;
    public float interactionDistance = 1f; // Distance to interact with the object

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        doorKnob = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // Check if the player is close enough to the door (using the collider's position)
        if (IsPlayerNearby() && Input.GetKeyDown(KeyCode.I))
        {
            LoadScene();
        }
    }

    // Check if the player is within interaction range of the door
    bool IsPlayerNearby()
    {
        // Use the BoxCollider2D's position to check if the player is within the door's range
        return Vector2.Distance(player.position, doorKnob.transform.position) < interactionDistance;
    }

    void LoadScene()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
