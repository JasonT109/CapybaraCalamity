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

    private float _CurrentTime;
    private float _SpawnTime;
    private bool _CanSpawn = true;
    private GameObject _uiScore;
    private int _InitNumAgents;
    private float _CountDown;

    void Start()
    {
        _InitNumAgents = numberOfAgents;
        _uiScore = GameObject.FindGameObjectWithTag("UI");
        var scoreScript = _uiScore.gameObject.GetComponent<uiScore>();
        scoreScript.totalNumAgents += numberOfAgents;
        _CurrentTime = Time.timeSinceLevelLoad;
        _SpawnTime = _CurrentTime + timeToFirstSpawn;
        _CountDown = timeToFirstSpawn;
        crateAnimator = crateMesh.GetComponent<Animator>();
    }

    public void ResetSpawner()
    {
        numberOfAgents = _InitNumAgents;
        _SpawnTime = _CurrentTime + timeToFirstSpawn;
        _CountDown = timeToFirstSpawn;
        StopCoroutine("WaitAndSpawn");
        _CanSpawn = true;
    }

    void Update()
    {
        _CurrentTime += Time.deltaTime;
        _CountDown -= Time.deltaTime;

        if (_CountDown > 0.5f)
            countDownText = ("" + Mathf.Round(_CountDown));
        else if (_CountDown <= 0.5f && _CountDown > -1.0f)
            countDownText = ("Here they come!");
        else
            countDownText = ("");
        
        if (_CurrentTime > _SpawnTime & _CanSpawn & numberOfAgents > 0)
        {
            _CanSpawn = false;
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

        _CanSpawn = true;
        numberOfAgents -= 1;
    }
}