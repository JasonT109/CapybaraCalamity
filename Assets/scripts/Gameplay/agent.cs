using UnityEngine;
using System;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.Hit;

public class agent : MonoBehaviour
{
    [Header ("Movement configuration:")]
    public Vector3 MoveDir = new Vector3(1, 0, 0);
    public float MoveSpeed = 1.0f;
    public float SplatSpeed = 6.0f;
    public bool Falling = false;
    public bool FallingFast = false;
    public float FallSpeed;
    public float FallTolerance = 1.0f;
    public bool FallingSlow = false;
    public bool Digging = false;
    public bool CanDig = false;

    [Header("Ability configuration:")]
    public abilityHandler.Abilities Ability;
    private abilityHandler _AbilityHandler;

    [Header ("Collision configuration:")]
    public Rigidbody RB;
    public Collider CL;
    public Collider CurrentCollider;
    public Collider IgnoredCollider;
    private bool _CollisionTimingCheck = false;

    [Header ("Prefab configuration:")]
    public GameObject Tunnel;
    public Animator AgentAnim;

    [HideInInspector]
    public SkinnedMeshRenderer ParachuteMesh;
    private SkinnedMeshRenderer[] _SkinnedMeshes;

    private GameObject UIScore;
    private PressGesture _PressGesture;

    private void OnEnable()
    {
        _PressGesture = GetComponent<PressGesture>();
        _PressGesture.Pressed += PressHandler;
    }

    private void OnDisable()
    {
        _PressGesture.Pressed -= PressHandler;
    }

    private void PressHandler(object sender, EventArgs e)
    {
        var gesture = sender as PressGesture;
        TouchHit hit;
        gesture.GetTargetHitResult(out hit);

        if (hit.Transform.gameObject == gameObject)
            _AbilityHandler.SetAgentAbility(this);
    }
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        CL = GetComponent<Collider>();
        UIScore = GameObject.FindGameObjectWithTag("UI");

