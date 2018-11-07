using KennethDevelops.ProLibrary.Managers;
using UnityEngine;

public class Player : MonoBehaviour{

	public float impulseSpeed = 3f;
	public float rotateAngle = 100f;

	public Transform bulletSpawn;

	private Rigidbody _rb;
	
	
	void Start (){
		_rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
		if (Input.GetAxisRaw("Vertical") == 1)
			Impulse();
		
		Rotate(Input.GetAxisRaw("Horizontal"));

		if (Input.GetKeyDown(KeyCode.Space)){
			PoolManager.GetInstance("BulletPool").AcquireObject<Bullet>(bulletSpawn.position, transform.rotation);
		}
	}

	private void Impulse(){
		_rb.velocity += transform.forward * impulseSpeed * Time.deltaTime;
	}

	private void Rotate(float rotateDirection){
		var rotation = Quaternion.AngleAxis(rotateDirection * rotateAngle * Time.deltaTime, Vector3.up);
		transform.forward = rotation * transform.forward;
	}
}
