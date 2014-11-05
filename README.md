Telerik.Sitefinity.Samples.Testimonials
=======================================

[![Build Status](http://sdk-jenkins-ci.cloudapp.net/buildStatus/icon?job=Telerik.Sitefinity.Samples.Testimonials.CI)](http://sdk-jenkins-ci.cloudapp.net/job/Telerik.Sitefinity.Samples.Testimonials.CI/)

The Testimonials sample project is a simple user widget-based module for maintaining a list of testimonials that are submitted by users. The Testimonials sample demonstrates how to create and install a basic intra-site module, based on a user wiget.

### Requirements

* Sitefinity 7.1 license
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


1. In Solution Explorer, navigate to _SitefinityWebApp_ -> *App_Data* -> _Sitefinity_ -> _Configuration_ and select the **DataConfig.config** file. 
2. Modify the **connectionString** value to match your server address.

For version-specific details about the required Sitefinity NuGet packages for this sample application, click on [Releases]
(https://github.com/Sitefinity-SDK/Telerik.Sitefinity.Samples.Testimonials/releases).

### Login

To login to Sitefinity backend, use the following credentials: 

**Username:** admin
**Password:** password


### Additional resources

[Car rental demo](http://demos.telerik.com/aspnet-ajax/carrental/)

