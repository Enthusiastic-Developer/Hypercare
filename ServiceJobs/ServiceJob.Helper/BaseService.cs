using ServiceJob.Interfaces;

namespace ServiceJob.Helper
{
    public abstract class BaseService : IService
    {
        public abstract bool StartProcess(string[] args);
    }
}
