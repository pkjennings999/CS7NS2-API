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
        /// <param name="imageName">The image name to run the check on</param>
        /// <returns>The output from the script</returns>
        public static async Task<string> CallFacemaskModel(string imageName)
        {
            ProcessStartInfo start = new ProcessStartInfo
            {
                FileName = FacemaskCheckConstants.PATH_TO_EXE,
                Arguments = $"--source {imageName}.jpg --weights {FacemaskCheckConstants.PATH_TO_WEIGHTS} --iou-thres 0.3 --conf-thres 0.5",
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

            // Make sure to delete the image once we are done with it
            //File.Delete($"{imageName}.jpg");

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

        /// <summary>
        /// Save an image from a byte array
        /// </summary>
        /// <param name="data">The image in byte array format</param>
        /// <param name="imageName">The name of the image</param>
        public async static Task SaveImage(byte[] data, string imageName)
        {
            await File.WriteAllBytesAsync($"{imageName}.jpg", data);
        }
    }
}
