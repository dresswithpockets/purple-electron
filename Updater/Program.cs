using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace Updater {
	class Program {
		public static void Main(string[] args) {
			try {
				Console.Title = "Purple Electron Updater";

				if (File.Exists("latest.zip")) {
					Console.WriteLine("Deleted old latest.zip");
				}

				if (Directory.Exists("latest/")) {
					foreach (string file in Directory.GetFiles("latest/")) {
						File.Delete(file);
						Console.WriteLine("Deleted old {0} file", new FileInfo(file).Name);
					}
					Directory.Delete("latest/");
					Console.WriteLine("Deleted old latest/ directory");
				}

				using (var client = new WebClient()) {
					Console.WriteLine("Downloading latest version of Purple Electron...");
					client.DownloadFile("http://purple-electron.tristenhorton.com/release/latest.zip", "latest.zip");
					Console.WriteLine("Downloaded latest.zip");
				}

				ZipFile.ExtractToDirectory("latest.zip", "latest/");
				Console.WriteLine("Decompressed latest.zip to latest/");

				File.Delete("latest.zip");
				Console.WriteLine("Deleted temporary file for latest.zip");
				
				foreach (string file in Directory.GetFiles("latest/")) {
					var fi = new FileInfo(file);
					if (!file.EndsWith("Updater.exe")) {
						if (File.Exists(fi.Name)) File.Delete(fi.Name);
						File.Copy(fi.FullName, fi.Name);
						Console.WriteLine("Copied {0} to host directory", fi.Name);
					}
					File.Delete(fi.FullName);
					Console.WriteLine("Deleted temporary file for {0}", fi.Name);
				}
				
				Directory.Delete("latest/");
				Console.WriteLine("Deleted temporary folder");

				Console.WriteLine("Update complete, reopening Purple Electron");
				System.Diagnostics.Process.Start("PurpleElectron.exe", "--ignore-update");
			}
			catch (WebException webex) {
				Console.WriteLine("An error occurred and the connection to the server failed. Could not download the latest version of Purple Electron.");
			}
		}
	}
}
