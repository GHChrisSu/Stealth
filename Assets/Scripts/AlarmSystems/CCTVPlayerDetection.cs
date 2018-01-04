using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTVPlayerDetection : MonoBehaviour {

    private GameObject player;
    private LastPlayerSighting lastPlayerSighting;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
        lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject  == player)
        {
            Vector3 relPlayer = player.transform.position - transform.position;
            RaycastHit hit;
            if(Physics.Raycast(transform.position, relPlayer, out hit)){
                if(hit.collider.gameObject == player) {
                    lastPlayerSighting.position = player.transform.position;
                }
            }
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Vector3 relPlayer = player.transform.position - transform.position;
    //    RaycastHit hit;
    //    if (Physics.Raycast(transform.position, relPlayer, out hit))
    //    {
    //        Gizmos.DrawRay(transform.position, relPlayer);
    //    }
    //}

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
