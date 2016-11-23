using System;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Linq;

namespace PurpleElectron {
	static class Program {

		static Mutex mutex = new Mutex(true, "{" + Config.GUID + "}");

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// <param name="args">Command line arguments passed at execution.</param>
		[STAThread]
		static void Main(string[] args) {

			Debug.WriteLine("Entering Main");

			if (mutex.WaitOne(TimeSpan.Zero, true)) {

				if (args.Length == 0 || !args.Contains("--ignore-update")) {

					Debug.WriteLine("Checking for updates...");

					var request = WebRequest.CreateHttp("http://purple-electron.tristenhorton.com/release/version.txt");
					var response = (HttpWebResponse)request.GetResponse();
					using (var receive = response.GetResponseStream())
					using (var read = new StreamReader(receive, Encoding.UTF8)) {
						if (read.ReadToEnd().Trim() == Assembly.GetExecutingAssembly().GetName().Version.ToString()) {
							Process.Start("Updater.exe");
							Process.GetCurrentProcess().Close();
							return;
						}
					}

					response.Close();
				}

				Debug.WriteLine("Running application.");

				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				using (ProcessContext pi = new ProcessContext()) {
					Application.Run(pi);
				}
			}
			else {
				MessageBox.Show("Theres already another instance of Purple Electron running!\nCheck your system tray.");

				// Instead of alerting them that there is another instance, lets bring the running instance
				// to the top of the desktop

				Utility.PostMessage(
					(IntPtr)Utility.HWND_BROADCAST,
					Utility.WM_SHOWME,
					IntPtr.Zero,
					IntPtr.Zero);
			}
		}
	}
}
