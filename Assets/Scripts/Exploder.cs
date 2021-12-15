using System.Collections;

using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] ParticleSystem _explosion;
    [SerializeField] GameObject _body;
    [SerializeField] AnimationCurve _moveCurve;
    [SerializeField] BlockLostAction blockLostAction;
    [SerializeField] GameOverFunction onGameOver;

    bool _isAlive = true;

    private void Start() => StartCoroutine(Move());

    private void OnTriggerEnter(Collider other)
    {
        if(_isAlive && other.GetComponent<Mover>() != null)
        {
            _isAlive = false;
            StopAllCoroutines();
            StartCoroutine(Explode());

            blockLostAction.Raise();
            if (transform.parent.childCount == 1) onGameOver.Raise(true);
        }         
    }

    IEnumerator Move()
    {
        while (true)
        {
            float progress = 0f;
            float xPos = Random.Range(-8f, 8f);
            float zPos = Random.Range(-8f, 8f);

            while(progress < 1)
            {                
                float yPos = _moveCurve.Evaluate(progress);
                _body.transform.position = new Vector3(xPos, yPos, zPos);
                progress += Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator Explode()
    {
        _body.GetComponent<MeshRenderer>().enabled = false;
        _explosion.Play();

        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
