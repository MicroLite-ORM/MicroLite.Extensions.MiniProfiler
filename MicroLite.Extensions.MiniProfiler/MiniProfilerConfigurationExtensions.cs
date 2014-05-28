// -----------------------------------------------------------------------
// <copyright file="MiniProfilerConfigurationExtensions.cs" company="MicroLite">
// Copyright 2012 - 2014 Project Contributors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// </copyright>
// -----------------------------------------------------------------------
namespace MicroLite.Configuration
{
    using System;
    using StackExchange.Profiling;
    using StackExchange.Profiling.Data;

    /// <summary>
    /// Extensions for the MicroLite configuration.
    /// </summary>
    public static class MiniProfilerConfigurationExtensions
    {
        /// <summary>
        /// Configures the MicroLite ORM Framework to use MiniProfiler.
        /// </summary>
        /// <param name="configureExtensions">The interface to configure extensions.</param>
        /// <returns>The configure extensions.</returns>
        public static IConfigureExtensions WithMiniProfiler(this IConfigureExtensions configureExtensions)
        {
            if (configureExtensions == null)
            {
                throw new ArgumentNullException("configureExtensions");
            }

            System.Diagnostics.Trace.TraceInformation("MicroLite: loading MiniProfiler extension.");

            Configure.OnSessionFactoryCreated = (ISessionFactory sessionFactory) =>
            {
                var dbProviderFactory = sessionFactory.DbDriver.DbProviderFactory;

                sessionFactory.DbDriver.DbProviderFactory = new ProfiledDbProviderFactory(dbProviderFactory);

                return sessionFactory;
            };

            MiniProfiler.Settings.ExcludeAssembly("MicroLite");
            MiniProfiler.Settings.ExcludeAssembly("MicroLite.Logging.Log4Net");
            MiniProfiler.Settings.ExcludeAssembly("MicroLite.Logging.NLog");

            System.Diagnostics.Trace.TraceInformation("MicroLite: MiniProfiler extension loaded.");

            return configureExtensions;
        }
    }
}