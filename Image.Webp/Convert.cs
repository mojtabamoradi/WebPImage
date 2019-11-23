using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Moraba.Images.Webp
{
    /// <summary>simple and light .netcore service for work with webp images
    /// <para>developed by mojtaba moradi (mojtabamoradi.net@outlook.com)</para>
    /// <para>inspired by Wrapper for WebP format in C#. (GPL) Jose M. Piñeiro</para>
    /// </summary>
    public class Convert
    {
        /// <summary>resize the webp image</summary>
        /// <param name="sourcePath">valid source image path</param>
        /// <param name="destPath">destination image path that saved image there</param>
        /// <param name="width">width that image resized to them</param>
        /// <param name="height">height that image resized to them</param>
        /// <param name="compress">compress image if that true</param>
        /// <returns>return true if do correctly else return false</returns>
        public static bool ResizeWebP(string sourcePath, string destPath, int width, int height, bool compress = false)
        {
            try
            {
                if (String.IsNullOrEmpty(sourcePath) || String.IsNullOrEmpty(destPath) || width <= 0 || height <= 0) return false;
                using (WebP webp = new WebP())
                {
                    var webp_byte = webp.LoadByte(sourcePath);
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
        /// <param name="sourcePath">valid source image path</param>
        /// <param name="destPath">destination image path that saved image there</param>
        /// <param name="width">width that image resized to them</param>
        /// <param name="height">height that image resized to them</param>
        /// <param name="compress">compress image if that true</param>
        /// <returns>return true if do correctly else return false</returns>
        public static bool ResizeJpeg(string sourcePath, string destPath, int width, int height, bool compress = false)
        {
            try
            {
                if (String.IsNullOrEmpty(sourcePath) || String.IsNullOrEmpty(destPath) || width <= 0 || height <= 0) return false;
                using (WebP webp = new WebP())
                {
                    Bitmap bmp = new Bitmap(sourcePath);
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
        /// <param name="sourcePath">valid source image path</param>
        /// <param name="destPath">destination image path that saved image there</param>
        /// <param name="width">width that image resized to them</param>
        /// <param name="height">height that image resized to them</param>
        /// <param name="compress">compress image if that true</param>
        /// <returns>return true if do correctly else return false</returns>
        public static bool ResizePng(string sourcePath, string destPath, int width, int height, bool compress = false)
        {
            try
            {
                if (String.IsNullOrEmpty(sourcePath) || String.IsNullOrEmpty(destPath) || width <= 0 || height <= 0) return false;
                using (WebP webp = new WebP())
                {
                    Bitmap bmp = new Bitmap(sourcePath);
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
        /// <param name="sourcePath">valid source image path</param>
        /// <param name="destPath">destination image path that saved image there</param> 
        /// <param name="quality">quality of converted image, between 0 and 100 <para>min quality : 0 </para><para>max quality : 100</para></param>
        /// <returns>return true if do correctly else return false</returns>
        public static bool JpegToWebP(string sourcePath, string destPath, int quality = 100)
        {
            try
            {
                if (String.IsNullOrEmpty(sourcePath) || String.IsNullOrEmpty(destPath)) return false;
                if (quality <= 0 || quality > 100) { quality = 100; }
                using (WebP webp = new WebP())
                {
                    Bitmap bmp = new Bitmap(sourcePath);
                    webp.Save(bmp, destPath, quality);
                }
                return true;
            }
            catch { throw; }
        }

        /// <summary>convert jpeg image to webp and resize image</summary>
        /// <param name="sourcePath">valid source image path</param>
        /// <param name="destPath">destination image path that saved image there</param> 
        /// <param name="width">width that image resized to them</param>
        /// <param name="height">height that image resized to them</param>
        /// <param name="quality">quality of converted image, between 0 and 100 <para>min quality : 0 </para><para>max quality : 100</para></param>
        /// <returns>return true if do correctly else return false</returns>
        public static bool JpegToWebP(string sourcePath, string destPath, int width, int height, int quality = 100)
        {
            try
            {
                if (String.IsNullOrEmpty(sourcePath) || String.IsNullOrEmpty(destPath) || width <= 0 || height <= 0) return false;
                if (quality <= 0 || quality > 100) { quality = 100; }
                using (WebP webp = new WebP())
                {
                    Bitmap bmp = new Bitmap(sourcePath);
                    var webp_byte = webp.EncodeLossless(bmp);
                    bmp = webp.GetThumbnailQuality(webp_byte, width, height);
                    webp.Save(bmp, destPath, quality);
                }
                return true;

            }
            catch { throw; }
        }

        /// <summary>convert png image to webp</summary>
        /// <param name="sourcePath">valid source image path</param>
        /// <param name="destPath">destination image path that saved image there</param> 
        /// <param name="quality">quality of converted image, between 0 and 100 <para>min quality : 0 </para><para>max quality : 100</para></param>
        /// <returns>return true if do correctly else return false</returns>
        public static bool PngToWebP(string sourcePath, string destPath, int quality = 100)
        {
            try
            {
                if (String.IsNullOrEmpty(sourcePath) || String.IsNullOrEmpty(destPath)) return false;
                if (quality <= 0 || quality > 100) { quality = 100; }
                using (WebP webp = new WebP())
                {
                    Bitmap bmp = new Bitmap(sourcePath);
                    webp.Save(bmp, destPath, quality);
                }
                return true;
            }
            catch { throw; }
        }

        /// <summary>convert png image to webp and resize image</summary>
        /// <param name="sourcePath">valid source image path</param>
        /// <param name="destPath">destination image path that saved image there</param> 
        /// <param name="width">width that image resized to them</param>
        /// <param name="height">height that image resized to them</param>
        /// <param name="quality">quality of converted image, between 0 and 100 <para>min quality : 0 </para><para>max quality : 100</para></param>
        /// <returns>return true if do correctly else return false</returns>
        public static bool PngToWebP(string sourcePath, string destPath, int width, int height, int quality = 100)
        {
            try
            {
                if (String.IsNullOrEmpty(sourcePath) || String.IsNullOrEmpty(destPath) || width <= 0 || height <= 0) return false;
                if (quality <= 0 || quality > 100) { quality = 100; }
                using (WebP webp = new WebP())
                {
                    Bitmap bmp = new Bitmap(sourcePath);
                    var webp_byte = webp.EncodeLossless(bmp);
                    bmp = webp.GetThumbnailQuality(webp_byte, width, height);
                    webp.Save(bmp, destPath, quality);
                }
                return true;
            }
            catch { throw; }
        }

        /// <summary>convert webp image to jpeg</summary>
        /// <param name="sourcePath">valid source image path</param>
        /// <param name="destPath">destination image path that saved image there</param> 
        /// <param name="compress">compress image if that true</param>
        /// <returns>return true if do correctly else return false</returns>
        public static bool WebPToJpeg(string sourcePath, string destPath, bool compress = false)
        {
            try
            {
                if (String.IsNullOrEmpty(sourcePath) || String.IsNullOrEmpty(destPath)) return false;
                using (WebP webp = new WebP())
                {
                    var bmp = webp.Load(sourcePath);
                    var webp_byte = webp.LoadByte(sourcePath);
                    if (compress) { bmp = webp.GetThumbnailFast(webp_byte, bmp.Width, bmp.Height); }
                    else { bmp = webp.GetThumbnailQuality(webp_byte, bmp.Width, bmp.Height); }
                    bmp.Save(destPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                return true;
            }
            catch { throw; }

        }

        /// <summary>convert webp image to jpeg and resize image</summary>
        /// <param name="sourcePath">valid source image path</param>
        /// <param name="destPath">destination image path that saved image there</param> 
        /// <param name="width">width that image resized to them</param>
        /// <param name="height">height that image resized to them</param>
        /// <param name="compress">compress image if that true</param>
        /// <returns>return true if do correctly else return false</returns>
        public static bool WebPToJpeg(string sourcePath, string destPath, int width, int height, bool compress = false)
        {
            try
            {
                if (String.IsNullOrEmpty(sourcePath) || String.IsNullOrEmpty(destPath) || width <= 0 || height <= 0) return false;
                using (WebP webp = new WebP())
                {
                    var webp_byte = webp.LoadByte(sourcePath);
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
        /// <param name="sourcePath">valid source image path</param>
        /// <param name="destPath">destination image path that saved image there</param> 
        /// <param name="compress">compress image if that true</param>
        /// <returns>return true if do correctly else return false</returns>
        public static bool WebPToPng(string sourcePath, string destPath, bool compress = false)
        {
            try
            {
                if (String.IsNullOrEmpty(sourcePath) || String.IsNullOrEmpty(destPath)) return false;
                using (WebP webp = new WebP())
                {
                    var bmp = webp.Load(sourcePath);
                    var webp_byte = webp.LoadByte(sourcePath);
                    if (compress) { bmp = webp.GetThumbnailFast(webp_byte, bmp.Width, bmp.Height); }
                    else { bmp = webp.GetThumbnailQuality(webp_byte, bmp.Width, bmp.Height); }
                    bmp.Save(destPath, System.Drawing.Imaging.ImageFormat.Png);
                }
                return true;
            }
            catch { throw; }

        }

        /// <summary>convert webp image to png and resize image</summary>
        /// <param name="sourcePath">valid source image path</param>
        /// <param name="destPath">destination image path that saved image there</param> 
        /// <param name="width">width that image resized to them</param>
        /// <param name="height">height that image resized to them</param>
        /// <param name="compress">compress image if that true</param>
        /// <returns>return true if do correctly else return false</returns>
        public static bool WebPToPng(string sourcePath, string destPath, int width, int height, bool compress = false)
        {
            try
            {
                if (String.IsNullOrEmpty(sourcePath) || String.IsNullOrEmpty(destPath) || width <= 0 || height <= 0) return false;
                using (WebP webp = new WebP())
                {
                    var webp_byte = webp.LoadByte(sourcePath);
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

