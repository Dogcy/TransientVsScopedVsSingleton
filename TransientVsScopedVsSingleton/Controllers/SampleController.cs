using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TransientVsScopedVsSingleton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly SampleScoped _scoped2;
        private readonly SampleSingleton _singleton2;
        private readonly SampleTransient _transient2;

        private readonly SampleScoped _scoped;
        private readonly SampleSingleton _singleton;
        private readonly SampleTransient _transient;
        private readonly TestDiService _testDi;
        public SampleController(
            SampleScoped scpoed,
            SampleScoped scpoed2,
            SampleSingleton singleton,
           SampleSingleton singleton2,
            SampleTransient transient,
            SampleTransient transient2,
            TestDiService testDi)
        {
            _scoped = scpoed;
            _scoped2 = scpoed2;
            _singleton = singleton;
            _singleton2 = singleton2;
            _transient = transient;
            _transient2 = transient2;
            _testDi = testDi;



        }
        [HttpGet]
        public IActionResult GetTest()
        {
            _testDi.run();
            _transient.CountAdd1();    //此註解則沒有transient的guid    與上面_testDi也是分開的_transient
            _transient2.CountAdd1();
            _scoped.CountAdd1();  //可以觀察 發一次的requset 裡面 guid會是同一個
            _scoped2.CountAdd1();
            _singleton.CountAdd1();
            var result = new
            {
                transient = _transient._count+"--"+_transient._guid, // 與testDI裡的transient 跟   _transient2 都是不同個實體
                transient2 = _transient2._count + "--" + _transient2._guid,   
                scoped = _scoped._count + "--" + _scoped._guid, // 與_testDI裡的scoped  和scoped2為同一個實體(僅限一次requset)
                scoped2 = _scoped2._count + "--" + _scoped2._guid,  
                singleton = _singleton._count + "--" + _singleton._guid, // 持續同一個
                singleton2 = _singleton2._count + "--" + _singleton2._guid,



            };
            return Ok(result);
        }
    }
}
