﻿// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace PlanetaryDocs
{
    /// <summary>
    /// Main program.
    /// </summary>
    public static class PlanetaryDocsMainProgram
    {
        /// <summary>
        /// Main method.
        /// </summary>
        /// <param name="args">Arguments passed in.</param>
        public static void Main(string[] args) =>
            CreateHostBuilder(args).Build().Run();

        /// <summary>
        /// Create the host builder for the app.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        /// <returns>The <see cref="IHostBuilder"/> instance.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<PlanetaryDocsStartup>());
    }
}
