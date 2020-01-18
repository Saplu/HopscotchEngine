using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Input;
using System.Collections.Generic;
using UserInput;
using CollectionAssert = Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert;
using System.Linq;

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

        [TestMethod]
        public void KeyboardProofOfConcept()
        {
            var pressedKeys = new List<UserKey>() { new UserKey(Key.A), new UserKey(Key.B) };
            pressedKeys = update(40, pressedKeys);
            pressedKeys = update(40, pressedKeys);

            var expected = new List<UserKey>();
            var key1 = new UserKey(Key.B);
            key1.Update(80);
            var key2 = new UserKey(Key.C);
            key2.Update(40);
            expected.Add(key1);
            expected.Add(key2);

            CollectionAssert.AreEqual(expected, pressedKeys);
        }

        private List<UserKey> update(int milliseconds, List<UserKey> keys)
        {
            keys.ForEach(item => item.WasUpdated = false);
            AddOrUpdate(Key.B, milliseconds, keys);
            AddOrUpdate(Key.C, milliseconds, keys);

            var newList = from Key in keys
                          where Key.WasUpdated == true
                          select Key;
            keys = newList.ToList();
            return keys;
        }

        private List<UserKey> AddOrUpdate(Key key, int milliseconds, List<UserKey> keys)
        {
            var newKey = new UserKey(key);
            var existingKey = keys.FirstOrDefault(x => x.Equals(newKey));
            if (existingKey != null)
            {
                existingKey.Update(milliseconds);
            }
            else keys.Add(newKey);
            return keys;
        }
    }
}
