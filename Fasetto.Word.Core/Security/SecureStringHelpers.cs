using System;
using System.Runtime.InteropServices;

namespace Fasetto.Word.Core
{
    using System.Security;

    /// <summary>
    /// Helpers for the <see cref="SecureString"/> class
    /// </summary>
    public static class SecureStringHelpers
    {
        #region Public Methods

        /// <summary>
        /// Decrypts a <see cref="SecureString"/> to a string
        /// </summary>
        /// <param name="secureString"></param>
        /// <returns></returns>
        public static string Unsecure(this SecureString secureString)
        {
            if (secureString == null)
            {
                return string.Empty;
            }

            var unmanagedString = IntPtr.Zero;

            try
            {
                // Unsecure the password
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                //Clean up memory allocation
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }

    #endregion Public Methods
}