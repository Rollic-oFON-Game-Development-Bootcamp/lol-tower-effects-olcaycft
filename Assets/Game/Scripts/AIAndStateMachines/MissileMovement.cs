using UnityEngine;

public class MissileMovement : MonoBehaviour
{
    private Vector3 destination;
    [SerializeField] private GameObject explosionPre;

    private void Awake()
    {
        LolTower.HitMinion += Destination;
    }

    private void Destination(Vector3 destination)
    {
        this.destination = destination;
    }

    void Update()
    {
        MoveMissile();
    }

    private void MoveMissile()
    {
        var missilePos = transform.position;
        transform.position = Vector3.MoveTowards(missilePos,
            Vector3.Lerp(missilePos, destination, 5f), 5f * Time.deltaTime);

        var sqrDistanceToTarget = (destination - transform.position).sqrMagnitude;
        if (sqrDistanceToTarget < 0.001f)
        {
            Destroy(gameObject);
            GameObject explosion = Instantiate(explosionPre, transform.position, Quaternion.identity);
            Destroy(explosion,2f);
        }
    }
}