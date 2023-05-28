using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBeahviours : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float patrolSpeed = 2f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float pauseDuration = 1f;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float chaseSpeed = 3f;

    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private Animator animator;

    private Transform player;
    private int currentPatrolIndex;
    private bool isPatrolling = true;
    private bool isChasingPlayer = false;
    private bool isAttacking = false;

    private Collider2D detectionCollider;
    private float lastAttackTime = 0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the child collider for detection range
        detectionCollider = GetComponentInChildren<Collider2D>();
        detectionCollider.isTrigger = true;
    }

    private void Update()
    {
        if (isChasingPlayer)
        {
            ChasePlayer();
        }
        else if (isPatrolling)
        {
            Patrol();
        }
        else if (isAttacking)
        {
            Attack();
        }
    }

    private void Patrol()
    {
        if (patrolPoints.Length == 0)
            return;

        // Move towards the current patrol point
        Transform currentPatrolPoint = patrolPoints[currentPatrolIndex];
        transform.position = Vector2.MoveTowards(transform.position, currentPatrolPoint.position, patrolSpeed * Time.deltaTime);

        // Rotate towards the movement direction
        Vector2 direction = currentPatrolPoint.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Check if reached patrol point
        if (Vector2.Distance(transform.position, currentPatrolPoint.position) < 0.1f)
        {
            // Pause and rotate towards the next patrol point
            StartCoroutine(RotateTowardsNextPatrolPoint());
        }
    }

    private System.Collections.IEnumerator RotateTowardsNextPatrolPoint()
    {
        isPatrolling = false;

        // Get the next patrol point
        Transform nextPatrolPoint = patrolPoints[(currentPatrolIndex + 1) % patrolPoints.Length];

        // Calculate the rotation direction
        Vector2 direction = nextPatrolPoint.position - transform.position;
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate towards the next patrol point
        while (Mathf.Abs(Mathf.DeltaAngle(transform.rotation.eulerAngles.z, targetAngle)) > 0.5f)
        {
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }

        // Pause for a specified duration
        yield return new WaitForSeconds(pauseDuration);

        // Move to the next patrol point
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        isPatrolling = true;
    }

    private void ChasePlayer()
    {
        // Move towards the player
        transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);

        // Rotate towards the player
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Check if the player is within attack range
        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            isChasingPlayer = false;
            isAttacking = true;
        }
    }

    private void Attack()
    {
        // Stop movement and play attack animation
        animator.SetTrigger("Attack");

        // Check if enough time has passed since the last attack
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            // Perform the attack logic here
            // ...
            // Reset the attack cooldown timer
            lastAttackTime = Time.time;
        }

        // Rotate towards the player during attack animation
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPatrolling = false;
            isChasingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isChasingPlayer = false;
            isPatrolling = true;
        }
    }
}