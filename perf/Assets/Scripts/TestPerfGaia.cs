using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Profiling;

public class TestPerfGaia : MonoBehaviour
{
    private bool start = false;
    [SerializeField] private GameObject Bullet;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            DoStuffOnStrings();
        }
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            DoLotString();
            DoStringBuilder();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            GetComponentPerf();
            //TryGetComponentPerf();
            
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            start = !start;
            StartCoroutine(InstantiateBullet());
        }
        
    }

    private IEnumerator InstantiateBullet()
    {
        Profiler.BeginSample("Test Bullet");
        while (start == true)
        {
            
            Instantiate(Bullet);
            yield return new WaitForSeconds(1);
            
        }
        Profiler.EndSample();

        
    }

    private void DoStuffOnStrings()
    {
        Profiler.BeginSample("Test Simple");
        
        string Word ="";

        for (int i = 0; i < 1500; i++)
        {
            Word += "Miam" + i;
        }
        
        Profiler.EndSample();
    }
    
    private void GetComponentPerf()
    {
        Debug.Log("GetComponent");
        Profiler.BeginSample("Test GetComponent");
        

        for (int i = 0; i < 1000; i++)
        {
            
            this.GetComponentsInChildren<Rigidbody>();
        }
        
        Profiler.EndSample();
        
    }
    private void TryGetComponentPerf()
    {
        Debug.Log("Try GetComponent");
        Profiler.BeginSample("Test TryGetComponent");
        

        for (int i = 0; i < 1000; i++)
        {
            if (TryGetComponent<Rigidbody>(out Rigidbody t))
            {
                t.position = Vector3.zero;
            }

        }
        
        Profiler.EndSample();
    }
    
    private void DoLotOfStuffOnStringsWithCapacity()
    {
        Profiler.BeginSample("Test 3");
        
        string sentence ="";
        
        for (int j = 0; j < 100; j++)
        {
            for (int i = 0; i < 1500; i++)
            {
                sentence += "unMot" + i;
            }
        }
        Profiler.EndSample();
    }
    
    private void DoLotOfStuffOnStringsWithCapacityAndLocalVar()
    {
        Profiler.BeginSample("Test 4");
        
        string sentence ="";
        string s;
        for (int j = 0; j < 100; j++)
        {
            for (int i = 0; i < 1500; i++)
            {
                s = "unMot" + i;
                sentence += s;
            }
        }
        Profiler.EndSample();
    }
    
    private void DoLotString()
    {
        Profiler.BeginSample("Test NoBuilder");

        string sentence ="";
        
        for (int j = 0; j < 100; j++)
        {
            for (int i = 0; i < 1500; i++)
            {
                sentence += $"unMot {i}";
            }
        }
        Profiler.EndSample();
    }
    
    private void DoStringBuilder()
    {
        Profiler.BeginSample("Test Builder");
        var builder = new StringBuilder();
        for (int j = 0; j < 100; j++)
        {
            for (int i = 0; i < 1500; i++)
            {
                builder.Append($"unMot {i}");
            }
        }
        Profiler.EndSample();
    }
    
    
}
