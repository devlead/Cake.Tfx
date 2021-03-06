﻿using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Tfx.Extension.Create
{
    /// <summary>
    /// The Tfx Create Runner used to create extensions.
    /// </summary>
    public sealed class TfxExtensionCreateRunner : TfxTool<TfxExtensionCreateSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="TfxExtensionCreateRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public TfxExtensionCreateRunner(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            _environment = environment;
        }

        /// <summary>
        /// Creates an extension using the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Create(TfxExtensionCreateSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            RunTfx(settings, new TfxExtensionCreateArgumentBuilder(_environment, settings));
        }
    }
}