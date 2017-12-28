MicroLite.Extensions.MiniProfiler
=================================

[![NuGet version](https://badge.fury.io/nu/MicroLite.Extensions.MiniProfiler.svg)](http://badge.fury.io/nu/MicroLite.Extensions.MiniProfiler) [![Build Status](https://trevorpilley.visualstudio.com/_apis/public/build/definitions/4cf9ae80-460f-4dc8-a6fd-815e9e58ad35/8/badge)](https://trevorpilley.visualstudio.com/MicroLite.Extensions.WebApi)

_MicroLite.Extensions.MiniProfiler_ is an extension to the MicroLite ORM Framework which allows [MiniProfiler](http://miniprofiler.com/) to profile MicroLite database queries.

In order to use the extension, you first need to install it via NuGet:

    Install-Package MicroLite.Extensions.MiniProfiler

You can then load the extension in your application start-up:

    // Load the extensions for MicroLite
    Configure
       .Extensions() // If you are also using a logging extension, that should be loaded first.
       .WithMiniProfiler();

    // Create the session factory...
    Configure
       .Fluently()
       ...

For further information on configuring MiniProfiler, see [http://miniprofiler.com/](http://miniprofiler.com/).

## Supported .NET Framework Versions

The NuGet Package contains binaries compiled against:

* .NET 4.5

## Supported miniprofiler Versions

* miniprofiler 3.2.0 onwards
