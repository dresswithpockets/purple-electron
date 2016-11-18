using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;

namespace PurpleElectron {
	internal class Utility {
		public const int HWND_BROADCAST = 0xffff;
		public static readonly int WM_SHOWME = RegisterWindowMessage("WM_SHOWME");
		[DllImport("user32")]
		public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
		[DllImport("user32")]
		public static extern int RegisterWindowMessage(string message);

		public static byte[] ReadToEnd(Stream stream) {
			long originalPosition = 0;

			if (stream.CanSeek) {
				originalPosition = stream.Position;
				stream.Position = 0;
			}

			try {
				var readBuffer = new byte[4096];

				var totalBytesRead = 0;
				int bytesRead;

				while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0) {
					totalBytesRead += bytesRead;

					if (totalBytesRead == readBuffer.Length) {
						var nextByte = stream.ReadByte();
						if (nextByte != -1) {
							byte[] temp = new byte[readBuffer.Length * 2];
							Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
							Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
							readBuffer = temp;
							totalBytesRead++;
						}
					}
				}

				var buffer = readBuffer;
				if (readBuffer.Length != totalBytesRead) {
					buffer = new byte[totalBytesRead];
					Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
				}
				return buffer;
			}
			finally {
				if (stream.CanSeek) {
					stream.Position = originalPosition;
				}
			}
		}

		[DllImport("winmm.dll")]
		private static extern uint mciSendString(
			string command,
			StringBuilder returnValue,
			int returnLength,
			IntPtr winHandle);

		public static int GetSoundLength(string fileName) {
			var lengthBuf = new StringBuilder(32);

			mciSendString(string.Format("open \"{0}\" type waveaudio alias wave", fileName), null, 0, IntPtr.Zero);
			mciSendString("status wave length", lengthBuf, lengthBuf.Capacity, IntPtr.Zero);
			mciSendString("close wave", null, 0, IntPtr.Zero);

			var length = 0;
			int.TryParse(lengthBuf.ToString(), out length);

			return length;
		}

		[DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		private static extern int GetShortPathName(string path, StringBuilder shortPath, int shortPathLength);

		public static string GetShortPathName(string longPath) {
			var shortPath = new StringBuilder(longPath.Length + 1);

			if (0 == GetShortPathName(longPath, shortPath, shortPath.Capacity)) {
				return longPath;
			}

			return shortPath.ToString();
		}
	}
}
