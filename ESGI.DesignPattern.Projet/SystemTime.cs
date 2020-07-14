using System;
using System.Collections.Generic;
using System.Text;


namespace ESGI.DesignPattern.Projet
{
    /// <summary>
    /// Used for getting DateTime.Now(), time is changeable for unit testing
    /// </summary>
    public static class SystemTime
    {
        /// <summary> Normally this is a pass-through to DateTime.Now, but it can be overridden with SetDateTime( .. ) for testing or debugging.
        /// </summary>
        public static DateTime Now { get; set; } = DateTime.Now;
    }
}
