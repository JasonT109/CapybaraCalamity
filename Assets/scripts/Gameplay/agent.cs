using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
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
    public Vector3 TunnelOffset = new Vector3(0.125f, 0, 0);
    public Vector3 StepOffsetDistance = new Vector3(0.2f, 1.4f, 0);
    public Vector3 StepInitialOffset = new Vector3(0.8f, -0.133f, 0);
    public float StepAssistImpulse = 0.1f;
    public float StepDistanceCheck = 0.8f;
    public float BuilderMoveSpeed = 0.8f;
    public float BuilderPauseTime = 0.2f;

    [Header("Ability configuration:")]
    public abilityHandler.Abilities Ability;
    private abilityHandler _AbilityHandler;

    [Header ("Collision configuration:")]
    public Rigidbody RB;
    public Collider CL;
    public Collider CurrentCollider;
    public Collider IgnoredCollider;
    public List<Collider> IgnoredColliders = new List<Collider>();
    public float MinStepHeight = 0.12f;
    public float RayDistance = 0.35f;
    private bool _CollisionTimingCheck = false;

    [Header ("Prefab configuration:")]
    public GameObject Tunnel;
    public GameObject Step;
    public Animator AgentAnim;

    [HideInInspector]
    public SkinnedMeshRenderer ParachuteMesh;
    private SkinnedMeshRenderer[] _SkinnedMeshes;

    private GameObject UIScore;
    private PressGesture _PressGesture;
    [HideInInspector]
    public bool _BuildingStep;

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
        if (Ability == abilityHandler.Abilities.Builder)
            Debug.DrawRay(transform.position, MoveDir * StepDistanceCheck, Color.red);

        foreach (Collider c in IgnoredColliders)
            Physics.IgnoreCollision(CL, c);

        FallSpeed = -RB.velocity.y;

        AgentAnim.SetFloat("Fall_Speed", FallSpeed);

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

        if (Ability == abilityHandler.Abilities.Builder && !_BuildingStep)
        {
            if (ValidStepPosition())
            {
                MakeStep();
            }
        }
    }

    /** Make a step at the agents current position and orientation. */
    public void MakeStep()
    {
        if (MoveDir.x > 0)
            MoveDir.x = BuilderMoveSpeed;
        else
            MoveDir.x = -BuilderMoveSpeed;

        StartCoroutine(RestoreMoveSpeed(BuilderPauseTime));
        _BuildingStep = true;
        float StepRotation = 0f;
        Vector3 StepOffset = transform.position + StepInitialOffset;

        if (CurrentCollider.tag == "step")
            StepOffset = CurrentCollider.transform.position + new Vector3(StepOffsetDistance.x, StepOffsetDistance.y, StepOffsetDistance.z);

        if (MoveDir.x < 0)
        {
            StepRotation = 180f;

            if (CurrentCollider.tag == "branch")
                StepOffset = transform.position + new Vector3(-StepInitialOffset.x, StepInitialOffset.y, StepInitialOffset.z);

            if (CurrentCollider.tag == "step")
                StepOffset = CurrentCollider.transform.position + new Vector3(-StepOffsetDistance.x, StepOffsetDistance.y, StepOffsetDistance.z);
        }

        GameObject StepClone = Instantiate(Step, StepOffset, Quaternion.identity) as GameObject;
        StepClone.transform.rotation = Quaternion.AngleAxis(StepRotation, Vector3.up);
    }

    /** Check that we can build a step here. */
    public bool ValidStepPosition()
    {
        bool IsValid = false;

        //check we are standing on a branch and not falling
        if (CurrentCollider.tag == "branch" || CurrentCollider.tag == "step")
        {
            //check we have enough distance in front of us
            RaycastHit hit;

            string[] Layers = { "trunk", "stopper", "branch" };

            if (!Physics.Raycast(transform.position, MoveDir, out hit, StepDistanceCheck, LayerMask.GetMask(Layers)))
            {
                if (!Physics.Raycast(transform.position + (new Vector3 (StepDistanceCheck, 0, 0) * MoveDir.x), new Vector3(0, 1, 0), out hit, 0.75f, LayerMask.GetMask(Layers)))
                    IsValid = true;
                else
                    ToggleBuilder(false);
            }
            else
                ToggleBuilder(false);
        }

        return IsValid;
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
            AgentAnim.Play("fall_in", -1, 0.0f);
    }

    /** Falling at fast speed. */
    void ToggleFallingFast()
    {
        FallingFast = !FallingFast;
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

    /** Toggle the builder ability. */
    public void ToggleBuilder(bool ToggleOn)
    {
        if (Ability != abilityHandler.Abilities.Builder && ToggleOn)
            Ability = abilityHandler.Abilities.Builder;
        else
            Ability = abilityHandler.Abilities.None;
    }

    /** Toggle the gnawer ability. */
    public void ToggleGnawer()
    {
        if (Ability != abilityHandler.Abilities.Gnawer)
            Ability = abilityHandler.Abilities.Gnawer;
        else
            Ability = abilityHandler.Abilities.None;
    }

    /** Toggle the floater ability. */
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
        if (collisionInfo.collider.tag == "branch" || collisionInfo.collider.tag == "step")
        {
            CurrentCollider = collisionInfo.collider;
            CheckImpactSpeed();

            if (collisionInfo.collider.tag == "branch")
                CanDig = true;
            else
                CanDig = false;
        }
        else
            CanDig = false;

        if (collisionInfo.collider.tag == "trunk" || collisionInfo.collider.tag == "branch" || collisionInfo.collider.tag == "agent" )
        {
            if (Ability == abilityHandler.Abilities.Gnawer && collisionInfo.collider.tag == "trunk")
                MakeTunnel(collisionInfo.collider);

            if (collisionInfo.collider.tag == "agent")
                CheckAgentToAgentCollision(collisionInfo.collider);
            else if (Ability != abilityHandler.Abilities.Gnawer && !Falling)
                CheckAgentToEnviroCollision(collisionInfo);
        }
    }

    /** Check impact speed, are we going to survive? */
    private void CheckImpactSpeed()
    {
        if (FallSpeed > SplatSpeed)
        {
            var uiScript = UIScore.GetComponent<uiScore>();
            uiScript.addLostUnit();
            Destroy(gameObject);
        }
    }

    /** Check height of thing we have hit, can we step over it? */
    private void CheckAgentToEnviroCollision(Collision CollisionInfo)
    {
        if (CollisionInfo.collider.tag != "step")
        {
            Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y + MinStepHeight, transform.position.z), MoveDir);

            Debug.DrawRay(ray.origin, ray.direction, Color.blue, 5f, false);

            RaycastHit hit;

            string[] Layers = { "trunk", "stopper", "branch" };

            if (Physics.Raycast(ray.origin, ray.direction, out hit, RayDistance, LayerMask.GetMask(Layers)))
            {
                Debug.Log("Hit an obstacle: " + hit.transform.name);

                if (MoveDir.x > 0)
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
            else
                RB.AddForce(Vector3.up * StepAssistImpulse, ForceMode.Impulse);
        }
    }

    /** Check we aren't inside another agent if it is a stopper, set move direction */
    private void CheckAgentToAgentCollision(Collider _Collider)
    {
        Vector3 pos1 = transform.position;
        Vector3 pos2 = _Collider.transform.position;
        if (Vector3.Distance(new Vector3(pos1.x, 0, 0), new Vector3(pos2.x, 0, 0)) < 0.29f)
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

    /** Instantiates a tunnel object and ingores the given collider the agent can pass through. */
    private void MakeTunnel(Collider _Collider)
    {
        float TunnelXOffset = TunnelOffset.x;
        float TunnelRotation = 0;
        string GnawAnimation = "Gnaw_Right";
        if (MoveDir.x == -1)
        {
            TunnelXOffset = -TunnelOffset.x;
            TunnelRotation = 180;
            GnawAnimation = "Gnaw_Left";
        }

        AgentAnim.SetBool(GnawAnimation, true);

        GameObject TunnelClone = Instantiate(Tunnel, transform.position + new Vector3(TunnelXOffset, TunnelOffset.y, TunnelOffset.z), Quaternion.identity) as GameObject;
        TunnelClone.transform.rotation = Quaternion.AngleAxis(TunnelRotation, Vector3.up);

        IgnoredCollider = _Collider;
        Physics.IgnoreCollision(CL, IgnoredCollider);

        MoveDir.x *= 0.2f;
        StartCoroutine(RestoreMoveSpeed(2.0f));
    }

    IEnumerator RestoreMoveSpeed(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        if (MoveDir.x > 0)
            MoveDir.x = 1;
        else
            MoveDir.x = -1;

        if (Ability == abilityHandler.Abilities.Gnawer)
        {
            Ability = abilityHandler.Abilities.None;
            AgentAnim.SetBool("Gnaw_Left", false);
            AgentAnim.SetBool("Gnaw_Right", false);
        }
    }

    void OnTriggerStay(Collider trigger)
    {
        if (trigger.tag == "hole")
        {
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

            exitPoint exitPointScript = trigger.gameObject.GetComponent<exitPoint>();
            exitPointScript.SpawnParticleEffect(transform.position);

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
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.125f, transform.position.z), MoveDir, Color.red, 0.5f);

            Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y + 0.125f, transform.position.z), MoveDir);
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

        if (trigger.tag == "pickup")
        {
            var Pickup = trigger.GetComponent<AbilityPickup>();
            _AbilityHandler.AddAbility(Pickup.Ability, Pickup.Count);
            Pickup.SpawnParticleEffect();
            Destroy(trigger.gameObject);
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
