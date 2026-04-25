using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBranch : MonoBehaviour
{
    public string NextStage;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Choice"))
        {
            NextStage = other.gameObject.name;
        }

        if (other.CompareTag("GoNextStage"))
        {
            Debug.Log("a");
            if (!(string.IsNullOrEmpty(NextStage)))
            {
                GoNextStage();
            }
        }
    }

    private void GoNextStage()
    {
        SceneManager.LoadScene(NextStage);
    }

}
