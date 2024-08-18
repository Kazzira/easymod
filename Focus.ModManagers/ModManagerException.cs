using System;
using System.Runtime.Serialization;

namespace Focus.ModManagers;

public class ModManagerException : Exception
{
    public ModManagerException() { }

    public ModManagerException(string? message)
        : base(message) { }
}
