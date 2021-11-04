using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.1f, 0);
        
        if(transform.position.y < -5.0f) {
            Destroy(gameObject);
        }

        Vector2 p1 = transform.position; //화살 중심 좌표
        Vector2 p2 = this.player.transform.position; //플레이어 중심 좌표
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f; //화살 반경
        float r2 = 1.0f; //캐릭터 반경

        if(d < r1 + r2) { //충돌시
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();
            Destroy(gameObject);
        }
    }
}
