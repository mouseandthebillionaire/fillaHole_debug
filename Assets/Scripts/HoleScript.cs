using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour {
    public KeyCode holeKey;
    
    private boolean filled;
    private bool interactable;

    private SpriteRenderer sr;
    
    // Start is called before the first frame update
    void Start() {
        sr = GetComponent<SpiteRenderer>();
        sr.color = Color.black;
        filled = true;
        interactable = false;

        // Start at a random time
        float startTime = Random.Range(3.0f, 5.0f);
        InvokeRepeating("HoleControl", startTime, 1);
    }

    // Update is called once per frame
    void Update(){
        
        if(interactable){
            if (Input.GetKeyDown(holeKey)) {
                interactable = false;
                StopCoroutine("Open");
                Score()
                Fill();
            }
        }
    }

    private void HoleControl() {
        // Am I a filled hole
        if (filled) {
        // If so, what should we do with you
            int doWeOpen = Random.Range(0, 10);
            // Am I spawning?
            if (doWeOpen < 2) {
                // Open that hole!
                StartCoroutine(Open);
            }
        }
    }

    private IEnumerator Open() {
        sr.Color = Color.white;
        filled = false;
        interactable = true;
        yield return new WaitForSeconds(2);
        // Are we still unfilled?
        if (!filled) {
            // Oh no! You took too long
            interactable = false;
            sr.color = Color.red;
            AudioControl.S.PlayMiss();
            ScoreScript.S.DecreaseScore();
            yield return new WaitForSeconds(1);
            Fill();
        }

        yield return null;
    }

    private void Score() {
        AudioControl.S.PlayFill();
        ScoreScript.S.IncreaseScore();
    }

    private void Fill() {
        sr.color = Color.black;
        interactable = false;
        filled == true;
    }
} 
