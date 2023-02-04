using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    public static int count = 0;

    public GameObject perk;

    public Text text;
    

    // public void IncrementCount()
    // {
    //     count++;
    // }

    public void Update(){

        var halved = count / 2;
        
        if (halved == 20)
        {
            StartCoroutine(perkMessage());
        }
        text.text = "KILLS: " + halved.ToString();

    }

    IEnumerator perkMessage(){
        Instantiate(perk, transform.position, transform.rotation);
        yield return new WaitForSeconds(2f);

    }
}
