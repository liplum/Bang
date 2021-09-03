using Bang.Core;
using Bang.Services;

namespace Bang.IO;
public static class ResourceHelper
{
    public static IResourceManager? ResourceManager
    {
        set; get;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="location"></param>
    /// <param name="suffix"></param>
    /// <exception cref="FileNotExistedException"></exception>
    /// <returns></returns>
    public static FileInfo File(this ResLocation location, string suffix = "")
    {
        if (ResourceManager is null)
        {
            throw new ResourceManagerNotInitializedException();
        }
        return ResourceManager.ResolveFile(location, suffix);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="location"></param>
    /// <exception cref="FolderNotExistedException"></exception>
    /// <returns></returns>
    public static DirectoryInfo Directory(this ResLocation location)
    {
        if (ResourceManager is null)
        {
            throw new ResourceManagerNotInitializedException();
        }
        return ResourceManager.ResolveDirectory(location);
    }
}


[Serializable]
public class ResourceManagerNotInitializedException : Exception
{
    public ResourceManagerNotInitializedException() { }
    public ResourceManagerNotInitializedException(string message) : base(message) { }
    public ResourceManagerNotInitializedException(string message, Exception inner) : base(message, inner) { }
    protected ResourceManagerNotInitializedException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}

[Serializable]
public class FileNotExistedException : ResLocationTargetNotExistedException
{
}

[Serializable]
public class FolderNotExistedException : ResLocationTargetNotExistedException
{
}


[Serializable]
public class ResLocationTargetNotExistedException : Exception
{
    public ResLocationTargetNotExistedException() { }
    public ResLocationTargetNotExistedException(string message) : base(message) { }
    public ResLocationTargetNotExistedException(string message, Exception inner) : base(message, inner) { }
    protected ResLocationTargetNotExistedException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}