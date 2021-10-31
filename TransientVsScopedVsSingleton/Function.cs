using System;

namespace TransientVsScopedVsSingleton
{
    public class SampleTransient
    {
        public int _count = 0;
        public Guid _guid;
        public void CountAdd1()
        {
            _count = _count + 1;
            _guid = Guid.NewGuid();
        }
    }
    public class SampleScoped
    {
        public int _count = 0;
        public Guid _guid = Guid.Empty;
        public void CountAdd1()
        {
            _count = _count + 1;
            _guid = Guid.NewGuid();
        }
    }
    public class SampleSingleton
    {
        public int _count = 0;
        public Guid _guid = Guid.Empty;
        public void CountAdd1()
        {
            _count = _count + 1;
            _guid = Guid.NewGuid();
        }
    }
    public class TestDiService
    {
        private readonly SampleScoped _scoped;
        private readonly SampleSingleton _singleton;
        private readonly SampleTransient _transient;
        public TestDiService(SampleScoped scpoed, SampleSingleton singleton, SampleTransient transient)
        {
            _scoped = scpoed;
            _singleton = singleton;
            _transient = transient;
        }

        public void run()
        {
            _scoped.CountAdd1();
            _singleton.CountAdd1();
            _transient.CountAdd1();
        }
    }
     public interface IFuncDemo
    {
        public string Demo();
    }
    public class Func1 : IFuncDemo
    {
        public string Demo()
        {
            return "1";
        }
    }
    public class Func2 : IFuncDemo
    {
        public string Demo()
        {
            return "2";
        }
    }
}
