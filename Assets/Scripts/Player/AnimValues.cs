using UnityEngine;
using System.Collections.Generic;

public class AnimValues : MonoBehaviour
{
    public string valuename;
    public string valuetype;
    public string value;
    public List<string> stringNames = new List<string>();
    public List<string> boolNames   = new List<string>();
    public List<string> intNames    = new List<string>(); 
    public List<string> stringVals  = new List<string>();
    public List<bool> boolVals      = new List<bool>();
    public List<int> intVals        = new List<int>();

    public void LogEvent(string msg)
    {
        string[] substring = msg.Split(',');
        valuename = substring[0];
        valuetype = substring[1];
        value = substring[2];
        if (valuename.Length > 0)
        {
            if (valuetype.Length > 0)
            {
                if (valuetype == "string")
                {
                    if (stringNames.IndexOf(valuename) != -1)
                    {
                        stringVals[stringNames.IndexOf(valuename)] = value;
                    }
                    else
                    {
                        stringNames.Add(valuename);
                        stringVals.Add(value);
                    }
                }
                else if (valuetype == "boolean")
                {
                    if (boolNames.IndexOf(valuename) != -1)
                    {
                        if (value == "true")
                        {
                            boolVals[boolNames.IndexOf(valuename)] = true;
                        }
                        else if (value == "false")
                        {
                            boolVals[boolNames.IndexOf(valuename)] = false;
                        }
                        else
                        {
                            Debug.LogError("given value does not fall in true or false");
                            Debug.Log(value);
                        }
                    }
                    else
                    {
                        if (value == "true")
                        {
                            boolVals.Add(true);
                        }
                        else if (value == "false")
                        {
                            boolVals.Add(false);
                        }
                        else
                        {
                            Debug.LogError("given value does not fall in true or false");
                            Debug.Log(value);

                        }
                    }

                }
                else if (valuetype == "integer")
                {
                    if (intNames.IndexOf(valuename) != -1)
                    {
                        int intval;
                        if (int.TryParse(value, out intval))
                        {
                            intVals[intNames.IndexOf(valuename)] = intval;
                        }
                        else
                        {
                            Debug.LogError("failed to parse as int");
                            Debug.Log(value);
                        }
                    }
                    else
                    {
                        int intval;
                        if (int.TryParse(value, out intval))
                        {
                            intVals.Add(intval);
                        }
                        else
                        {
                            Debug.LogError("failed to parse as int");
                            Debug.Log(value);
                        }
                    }
                }
            }
        }
    }
}
