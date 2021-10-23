namespace TransientVsScopedVsSingleton
{
    public interface ISample
    {
        int Id { get; }
    }

    public interface ISampleTransient : ISample
    {
    }

    public interface ISampleScoped : ISample
    {
    }

    public interface ISampleSingleton : ISample
    {
    }

    //public class SampleTransient : ISampleTransient
    //{
    //    private static int T_counter;
    //    private int _id;

    //    public SampleTransient()
    //    {
    //        _id = ++T_counter;
    //    }

    //    public int Id => _id;
    //}
    //public class SampleScoped : ISampleScoped
    //{
    //    private static int S_counter;
    //    private int _id;

    //    public SampleScoped()
    //    {
    //        _id = ++S_counter;
    //    }

    //    public int Id => _id;
    //}
    //public class SampleSingleton : ISampleSingleton
    //{
    //    private static int _counter;
    //    private int _id;

    //    public SampleSingleton()
    //    {
    //        _id = ++_counter;
    //    }

    //    public int Id => _id;
    //}
}
