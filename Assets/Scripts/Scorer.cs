using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    [SerializeField] ParticleSystem celebration;
    [SerializeField] int scorePoints = 50;
    [SerializeField] AnimationCurve sizeCurve;

    int Score = 0;
    int txtFontSize;

    Text txtScore;

    private void Start()
    {
        txtScore = GetComponent<Text>();
        txtFontSize = txtScore.fontSize;
    }

    public void IncreaseScore()
    {        
        Score += scorePoints;
        StartCoroutine(ShowOnText());
        StartCoroutine(BonusTime());
    }

    IEnumerator ShowOnText()
    {
        txtScore.text = Score.ToString();
        float animProgress = 0f;

        while(animProgress < 1f)
        {
            txtScore.fontSize = txtFontSize + (int)(sizeCurve.Evaluate(animProgress) * 100);
            animProgress += Time.deltaTime;
            yield return null;
        }
        txtScore.fontSize = txtFontSize;
    }

    IEnumerator BonusTime()
    {
        scorePoints *= 4;
        yield return new WaitForSeconds(1);
        scorePoints /= 2;
        yield return new WaitForSeconds(1);
        scorePoints /= 2;
    }

    public void CelebrateGameOver()
    {
        celebration.Play();
    }
}
