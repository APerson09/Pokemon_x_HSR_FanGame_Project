using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform targetPlayer;
    public float detection = 3f;
    public float stop = 1f;
    public float speed = 3f;
    public float range = 3f;
    private Vector3 originalPosition;
    public string sceneName;
    void Start()
    {
        originalPosition = transform.position;
        if(targetPlayer == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if(player != null)
            {
                targetPlayer = player.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(targetPlayer == null) return;

        float distance = Vector3.Distance(transform.position, targetPlayer.position);

        if(distance <= detection)
        {
            attemptBattle(distance);
        }
        else
        {
            returnToPosition();
        }
    }

    private void attemptBattle(float distance)
    {
        if (distance <= range)
        {
            if(!string.IsNullOrEmpty(sceneName))
            {
                SceneManager.LoadScene(sceneName);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
        }
    }

    private void returnToPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, originalPosition, speed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detection);
    }
}
