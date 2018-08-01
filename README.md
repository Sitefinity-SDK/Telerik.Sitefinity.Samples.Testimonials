Progress.Sitefinity.Samples.Testimonials
=======================================

### Disclaimer
### The purpose of this sample is to show the creation of a Sitefinity content module. The content module similar to the built-in News module in Sitefinity. We highly recommend using [Module Builder](https://docs.sitefinity.com/overview-dynamic-modules-and-the-module-builder) to create modules that manage content. The built-in module builder can address all of the needs for managing content and updates will be provided to it with each Sitefinity release and is the best way to go in terms of managing content in the long run. To move the configurations for module builder modules between different deployment environments refer to [this](https://docs.sitefinity.com/export-and-deploy-code-changes#procedure) documentation or to setup continuous delivery refer to [this](https://docs.sitefinity.com/setup-the-continuous-delivery-process) guide.
### The sample presented here can be used as a reference to how Sitefinity content modules are created, but for actual use of content module it is best to use Module Builder module.

### This repository is not automatically upgraded to latest Sitefintiy version. The repository is monitored for pull requests and fixes. The latest official version of Sitefinity that supports this sample is 9.1. Be aware that using a higher version could cause unexpected behavior. If you successfully upgrade the example to a greater version, please share your work with the community by submitting your changes via pull request.

The Testimonials sample project is a simple user widget-based module for maintaining a list of testimonials that are submitted by users. The Testimonials sample demonstrates how to create and install a basic intra-site module, based on a user widget.

### Requirements

* Sitefinity CMS license
* .NET Framework 4
* Visual Studio 2012
* Microsoft SQL Server 2008R2 or later versions

### Prerequisites

Clear the NuGet cache files. To do this:

1. In Windows Explorer, open the **%localappdata%\NuGet\Cache** folder.
2. Select all files and delete them.

### Nuget package restoration
The solution in this repository relies on NuGet packages with automatic package restore while the build procedure takes place.   
For a full list of the referenced packages and their versions see the [packages.config](https://github.com/Sitefinity-SDK/Telerik.Sitefinity.Samples.Testimonials/blob/master/SitefinityWebApp/packages.config) file.    
For a history and additional information related to package versions on different releases of this repository, see the [Releases page](https://github.com/Sitefinity-SDK/Telerik.Sitefinity.Samples.Testimonials/releases).    


### Installation instructions: SDK Samples from GitHub

1. In Solution Explorer, navigate to _SitefinityWebApp_ » *App_Data* » _Sitefinity_ » _Configuration_ and select the **StartupConfig.config** file. 
2. Modify the **dbType**, **sqlInstance** and **dbName** values to match your server settings.
3. Build the solution.

For version-specific details about the required Sitefinity CMS NuGet packages for this sample application, click on [Releases](https://github.com/Sitefinity-SDK/Telerik.Sitefinity.Samples.Testimonials/releases).

### Login

To login into the Sitefinity CMS backend, use the following credentials:   
**Username:** admin   
**Password:** password


### Additional resources
[Car rental demo](http://demos.telerik.com/aspnet-ajax/carrental/)
