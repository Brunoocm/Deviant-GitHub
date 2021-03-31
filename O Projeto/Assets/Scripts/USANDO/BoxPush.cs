using UnityEngine;
using System.Collections;

public class BoxPush : MonoBehaviour
{
	public Rigidbody2D rbox;
	public float defaultMass;
	public float imovableMass;
	public bool beingPushed;
	float xPos;

	public Vector3 lastPos;

	public int mode;
	public int colliding;


	void Start()
	{
		xPos = transform.position.x;
		lastPos = transform.position;
	}

	public void Update()
    {
		Physics2D.IgnoreLayerCollision(12, 12);
	}

	void FixedUpdate()
	{
		if (mode == 0)
		{
			if (beingPushed == false)
			{
				rbox.constraints = RigidbodyConstraints2D.FreezeAll;
				transform.position = new Vector3(xPos, transform.position.y);
			}
			else
				rbox.constraints = ~RigidbodyConstraints2D.FreezePositionX;
				xPos = transform.position.x;
		}
		else if (mode == 1)
		{

			if (beingPushed == true)
			{
				
				GetComponent<Rigidbody2D>().mass = imovableMass;

			}
			else
			{
				
				GetComponent<Rigidbody2D>().mass = defaultMass;

			}

		}
	}


}