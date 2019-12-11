# WebPImage
.netcore simple and light package for convert images to webp.

## Adding Moraba.Images.Webp.Core package to your .NET Core project

  you can add this package from nuget.

## Package Manager
   Install-Package Moraba.Images.Webp.Core 
## .NET CLI 
   dotnet add package Moraba.Images.Webp.Core 
  
## DLL Requirement  
   after install package you must download two below dll and put it in the project folder.\
   [libwebp_x64.dll](https://github.com/mojtabamoradi/WebPImage/raw/master/Image.Webp/libwebp_x64.dll)\
   [libwebp_x86.dll](https://github.com/mojtabamoradi/WebPImage/raw/master/Image.Webp/libwebp_x86.dll)
   
## usage

```c#

      try
      {
           Moraba.Images.Webp.Convert.PngToWebP("test.png", "webp.webp", 440, 200);
          //convert png image to webp and save on local path

		  
           Moraba.Images.Webp.Convert.PngToWebPFromWeb("https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png", "webp.webp", 100, 50);
          //convert web png image to webp and save on local path
      }
      catch (Exception ex)
      {
          Console.WriteLine(ex.Message);
      } 

``` 
##
![https://github.com/mojtabamoradi/PersianNumber](https://raw.githubusercontent.com/mojtabamoradi/Moraba/master/logo.png)

