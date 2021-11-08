using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour
{
    public int cansCount;
    public GameObject bal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cans")
        {
            other.gameObject.SetActive(false);
            cansCount--;

            if (cansCount == 0)
            {
                Invoke(nameof(RestartGame), 2f);
            }
        }

        if (other.tag == "Player")
        {
            other.gameObject.SetActive(false);

            if (cansCount != 0)
            {
                Instantiate(bal);
            }
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
