using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Vector3 startPosition;
    public GameObject particle;

    public TrailRenderer trailRenderer;

    private float startSpeed;

    void Start()
    {
        startPosition = transform.position;
        startSpeed = speed;
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        speed = startSpeed;
        trailRenderer.enabled = false;
        Invoke(nameof(Launch), 3.0f);
    }

    private void Launch()
    {
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
        trailRenderer.enabled = true;
        particle.transform.position = new Vector3(0, 0, -100);
    }

    public void Boost(float amount)
    {
        speed = speed + amount;
        rb.velocity = new Vector2(speed, speed);
    }
}
