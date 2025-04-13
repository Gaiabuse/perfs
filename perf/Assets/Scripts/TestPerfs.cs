using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Profiling;

public class TestPerfs : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            DoStuffOnStrings();
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            DoLotOfStuffOnStrings();
        }
        
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            DoStuffOnStrings();
            DoLotOfStuffOnStrings();
        }
                
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            DoStuffOnStrings();
            DoLotOfStuffOnStrings();
            DoLotOfStuffOnStringsWithCapacity();
            DoLotOfStuffOnStringsWithCapacityAndLocalVar();
            DoLotOfStuffOnStringsWithCapacityAndInterpolation();
        }
        
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            DoStuffOnStrings();
            DoLotOfStuffOnStrings();
            DoLotOfStuffOnStringBuilder();
            DoLotOfStuffOnStringBuilderInterpolation();
        }
    }

    private void DoStuffOnStrings()
    {
        Profiler.BeginSample("Test 1");
        
        var allString = new List<string>();

        for (int i = 0; i < 1500; i++)
        {
            allString.Add("unMot" + i);
        }
        
        Profiler.EndSample();
    }
    
    private void DoLotOfStuffOnStrings()
    {
        Profiler.BeginSample("Test 2");
        
        var allString = new List<string>();
        
        for (int j = 0; j < 100; j++)
        {
            for (int i = 0; i < 1500; i++)
            {
                allString.Add("unMot" + i);
            }
        }
        Profiler.EndSample();
    }
    
    private void DoLotOfStuffOnStringsWithCapacity()
    {
        Profiler.BeginSample("Test 3");
        
        var allString = new List<string>(1500*100);
        
        for (int j = 0; j < 100; j++)
        {
            for (int i = 0; i < 1500; i++)
            {
                allString.Add("unMot" + i);
            }
        }
        Profiler.EndSample();
    }
    
    private void DoLotOfStuffOnStringsWithCapacityAndLocalVar()
    {
        Profiler.BeginSample("Test 4");
        
        var allString = new List<string>(1500*100);
        string s;
        for (int j = 0; j < 100; j++)
        {
            for (int i = 0; i < 1500; i++)
            {
                s = "unMot" + i;
                allString.Add(s);
            }
        }
        Profiler.EndSample();
    }
    
    private void DoLotOfStuffOnStringsWithCapacityAndInterpolation()
    {
        Profiler.BeginSample("Test 5");

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
    
    private void DoLotOfStuffOnStringBuilder()
    {
        Profiler.BeginSample("Test 10");
        var builder = new StringBuilder();
        for (int j = 0; j < 100; j++)
        {
            for (int i = 0; i < 1500; i++)
            {
                builder.Append("unMot" + i);
            }
        }
        Profiler.EndSample();
    }
 
    private void DoLotOfStuffOnStringBuilderInterpolation()
    {
        Profiler.BeginSample("Test 11");
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
