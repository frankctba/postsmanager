namespace PostsManager.PostsApi
{
    public class SingletonTest
    {
        private static SingletonTest instance = null;
        private static readonly object lockObject = new object();

        private SingletonTest()
        {
        }

        public static SingletonTest Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new SingletonTest();
                    }
                    return instance;
                }
            }
        }
    }
}
