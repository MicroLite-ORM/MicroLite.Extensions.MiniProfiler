MicroLite.Extensions.MiniProfiler
=================================

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

For further information on configuring MiniProfiler, see [http://miniprofiler.com/](http://miniprofiler.com/)