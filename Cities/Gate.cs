using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            PlayerStats.Instance.CurrentCityName = PlayerStats.Instance.DestinationCityName;
            SceneManager.LoadScene("WorldMap");
        }
    }
}
