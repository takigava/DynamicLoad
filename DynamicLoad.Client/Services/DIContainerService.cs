namespace DynamicLoad.Client.Services
{
    public class DIContainerService
    {
        public IServiceCollection Services { get; private set; }
        public IServiceProvider Provider { get { return Services.BuildServiceProvider(); } }

        public DIContainerService(IServiceCollection services)
        {
            this.Services = services;
        }
    }
}
