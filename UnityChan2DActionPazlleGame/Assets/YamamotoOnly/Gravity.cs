using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour
{

    public float Gravitysize=3.5f;

	//重力加速度.
	private const float gravitationalAcceleration = 9.81f;

	/// <summary>
	/// 重力方向を変更する.
	/// </summary>
	/// <param name="direction">重力の向き.</param>
	private void Change (Vector2 direction)
	{
        //引数のVecotr2を単位ベクトルに正規化し重力加速度を掛ける.
        Physics2D.gravity = direction.normalized * Gravitysize;//gravitationalAcceleration;
		Debug.Log (Physics2D.gravity);
	}

	private void Awake ()
	{
        //Startが実行される前に初期重力を設定する.
        Physics2D.gravity = Vector3.up * Gravitysize;//gravitationalAcceleration;
	}

	private void Update ()
	{
		//水平入力と垂直入力から入力方向を調べる.
		Vector2 InputDirection;
		InputDirection.x = Input.GetAxis ("Horizontal");
		InputDirection.y = Input.GetAxis ("Vertical");
		//入力が0でなければ、重力方向を変更する.
		if (InputDirection.magnitude > 0) {
			Change (InputDirection);
		}
	}
    
}
