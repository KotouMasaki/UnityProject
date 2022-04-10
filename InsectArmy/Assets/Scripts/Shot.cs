using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField]
    private float laserSpeed;
    [SerializeField]
    private float LifeTime;
    private int count;

    [SerializeField]
    private GameObject Laser;
    [SerializeField]
    private GameObject firingPoint;

    void Update()
    {
        count += 1;

        if (Input.GetKey(KeyCode.Space) & count % 10 == 0)
        {
            // レ－ザ－を発射する
            LauncherShot();
        }
    }

    //レ－ザ－の発射
    private void LauncherShot()
    {
        // レーザーを発射する場所を取得
        Vector3 laserPosition = firingPoint.transform.position;
        // 上で取得した場所に、"laser"のPrefabを出現させる
        GameObject newLaser = Instantiate(Laser, laserPosition, transform.rotation);
        // 出現させたレーザーのforward(z軸方向)
        Vector3 direction = newLaser.transform.forward;
        // 弾の発射方向にmewLaserのz方向(ローカル座標)を入れ、レーザーオブジェクトのrigidbodyに衝撃力を加える
        newLaser.GetComponent<Rigidbody>().AddForce(direction * laserSpeed, ForceMode.Impulse);
        // 出現させたレーザーの名前を"Laser"に変更
        newLaser.name = Laser.name;
        // 出現させたボールを設定した時間で消す
        Destroy(newLaser, LifeTime);
    }
}