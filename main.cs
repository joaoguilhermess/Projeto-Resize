using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;

class Resizes {
	[DllImport("user32.dll")]
	private static extern IntPtr GetForegroundWindow();

	[DllImport("user32.dll")]
	private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int width, int height, bool repaint);

	[DllImport("user32.dll")]
	private static extern Int32 GetWindowThreadProcessId(IntPtr hwnd, uint lpdwPId);

	static void Main() {
		for (var i = 0; i < 2; i++) {
			Console.WriteLine((i + 1) + " Seconds Elapsed...");
			Thread.Sleep(1000);
		}


		Screen[] screens = Screen.AllScreens;

		int TotalWidth = 0;
		int TotalHeight = 0;

		for (int i = 0; i < screens.Length; i++) {
			Console.WriteLine("Name: " + screens[i].DeviceName);
			Console.WriteLine("Bounds: " + screens[i]);
			TotalWidth += screens[i].Bounds.Width;
		}
		TotalHeight = screens[0].Bounds.Height;
		Console.WriteLine(TotalWidth + "x" + TotalHeight);

		IntPtr FocusWindow = GetForegroundWindow();
		Console.WriteLine(FocusWindow);

		bool que = MoveWindow(FocusWindow, -8, -8, TotalWidth + 16, TotalHeight -14, true);
		// bool que = MoveWindow(FocusWindow, 0, 0, , 700, true);
		Console.WriteLine(que);
	}

	// static void Main() {
	// 	Process[] p = Process.GetProcesses();	
	// 	for (int i = 0; i < p.Length; i++) {
	// 		if (p[i].MainWindowHandle != IntPtr.Zero) {
	// 			Console.WriteLine(p[i].Id + " " + p[i].ProcessName);
	// 			// if (p[i].ProcessName == "javaw") {
	// 			// }
	// 			IntPtr FocusWindow = GetForegroundWindow();
	// 			Console.WriteLine(FocusWindow);
	// 			if (FocusWindow != null) {
	// 				Int32 Id = GetWindowThreadProcessId(FocusWindow, 0);
	// 				Console.WriteLine(Id);

	// 				// Process p = Process.GetProcessById(Id);
	// 				// Console.WriteLine(FocusWindow + " " + p);
	// 				if ()
	// 			}
	// 		}
	// 	}
	// }
}