using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KennethDevelops.ProLibrary.Managers;
using KennethDevelops.ProLibrary.DataStructures.Pool;
using KennethDevelops.ProLibrary.Extensions;

public class Bullet : MonoBehaviour, IPoolObject{

	public float speed = 10;
	
	
	void Update (){
		transform.position += transform.forward * speed * Time.deltaTime;

		if (!Camera.main.IsInFov(gameObject))
			PoolManager.GetInstance("BulletPool").Dispose(this);
	}

	public void OnAcquire(){
		
	}

	public void OnDispose(){
		
	}
}
