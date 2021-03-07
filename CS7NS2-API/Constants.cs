namespace CS7NS2_API
{
    /// <summary>
    /// Constants pertaining to the facemask check script
    /// </summary>
    public static class FacemaskCheckConstants
    {
        /// <summary>
        /// Path to the facemask check exe script
        /// </summary>
        public static string PATH_TO_EXE = Helpers.isProd() ? "detect\\detect.exe" : "..\\dist\\detect\\detect.exe";

        /// <summary>
        /// Path to the weights file
        /// </summary>
        public static string PATH_TO_WEIGHTS = Helpers.isProd() ? "best.pt" : "..\\maskDetector\\mask_detector\\weights\\best.pt";

        /// <summary>
        /// Path to the image to check
        /// </summary>
        public static string PATH_TO_IMAGE = Helpers.isProd() ? "test-images\\mask.jpg" : "..\\maskDetector\\test-images\\mask.jpg";
    }
}
