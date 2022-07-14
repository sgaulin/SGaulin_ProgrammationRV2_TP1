using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDestroy : MonoBehaviour
{

    private GameObject player;    

    public float dist = 0f;
    // Start is called before the first frame update
    void OnEnable()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist > 40)
        {
            Destroy(gameObject);
        }
    }
}
