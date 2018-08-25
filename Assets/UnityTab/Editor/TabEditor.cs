using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityTab;

public class TabEditor : Editor
{

	[MenuItem ("UnityTab/LaunchWindowStart")]
	static void LaunchWindowStart ()
	{
		UnityTab.TabMain.Launch (
			(int index) =>
			{
				var path = UnityTab.TabMain.GetFilePath[index];
				var tyWindowLayout = Type.GetType ("UnityEditor.WindowLayout,UnityEditor");
				var method = tyWindowLayout.GetMethod ("LoadWindowLayout", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static, null, new Type[] { typeof (string), typeof (bool) }, null);
				var assetPath = Path.Combine (Directory.GetCurrentDirectory (), path);
				method.Invoke (null, new object[] { assetPath, false });
			});
	}

	[MenuItem ("UnityTab/LaunchWindowStop")]
	static void LaunchWindowStop ()
	{
		UnityTab.TabMain.Stop ();
	}
}