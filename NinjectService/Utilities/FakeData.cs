using System.Collections.Generic;
using NinjectService.Entities;

namespace NinjectService.Utilities
{
    public static class FakeData
    {
        public static List<Apple> Apples = new List<Apple>()
        {
            new Apple{AppleId = "1" ,AppleName = "red apple"},
            new Apple{AppleId = "2" ,AppleName = "blue apple"},
            new Apple{AppleId = "3" ,AppleName = "black apple"}
        };  
    }
}