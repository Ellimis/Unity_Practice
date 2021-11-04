using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;
    float threshold = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();   
        this.animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // Y 방향의 속도가 0 일때만 점프 가능
        // Input.GetKeyDown(KeyCode.Space) 스페이스 바
        // 마우스와 화면 탭은 GetMouseButtonDown(0) 으로
        if((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && this.rigid2D.velocity.y == 0) {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        int key = 0; //안움직일 때
        if(Input.GetKey(KeyCode.RightArrow)) key = 1; //우측으로 갈 때
        if(Input.GetKey(KeyCode.LeftArrow)) key = -1; //좌측으로 갈 때
        //모바일을 위한 가속도
        if(Input.acceleration.x > this.threshold) key = 1;
        if(Input.acceleration.x < this.threshold) key = -1;

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        if(speedx < this.maxWalkSpeed) {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        if(key != 0) {
            transform.localScale = new Vector3(key, 1, 1);
        }

        if(this.rigid2D.velocity.y == 0) {
            // 플레이어의 속도에 비례
            this.animator.speed = speedx / 2.0f;
        } else {
            this.animator.speed = 1.0f;
        }

        if(transform.position.y < -10) {
            SceneManager.LoadScene("GameScene");
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("골");   
        SceneManager.LoadScene("ClearScene"); 
    }
}
