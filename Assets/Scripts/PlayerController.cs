using Assets.Scripts;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    GameObject focalPoint;
    [SerializeField] GameObject checkpointWall;
    [SerializeField] GameObject checkpointFlag;
    Vector3 defaultCheckpointWallScale;
    public GameObject attack;
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        checkpointWall = GameObject.Find("CheckpointWall");
        defaultCheckpointWallScale = checkpointWall.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float sideInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        playerRb.AddForce(focalPoint.transform.right * speed * sideInput);
    }

    Checkpoint[] checkpoints = new Checkpoint[]
    {
        new Checkpoint(new Vector3(-22.46f, 1.59f, -13.73f), 0f),
        new Checkpoint(new Vector3(-10.47f, 1.59f, -6.36f), 90f),
        new Checkpoint(new Vector3(-12.37f, 1.59f, 15.42f), 0f),
        new Checkpoint(new Vector3(2.24f, 1.59f, 5.47f), 0f),
        new Checkpoint(new Vector3(11.4f, 1.59f, 20.3f), 0f),
        new Checkpoint(new Vector3(8.2f, 1.59f, 2.5f), 90f),
        new Checkpoint(new Vector3(20.05f, 1.59f, 0.8f), 0f),
        new Checkpoint(new Vector3(26.02f, 1.59f, -20.34f), 90f)
    };
    Vector3 checkFlagOffset = new Vector3(-0.98f, 0, -1.75f);
    Vector3 checkFlagOffset90 = new Vector3(-1.77f, 0, 1.34f);
    int checkpointCount = 0;
    void SpawnNextCheckpoint()
    {
        try
        {
            Vector3 offset = (checkpoints[checkpointCount].rotation == 0f) ? checkFlagOffset : checkFlagOffset90;
            Instantiate(checkpointFlag, checkpoints[checkpointCount].position - offset, checkpointWall.transform.rotation);
            checkpointCount++;

            checkpointWall.transform.position = checkpoints[checkpointCount].position;
            checkpointWall.transform.rotation = new Quaternion(0f, 0f, 0f, checkpointWall.transform.rotation.w);
            checkpointWall.transform.Rotate(Vector3.up, checkpoints[checkpointCount].rotation);

        }
        catch (System.Exception ex)
        {
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("checkpoint"))
        {
            if (checkpointCount < checkpoints.Length)
                SpawnNextCheckpoint();
            else
                GameCompleted();
        }
    }

    private void GameCompleted()
    {
        checkpointCount = 0;
        checkpointWall.transform.localScale = defaultCheckpointWallScale;
        checkpointWall.transform.position = checkpoints[0].position;
        checkpointWall.transform.rotation = new Quaternion(0f, 0f, 0f, checkpointWall.transform.rotation.w);
        checkpointWall.transform.Rotate(Vector3.up, checkpoints[0].rotation);
        checkpointWall.GetComponent<Counter>().Restart();
        foreach (GameObject check in GameObject.FindGameObjectsWithTag("checkpointFlag"))
            Destroy(check);
    }
}