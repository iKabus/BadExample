using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Rigibody _prefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _cooldown;

    private void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        WaitForSecondsRealtime waitingTime = new WaitForSecondsRealtime(_cooldown);

        while (enabled)
        {
            yield return waitingTime;

            Vector3 direction = (_target.position - transform.position).normalized;
            Rigidbody newBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            newBullet.transform.up = direction;
            newBullet.velocity = direction * _speed;
        }
    }
}