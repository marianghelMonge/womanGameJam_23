using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonPattern<T> : MonoBehaviour where T : SingletonPattern<T>
{
public bool dontDestroyOnLoad = false; 

public static T Instance;
  protected virtual void Awake()
  {
  if(Instance != null )
  {
	  Destroy(this);
	  return;
  }
  
  Instance = this as T;
  if (dontDestroyOnLoad)
  {
	  DontDestroyOnLoad(this);
  }
  }
}
