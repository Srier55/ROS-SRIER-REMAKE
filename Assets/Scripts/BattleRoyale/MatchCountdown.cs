
using UnityEngine;
using System;
using System.Collections;

public class MatchCountdown : MonoBehaviour
{
    public int countdownSeconds = 10;

    public event Action<int> OnCountdownChanged;
    public event Action OnCountdownFinished;

    private bool isCountingDown;

    public void StartCountdown()
    {
        if (isCountingDown) return;

        StartCoroutine(CountdownRoutine());
    }

    private IEnumerator CountdownRoutine()
    {
        isCountingDown = true;

        for (int seconds = countdownSeconds; seconds > 0; seconds--)
        {
            OnCountdownChanged?.Invoke(seconds);
            Debug.Log("Battle starts in: " + seconds);

            yield return new WaitForSeconds(1f);
        }

        isCountingDown = false;

        OnCountdownChanged?.Invoke(0);
        OnCountdownFinished?.Invoke();

        Debug.Log("Battle begins!");
    }
}
