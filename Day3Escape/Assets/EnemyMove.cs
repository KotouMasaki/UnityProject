using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	private CharacterController enemyController;
	private Animator animator;
	//　目的地
	private Vector3 destination;
	private Vector3 Position1;
	[SerializeField]
	private float Position2_x, Position2_z;
	[SerializeField]
	private float Position3_x, Position3_z;
	[SerializeField]
	private float Position4_x, Position4_z;
	//目的地を切り替えるフラグ
	[SerializeField]
	private bool therdPoint;
	[SerializeField]
	private bool fourthPoint;
	private int RootCounter;
	//private bool countDown;
	//　歩くスピード
	[SerializeField]
	private float walkSpeed = 1.0f;
	//　速度
	private Vector3 velocity;
	//　移動方向
	private Vector3 direction;
	//　到着フラグ
	private bool arrived;
	//　待ち時間
	[SerializeField]
	private float waitTime = 5f;
	//　経過時間
	private float elapsedTime;


	// Use this for initialization
	void Start()
	{
		enemyController = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
		Position1 = transform.position;
		destination = new Vector3(Position2_x, 0f, Position2_z);
		velocity = Vector3.zero;
		arrived = false;
		RootCounter = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if (!arrived)
		{
			if (enemyController.isGrounded)
			{
				velocity = Vector3.zero;
				animator.SetBool("Speed", true);
				direction = (destination - transform.position).normalized;
				transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
				velocity = direction * walkSpeed;
				//Debug.Log(destination);
			}
			velocity.y += Physics.gravity.y * Time.deltaTime;
			enemyController.Move(velocity * Time.deltaTime);

			//　目的地に到着したかどうかの判定
			if (Vector3.Distance(transform.position, destination) < 0.5f)
			{
				arrived = true;
				animator.SetBool("Speed", false);
				//Debug.Log(arrived);
			}
        }
        else
        {
			elapsedTime += Time.deltaTime;

			//　待ち時間を越えたら次の目的地を設定
			if (elapsedTime > waitTime)
			{
				if(!therdPoint && !fourthPoint)
                {
					SecondPoint();
                }
				if(therdPoint)
                {
					TherdPoint();
                }
				if(fourthPoint)
                {
					FourthPoint();
                }
				arrived = false;
				elapsedTime = 0f;
			}
			Debug.Log(elapsedTime);
		}
	}

	void SecondPoint()
    {
		//Debug.Log("到達");
		if (RootCounter > 2) RootCounter = 0;
		RootCounter++;
		switch (RootCounter)
		{
			case 1:
				destination = new Vector3(Position1.x, 0f, Position1.z);
				break;
			case 2:
				destination = new Vector3(Position2_x, 0f, Position2_z);
				break;
		}
	}
	void TherdPoint()
    {
		//Debug.Log("到達");
		if (RootCounter > 4) RootCounter = 0;
		RootCounter++;
		switch(RootCounter)
        {
			case 1:
				destination = new Vector3(Position3_x, 0f, Position3_z);
				break;
			case 2:
				destination = new Vector3(Position2_x, 0f, Position2_z);
				break;
			case 3:
				destination = new Vector3(Position1.x, 0f, Position1.z);
				break;
			case 4:
				destination = new Vector3(Position2_x, 0f, Position2_z);
				break;
		}
	}

	void FourthPoint()
    {
		//Debug.Log("到達");
		if (RootCounter > 6) RootCounter = 0;
		RootCounter++;
		switch (RootCounter)
		{
			case 1:
				destination = new Vector3(Position3_x, 0f, Position3_z);
				break;
			case 2:
				destination = new Vector3(Position4_x, 0f, Position4_z);
				break;
			case 3:
				destination = new Vector3(Position3_x, 0f, Position3_z);
				break;
			case 4:
				destination = new Vector3(Position2_x, 0f, Position2_z);
				break;
			case 5:
				destination = new Vector3(Position1.x, 0f, Position1.z);
				break;
			case 6:
				destination = new Vector3(Position2_x, 0f, Position2_z);
				break;
		}
	}
}
