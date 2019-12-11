
using Moraba.Images.Webp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Moraba.Images.Webp
{
    public partial class Convert
    {


        /// <summary>resize the webp image</summary>
        /// <param name="sourceUrl">valid source image url</param>
        /// <param name="destPath">destination image path that saved image there</param>
        /// <param name="width">width that image resized to them</param>
        /// <param name="height">height that image resized to them</param>
        /// <param name="compress">compress image if that true</param>
        /// <returns>return true if do correctly else return false</returns>
        public static bool ResizeWebPFromWeb(string sourceUrl, string destPath, int width, int height, bool compress = false)
        {
            try
            {
                if (String.IsNullOrEmpty(sourceUrl) || String.IsNullOrEmpty(destPath) || width <= 0 || height <= 0) return false;
                using (WebP webp = new WebP())
                {
                    var stream = Helper.DownloadImage(sourceUrl);
                    var webp_byte = Helper.ReadByte(stream);
                    Bitmap bmp;
                    if (compress) { bmp = webp.GetThumbnailFast(webp_byte, width, height); }
                    else { bmp = webp.GetThumbnailQuality(webp_byte, width, height); }
                    webp.Save(bmp, destPath);
                }
                return true;
            }
            catch { throw; }
        }

        /// <summary>resize the jpeg image</summary>
        /// <param name="sourceUrl">valid source image url</param>
        /// <param name="destPath">destination image path that saved image there</param>
        /// <param name="width">width that image resized to them</param>
        /// <param name="height">height that image resized to them</param>
        /// <param name="compress">compress image if that true</param>
        /// <returns>return true if do correctly else return false</returns>
        public static bool ResizeJpegFromWeb(string sourceUrl, string destPath, int width, int height, bool compress = false)
        {
            try
            {
                if (String.IsNullOrEmpty(sourceUrl) || String.IsNullOrEmpty(destPath) || width <= 0 || height <= 0) return false;
                using (WebP webp = new WebP())
                {
                    Bitmap bmp = new Bitmap(Helper.DownloadImage(sourceUrl));
                    var webp_byte = webp.EncodeLossless(bmp);
                    if (compress) { bmp = webp.GetThumbnailFast(webp_byte, width, height); }
                    else { bmp = webp.GetThumbnailQuality(webp_byte, width, height); }
                    bmp.Save(destPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                return true;
            }
            catch { throw; }
        }

        /// <summary>resize the png image</summary>
        /// <param name="sourceUrl">valid source image url</param>
        /// <param name="destPath">destination image path that saved image there</param>
        /// <param name="width">width that image resized to them</param>
        /// <param name="height">height that image resized to them</param>
        /// <param name="compress">compress image if that true</param>
        /// <returns>return true if do correctly else return false</returns>
        public static bool ResizePngForWeb(string sourceUrl, string destPath, int width, int height, bool compress = false)
        {
            try
            {
                if (String.IsNullOrEmpty(sourceUrl) || String.IsNullOrEmpty(destPath) || width <= 0 || height <= 0) return false;
                using (WebP webp = new WebP())
                {
                    Bitmap bmp = new Bitmap(Helper.DownloadImage(sourceUrl));
                    var webp_byte = webp.EncodeLossless(bmp);
                    if (compress) { bmp = webp.GetThumbnailFast(webp_byte, width, height); }
                    else { bmp = webp.GetThumbnailQuality(webp_byte, width, height); }
                    bmp.Save(destPath, System.Drawing.Imaging.ImageFormat.Png);
                }
                return true;
            }
            catch { throw; }
        }

        /// <summary>convert jpeg image to webp</summary>
        /// <param name="sourceUrl">valid source image url</param>
        /// <param name="destPath">destination image path that saved image there</param> 
        /// <param name="quality">quality of converted image, between 0 and 100 <para>min quality : 0 </para><para>max quality : 100</para></param>
        /// <returns>return true if do correctly else return false</returns>
        public static bool JpegToWebPFromWeb(string sourceUrl, string destPath, int quality = 100)
        {
            try
            {
                if (String.IsNullOrEmpty(sourceUrl) || String.IsNullOrEmpty(destPath)) return false;
                if (quality <= 0 || quality > 100) { quality = 100; }

                using (WebP webp = new WebP())
                {
                    Bitmap bmp = new Bitmap(Helper.DownloadImage(sourceUrl));
                    webp.Save(bmp, destPath, quality);
                }
                return true;
            }
            catch { throw; }
        }

        /// <summary>convert png image to webp</summary>
        /// <param name="sourceUrl">valid source image url</param>
        /// <param name="destPath">destination image path that saved image there</param> 
        /// <param name="quality">quality of converted image, between 0 and 100 <para>min quality : 0 </para><para>max quality : 100</para></param>
        /// <returns>return true if do correctly else return false</returns>
        public static bool PngToWebPFromWeb(string sourceUrl, string destPath, int quality = 100)
        {
            try
            {
                if (String.IsNullOrEmpty(sourceUrl) || String.IsNullOrEmpty(destPath)) return false;
                if (quality <= 0 || quality > 100) { quality = 100; }
                using (WebP webp = new WebP())
                {
                    Bitmap bmp = new Bitmap(Helper.DownloadImage(sourceUrl));
                    webp.Save(bmp, destPath, quality);
                }
                return true;
            }
            catch { throw; }
        }


        /// <summary>convert png image to webp and resize image</summary>
        /// <param name="sourceUrl">valid source image url</param>
        /// <param name="destPath">destination image path that saved image there</param> 
        /// <param name="width">width that image resized to them</param>
        /// <param name="height">height that image resized to them</param>
        /// <param name="quality">quality of converted image, between 0 and 100 <para>min quality : 0 </para><para>max quality : 100</para></param>
        /// <returns>return true if do correctly else return false</returns>
        public static bool PngToWebPFromWeb(string sourceUrl, string destPath, int width, int height, int quality = 100)
        {
            try
            {
                if (String.IsNullOrEmpty(sourceUrl) || String.IsNullOrEmpty(destPath) || width <= 0 || height <= 0) return false;
                if (quality <= 0 || quality > 100) { quality = 100; }
                using (WebP webp = new WebP())
                {
                    Bitmap bmp = new Bitmap(Helper.DownloadImage(sourceUrl));
                    var webp_byte = webp.EncodeLossless(bmp);
                    bmp = webp.GetThumbnailQuality(webp_byte, width, height);
                    webp.Save(bmp, destPath, quality);
                }
                return true;
            }
            catch { throw; }
        }

        /// <summary>convert webp image to jpeg</summary>
        /// <param name="sourceUrl">valid source image url</param>
        /// <param name="destPath">destination image path that saved image there</param> 
        /// <param name="compress">compress image if that true</param>
        /// <returns>return true if do correctly else return false</returns>
        public static bool WebPToJpegFromWeb(string sourceUrl, string destPath, bool compress = false)
        {
            try
            {
                if (String.IsNullOrEmpty(sourceUrl) || String.IsNullOrEmpty(destPath)) return false;
                using (WebP webp = new WebP())
                {
                    var stream = Helper.DownloadImage(sourceUrl);
                    var webp_byte = Helper.ReadByte(stream);
                    var bmp = new Bitmap(stream);
                    if (compress) { bmp = webp.GetThumbnailFast(webp_byte, bmp.Width, bmp.Height); }
                    else { bmp = webp.GetThumbnailQuality(webp_byte, bmp.Width, bmp.Height); }
                    bmp.Save(destPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                return true;
            }
            catch { throw; }

        }
         
        /// <summary>convert webp image to jpeg and resize image</summary>
        /// <param name="sourceUrl">valid source image url</param>
        /// <param name="destPath">destination image path that saved image there</param> 
        /// <param name="width">width that image resized to them</param>
        /// <param name="height">height that image resized to them</param>
        /// <param name="compress">compress image if that true</param>
        /// <returns>return true if do correctly else return false</returns>
        public static bool WebPToJpegFromWeb(string sourceUrl, string destPath, int width, int height, bool compress = false)
        {
            try
            {
                if (String.IsNullOrEmpty(sourceUrl) || String.IsNullOrEmpty(destPath) || width <= 0 || height <= 0) return false;
                using (WebP webp = new WebP())
                { 
                    var stream = Helper.DownloadImage(sourceUrl);
                    var webp_byte = Helper.ReadByte(stream); 
                    Bitmap bmp;
                    if (compress) { bmp = webp.GetThumbnailFast(webp_byte, width, height); }
                    else { bmp = webp.GetThumbnailQuality(webp_byte, width, height); }
                    bmp.Save(destPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                return true;
            }
            catch { throw; }

        }
         
        /// <summary>convert webp image to png</summary>
        /// <param name="sourceUrl">valid source image url</param>
        /// <param name="destPath">destination image path that saved image there</param> 
        /// <param name="compress">compress image if that true</param>
        /// <returns>return true if do correctly else return false</returns>
        public static bool WebPToPngFromWeb(string sourceUrl, string destPath, bool compress = false)
        {
            try
            {
                if (String.IsNullOrEmpty(sourceUrl) || String.IsNullOrEmpty(destPath)) return false;
                using (WebP webp = new WebP())
                {
                    var stream = Helper.DownloadImage(sourceUrl);
                    var webp_byte = Helper.ReadByte(stream);
                    var bmp = new Bitmap(stream);
                    if (compress) { bmp = webp.GetThumbnailFast(webp_byte, bmp.Width, bmp.Height); }
                    else { bmp = webp.GetThumbnailQuality(webp_byte, bmp.Width, bmp.Height); }
                    bmp.Save(destPath, System.Drawing.Imaging.ImageFormat.Png);
                }
                return true;
            }
            catch { throw; }

        }
         
        /// <summary>convert webp image to png and resize image</summary>
        /// <param name="sourceUrl">valid source image url</param>
        /// <param name="destPath">destination image path that saved image there</param> 
        /// <param name="width">width that image resized to them</param>
        /// <param name="height">height that image resized to them</param>
        /// <param name="compress">compress image if that true</param>
        /// <returns>return true if do correctly else return false</returns>
        public static bool WebPToPngFromWeb(string sourceUrl, string destPath, int width, int height, bool compress = false)
        {
            try
            {
                if (String.IsNullOrEmpty(sourceUrl) || String.IsNullOrEmpty(destPath) || width <= 0 || height <= 0) return false;
                using (WebP webp = new WebP())
                {
                    var stream = Helper.DownloadImage(sourceUrl);
                    var webp_byte = Helper.ReadByte(stream);
                    Bitmap bmp;
                    if (compress) { bmp = webp.GetThumbnailFast(webp_byte, width, height); }
                    else { bmp = webp.GetThumbnailQuality(webp_byte, width, height); }
                    bmp.Save(destPath, System.Drawing.Imaging.ImageFormat.Png);
                }
                return true;
            }
            catch { throw; }

        }

    }
}
