using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text timerText;
    [SerializeField] int elapsedTime = 60;
    [SerializeField] GameOverFunction onGameOver;

    void Start() => CountTime();

    void CountTime(bool goingUp = true)
    {
        timerText = GetComponent<Text>();
        StartCoroutine(goingUp ? CountUp() : Countdown());
    }

    IEnumerator Countdown()
    {
        while (elapsedTime > 0)
        {
            yield return new WaitForSeconds(1);
            elapsedTime--;
            timerText.text = elapsedTime.ToString();
        }
        onGameOver.Raise(false);
    }

    IEnumerator CountUp()
    {
        elapsedTime = 0;
        while (true)
        {
            yield return new WaitForSeconds(1);
            elapsedTime++;
            timerText.text = elapsedTime.ToString();
        }
    }

    IEnumerator SlowTime()
    {
        Time.timeScale = .4f;
        yield return new WaitForSeconds(1);
        Time.timeScale = 1f;
    }

    public void OnGameOver()
    {
        StopAllCoroutines();
        StartCoroutine(GameEndingRoutine());
    }

    IEnumerator GameEndingRoutine()
    {
        yield return new WaitForSeconds(3);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

        public void BulletTime() => StartCoroutine(SlowTime());
}