        _SkinnedMeshes = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer SkinnedMesh in _SkinnedMeshes)
        {
            if (SkinnedMesh.name == "char_para_leaf")
            {
                SkinnedMesh.enabled = false;
                ParachuteMesh = SkinnedMesh;
            }
        }
        _AbilityHandler = GameObject.FindGameObjectWithTag("AbilityHandler").GetComponent<abilityHandler>();
    }
	
	void FixedUpdate ()
    {
        FallSpeed = -RB.velocity.y;

        if (FallSpeed < FallTolerance)
        {
            if (Falling)
                ToggleFalling();
            if (!Digging && Ability != abilityHandler.Abilities.Stopper)
                RB.MovePosition(transform.position + new Vector3(MoveDir.x, 0, 0) * (Time.deltaTime * MoveSpeed));
        }
        else
        {
            if (!Falling)
                ToggleFalling();
            if (!FallingFast && FallSpeed >= SplatSpeed)
                ToggleFallingFast();
        }

        if (Falling && Ability == abilityHandler.Abilities.Floater && FallSpeed > 2.0f)
        {
            RB.velocity = new Vector3(RB.velocity.x, Mathf.Clamp(RB.velocity.y, -2.1f, 0.0f), RB.velocity.z);
            if (!FallingSlow)
                ToggleFallingSlow();
        }
    }

    /** Falling slowly under parachute. */
    void ToggleFallingSlow()
    {
        FallingSlow = !FallingSlow;
        if (FallingSlow)
            AgentAnim.Play("float", -1, 0.0f);
    }

    /** Falling at normal speed. */
    void ToggleFalling()
    {
        Falling = !Falling;

        if (MoveDir.x < 0 && Ability != abilityHandler.Abilities.Stopper && !Falling)
            AgentAnim.Play("run_left", -1, 0.0f);
        else if (MoveDir.x > 0 && Ability != abilityHandler.Abilities.Stopper && !Falling)
            AgentAnim.Play("run_right", -1, 0.0f);

        if (Falling)
            AgentAnim.Play("fall", -1, 0.0f);
    }

    /** Falling at fast speed. */
    void ToggleFallingFast()
    {
        FallingFast = !FallingFast;

        if (FallingFast)
            AgentAnim.Play("fall_fast", -1, 0.0f);
    }

    /** Toggle the stopper ability. */
    public void ToggleStopper()
    {
        if (Ability != abilityHandler.Abilities.Stopper)
        {
            gameObject.layer = 15;
            Ability = abilityHandler.Abilities.Stopper;
            RB.mass = 50.0f;
            AgentAnim.Play("stopper_in", -1, 0.0f);
        }
        else
        {
            gameObject.layer = 8;
            Ability = abilityHandler.Abilities.None;
            RB.mass = 0.2f;
            if (MoveDir.x == -1)
                AgentAnim.Play("run_left", -1, 0.0f);
            else
                AgentAnim.Play("run_right", -1, 0.0f);
        }
    }

    public void ToggleGnawer()
    {
        if (Ability != abilityHandler.Abilities.Gnawer)
            Ability = abilityHandler.Abilities.Gnawer;
        else
            Ability = abilityHandler.Abilities.None;
    }

    public void ToggleFloater()
    {
        if (Ability == abilityHandler.Abilities.Stopper)
            ToggleStopper();

        if (Ability != abilityHandler.Abilities.Floater)
            Ability = abilityHandler.Abilities.Floater;
        else
            Ability = abilityHandler.Abilities.None;

        if (Ability == abilityHandler.Abilities.Floater)
            ParachuteMesh.enabled = true;
        else
            ParachuteMesh.enabled = false;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "branch")
        {
            CurrentCollider = collisionInfo.collider;
            CanDig = true;

            //fell too hard
            if (FallSpeed > SplatSpeed)
            {
                var uiScript = UIScore.GetComponent<uiScore>();
                uiScript.addLostUnit();

                Destroy(gameObject);
            }
            
        }
        else if (collisionInfo.collider.tag == "trunk" || collisionInfo.collider.tag == "agent")
        {
            if (collisionInfo.collider.tag == "agent")
            {
                //Check that we are not inside the other agent, if so move us back
                Vector3 pos1 = transform.position;
                Vector3 pos2 = collisionInfo.collider.transform.position;
                if (Vector3.Distance(pos1, pos2) < 0.29f)
                {
                    if (pos1.x < pos2.x && Ability != abilityHandler.Abilities.Stopper)
                    {
                        transform.position = new Vector3(transform.position.x - 0.01f,
                                              transform.position.y,
                                              transform.position.z);
                        MoveDir.x = -1;
                        AgentAnim.Play("run_left", -1, 0.0f);
                    }
                    else if (pos1.x > pos2.x && Ability != abilityHandler.Abilities.Stopper)
                    {
                        transform.position = new Vector3(transform.position.x + 0.01f,
                                              transform.position.y,
                                              transform.position.z);
                        MoveDir.x = 1;
                        AgentAnim.Play("run_right", -1, 0.0f);
                    }
                }
            }
            else if (Ability != abilityHandler.Abilities.Gnawer && !Falling)
            {
                if (MoveDir.x == 1)
                {
                    MoveDir.x = -1;
                    AgentAnim.Play("run_left", -1, 0.0f);
                }
                else
                {
                    MoveDir.x = 1;
                    AgentAnim.Play("run_right", -1, 0.0f);
                }
            }
            if (Ability == abilityHandler.Abilities.Gnawer && collisionInfo.collider.tag == "trunk")
            {
                float tunnelOffset = 0.125f;
                float tunnelRotation = 0;
                if (MoveDir.x == -1)
                {
                    tunnelOffset = -0.125f;
                    tunnelRotation = 180;
                }

                //let's make a tunnel
                GameObject tunnelClone = Instantiate(Tunnel, transform.position + new Vector3(tunnelOffset, -0.16f, 0), Quaternion.identity) as GameObject;
                tunnelClone.transform.rotation = Quaternion.AngleAxis(tunnelRotation, Vector3.up);
                
                //ignore the collision so we can travel through it
                IgnoredCollider = collisionInfo.collider;
                Physics.IgnoreCollision(CL, IgnoredCollider);

                MoveDir.x *= 0.2f;
                StartCoroutine(RestoreMoveSpeed(2.0f));
                Ability = abilityHandler.Abilities.None;
            }
        }
        else
        {
            CanDig = false;
        }
    }

    IEnumerator RestoreMoveSpeed(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (MoveDir.x > 0)
        {
            MoveDir.x = 1;
        }
        else
        {
            MoveDir.x = -1;
        }
    }

    void OnTriggerStay(Collider trigger)
    {
        if (trigger.tag == "hole")
        {
            //if that collider is a branch turn off collision with it
            if (CurrentCollider != null)
            {
                if (CurrentCollider.tag == "branch")
                {
                    Physics.IgnoreCollision(CL, CurrentCollider);
                }
            }
        }
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.tag == "hole" && trigger.transform.localScale.y > 0.1)
        {
            //if that collider is a branch turn off collision with it
            if (CurrentCollider != null)
            {
                if (CurrentCollider.tag == "branch")
                {
                    Physics.IgnoreCollision(CL, CurrentCollider);
                }
            }
        }
        if (trigger.tag == "exit")
        {
            var uiScript = UIScore.GetComponent<uiScore>();
            uiScript.addSavedUnit();

            Destroy(gameObject);
        }
        if (trigger.tag == "killplane")
        {
            var uiScript = UIScore.GetComponent<uiScore>();
            uiScript.addLostUnit();

            Destroy(gameObject);
        }
        if (trigger.tag == "tunnel")
        {
            //cast a ray in current direction to find the trunk we want to travel through
            Ray ray = new Ray(transform.position, new Vector3(1.25f * MoveDir.x, 0, 0));
            int layerMask = 1 << 9;

            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 1.25f, layerMask))
            {
                if (!_CollisionTimingCheck)
                {
                    IgnoredCollider = hit.collider;
                    Physics.IgnoreCollision(CL, IgnoredCollider);
                    _CollisionTimingCheck = true;
                    StartCoroutine(TimingCheck(0.05F));
                }
            }
        }
    }

    void OnTriggerExit(Collider trigger)
    {
        if (trigger.tag == "hole")
        {
            if (CurrentCollider != null)
            {
                if (CurrentCollider.tag == "branch")
                {
                    Physics.IgnoreCollision(CL, CurrentCollider, false);
                }
            }
        }
        if (trigger.tag == "tunnel")
        {
            if (IgnoredCollider != null && !_CollisionTimingCheck)
            {
                Physics.IgnoreCollision(CL, IgnoredCollider, false);
                IgnoredCollider = null;
                _CollisionTimingCheck = true;
                StartCoroutine(TimingCheck(0.05F));
            }
        }
    }

    IEnumerator TimingCheck(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _CollisionTimingCheck = false;
    }
}
