using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    public void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);

    }
    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene(); //carrega proxima scene
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }
    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners(); //qdo acabar o tempo, chama o stopspawners
    }

    private void StopSpawners() //para os 5 spawners em sequencia por meio de um foreach
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
