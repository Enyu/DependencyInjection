using System.Collections.Generic;
using System.Linq;
using NinjectService.Entities;
using NinjectService.Utilities;

namespace NinjectService.Repositories
{
    public class ApplesRepository
    {
        private readonly List<Apple> _apples = FakeData.Apples;

        public List<Apple> ListAll()
        {
            return _apples;
        }

        public Apple GetById(string id)
        {
            return _apples.FirstOrDefault(apple => apple.AppleId == id);
        }
    }
}