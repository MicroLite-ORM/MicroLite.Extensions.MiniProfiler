# MicroLite.Extensions.MiniProfiler

MicroLite.Extensions.MiniProfiler is a .NET 4.5 library which adds an extension for the MicroLite ORM Framework to integrate with [MiniProfiler](http://miniprofiler.com/).

![Nuget](https://img.shields.io/nuget/dt/MicroLite.Extensions.MiniProfiler)

|Branch|Status|
|------|------|
|/develop|![GitHub last commit (branch)](https://img.shields.io/github/last-commit/MicroLite-ORM/MicroLite.Extensions.MiniProfiler/develop) [![Build Status](https://dev.azure.com/trevorpilley/MicroLite-ORM/_apis/build/status/MicroLite-ORM.MicroLite.Extensions.MiniProfiler?branchName=develop)](https://dev.azure.com/trevorpilley/MicroLite-ORM/_build/latest?definitionId=31&branchName=develop) ![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/MicroLite.Extensions.MiniProfiler)|
|/master|![GitHub last commit](https://img.shields.io/github/last-commit/MicroLite-ORM/MicroLite.Extensions.MiniProfiler/master) [![Build Status](https://dev.azure.com/trevorpilley/MicroLite-ORM/_apis/build/status/MicroLite-ORM.MicroLite.Extensions.MiniProfiler?branchName=master)](https://dev.azure.com/trevorpilley/MicroLite-ORM/_build/latest?definitionId=31&branchName=master) ![Nuget](https://img.shields.io/nuget/v/MicroLite.Extensions.MiniProfiler) ![GitHub Release Date](https://img.shields.io/github/release-date/MicroLite-ORM/MicroLite.Extensions.MiniProfiler)|

## Installation

Install the nuget package `Install-Package MicroLite.Extensions.MiniProfiler`

## Configuration

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

## Supported .NET Versions

The NuGet Package contains binaries compiled against (dependencies indented):

* .NET Framework 4.5
  * MicroLite 7.0.0
  * MiniProfiler 3.2.0.157
