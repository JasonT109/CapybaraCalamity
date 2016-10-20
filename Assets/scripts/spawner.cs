using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class spawner : MonoBehaviour
{
    [Header("Prefab configuration:")]
    public GameObject agent;
    public GameObject crateMesh;
    public Animator crateAnimator;

    [Header("Spawner configuration:")]
    public int numberOfAgents = 10;
    public float timeInterval = 0.5f;
    public float timeToFirstSpawn = 2.0f;
    public float initialDirection = -1.0f;
    public string countDownText;
    public Text coundDownTextObject;

    private float currentTime;
    private float spawnTime;
    private bool canSpawn = true;
    private GameObject uiScore;
    private int initNumAgents;
    private float countDown;

    void Start()
    {
        initNumAgents = numberOfAgents;
        uiScore = GameObject.FindGameObjectWithTag("UI");
        var scoreScript = uiScore.gameObject.GetComponent<uiScore>();
        scoreScript.totalNumAgents += numberOfAgents;
        currentTime = Time.timeSinceLevelLoad;
        spawnTime = currentTime + timeToFirstSpawn;
        countDown = timeToFirstSpawn;
        crateAnimator = crateMesh.GetComponent<Animator>();
    }

    public void resetSpawner()
    {
        numberOfAgents = initNumAgents;
        spawnTime = currentTime + timeToFirstSpawn;
        countDown = timeToFirstSpawn;
        StopCoroutine("WaitAndSpawn");
        canSpawn = true;
    }

    // Update is called once per frame
    void Update() {
        currentTime += Time.deltaTime;
        countDown -= Time.deltaTime;
        if (countDown > 0.5f)
        {
            countDownText = ("" + Mathf.Round(countDown));
        }
        else if (countDown <= 0.5f && countDown > -1.0f)
        {
            countDownText = ("Here they come!");
        }
        else
        {
            countDownText = ("");
        }
        
        if (currentTime > spawnTime & canSpawn & numberOfAgents > 0)
        {
            canSpawn = false;
            StartCoroutine("WaitAndSpawn", timeInterval);
        }
        coundDownTextObject.text = countDownText;
    }

    IEnumerator WaitAndSpawn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        crateAnimator.Play("box_shake", -1, 0.0f);
        GameObject newAgent;
        newAgent = Instantiate(agent, transform.position, transform.rotation) as GameObject;
        var agentScript = newAgent.GetComponent<agent>();
        agentScript.MoveDir.x = initialDirection;
        Rigidbody rb;
        rb = newAgent.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, -1, 0);
        canSpawn = true;
        numberOfAgents -= 1;
    }
}