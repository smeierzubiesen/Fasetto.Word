namespace Fasetto.Word.Core
{
    using Ninject;
    
    /// <summary>
    /// The IoC Conatiner for our application
    /// </summary>
    public static class IoC
    {
        /// <summary>
        /// The Kernel for the IoC Container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// Sets up the IoC container, binds all information required and is ready for use
        /// NOTE: Must be called as soons as your application starts up to ensure all
        ///        services/data can be found
        /// </summary>
        public static void Setup()
        {
            //Bind all required viewmodels
            BindViewModels();
        }

        /// <summary>
        /// Binds all singelton view models
        /// </summary>
        private static void BindViewModels()
        {
            //Bind to a single instance of ApplicatonViewModel
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }

        /// <summary>
        /// Gets a service from the IoC, of the specified type
        /// </summary>
        /// <typeparam name="T">The type to get</typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
