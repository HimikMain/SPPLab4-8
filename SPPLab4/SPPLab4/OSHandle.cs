using System;
using System.Runtime.InteropServices;

namespace SPPLab4
{
    public class OSHandle : IDisposable
    {
        [DllImport("kernel32")]
        private static extern bool CloseHandle(IntPtr handle);
        private bool disposed = false;

        public OSHandle(IntPtr handle)
        {
            this.handle = handle;
        }

        ~OSHandle()
        {
            Dispose(false);
        }
        private IntPtr handle;
        public IntPtr Handle
        {
            get
            {
                if (!disposed)
                    return handle;
                else
                    throw new ObjectDisposedException(ToString());
            }
            set
            {
                if (!disposed)
                    handle = value;
                else
                    throw new ObjectDisposedException(ToString());
            }
        }
        public void Dispose()
        {
            if (!disposed)
            {
                Dispose(true);
                GC.SuppressFinalize(this);
                disposed = true;
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (handle != IntPtr.Zero)
                CloseHandle(handle);
            if (disposing)
            {
                //Dispose 
            }
            else
            {
                //Finalize 
            }
        }
    }
}
