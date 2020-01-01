using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Input;
using System.Collections.Generic;
using UserInput;

namespace BulletTests
{
    [TestClass]
    public class InputTests
    {
        [TestMethod]
        public void UserKeyConstructorTest()
        {
            var key1 = new UserKey(Key.A);
            var key2 = new UserKey(Key.D3);
            var key3 = new UserKey(Key.Enter);

            var expected = new List<string>() { "A", "#", "Enter", "True" };
            var actual = new List<string>() { key1.Secondary, key2.Secondary, key3.Primary, key3.WasUpdated.ToString() };
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
