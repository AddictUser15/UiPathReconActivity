using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using RazorEngine;
using RazorEngine.Templating;

namespace ReconActivity.Reporting
{
    public class RazorSynchronizedServices : IDisposable
    {
        private static readonly object SharedLock = new Object();

        private bool _disposed;

        private readonly object _disposedSyncRoot = new object();

        public RazorSynchronizedServices()
        {
            Monitor.Enter(SharedLock);
        }

        public void CompileWithAnonymous(string template, string name)
        {
            try
            {
                Engine.Razor.AddTemplate(name, template);
                Engine.Razor.Compile(name, typeof(ExpandoObject));
            }
            catch (TemplateCompilationException ex)
            {
                var templateErrors = new StringBuilder("Error Compiling Template");
                ex.CompilerErrors.ToList().ForEach(p => templateErrors.AppendLine(p.ErrorText));
                throw new ApplicationException(templateErrors.ToString());
            }
        }
        public string Run<T>(T model, string name)
        {
            return Engine.Razor.Run(name, typeof(T), model);
        }

        public void Dispose()
        {
            if (_disposed)
            {
               return;
            }

            lock (_disposedSyncRoot)
            {
                if (_disposed)
                {
                    return;
                }

                Monitor.Exit(SharedLock);
                _disposed = true;
            }
        }
    }
}
