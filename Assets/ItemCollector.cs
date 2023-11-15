using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int telur = 0;

    [SerializeField] private Text telurTeks;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("telur"))
        {
            Destroy(collision.gameObject);
            telur++;
            telurTeks.text = "telur:" + telur;
        }
    }
}
