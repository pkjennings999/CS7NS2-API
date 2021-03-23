using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CS7NS2_API
{
    /// <summary>
    /// Helper functions
    /// </summary>
    public static class Helpers
    {
        private static StringBuilder output = null;

        /// <summary>
        /// Call the facemask model python script
        /// </summary>
        public static async Task<string> CallFacemaskModel()
        {
            ProcessStartInfo start = new ProcessStartInfo
            {
                FileName = FacemaskCheckConstants.PATH_TO_EXE,
                Arguments = $"--source {FacemaskCheckConstants.PATH_TO_IMAGE} --weights {FacemaskCheckConstants.PATH_TO_WEIGHTS} --iou-thres 0.3 --conf-thres 0.5",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            Process process = new Process();
            process.StartInfo = start;
            output= new StringBuilder();
            process.OutputDataReceived += OutputHandler;
            process.ErrorDataReceived += OutputHandler;
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            await process.WaitForExitAsync();

            return output.ToString();
        }

        private static void OutputHandler(object sendingProcess,
            DataReceivedEventArgs outLine)
        {
            if (!string.IsNullOrEmpty(outLine.Data))
            {
                output.Append(Environment.NewLine +
                    $"{outLine.Data}");
            }
        }

        /// <summary>
        /// Check if the environment is prod or not
        /// </summary>
        /// <returns>If the environment is prod</returns>
        public static bool isProd()
        {
#if DEBUG
            return false;
#else
            return true;
#endif
        }

        public async static Task SaveData(string data)
        {
            await File.WriteAllTextAsync("output.txt", data);
        }
    }
}
