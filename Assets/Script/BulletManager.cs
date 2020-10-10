using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System Serializable]
public class BulletManager : MonoBehaviour
{
    public GameObject bullet;
    public int MaxBullets;
    private Queue<GameObject> m_bulletpool;
    // Start is called before the first frame update
    void Start()
    {
        _BuildBulletPool();
    }
    private void _BuildBulletPool()
    {
        m_bulletpool = new Queue<GameObject>();
        for(int count = 0; count < MaxBullets; count++)
        {
            var tempbullet = Instantiate(bullet); // instanciate an empty buller
            tempbullet.SetActive(false); //false it is invisible
            tempbullet.transform.parent = transform; // temp bullet is the children of the bullet manager.
            m_bulletpool.Enqueue(tempbullet); //put i back in the pool
        }
    }

    public GameObject GetBullet(Vector3 position)
    {
        //get bullet function
        var newBullet = m_bulletpool.Dequeue(); //return the bullet
        newBullet.SetActive(true); // goes in the seen
        newBullet.transform.position = position;

        return newBullet;
    }

    public void ReturnBullet(GameObject returnbullet)
    {
        returnbullet.SetActive(false);
        m_bulletpool.Enqueue(returnbullet); //this put it back into the pool
    }
}
