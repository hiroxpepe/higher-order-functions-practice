
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HOFPractice.Tests {
    [TestClass()]
    public class ExtensionsTests {

        [TestMethod()]
        public void EachTest1() {
            var _target = new[] { 3, 2, 9, 6 };
            var _expected = new[] { 6, 4, 18, 12 };
            var _result = new int[_target.Length];
            var _idx = 0;
            _target.Each(x => _result[_idx++] = x * 2);
            CollectionAssert.AreEqual(_result, _expected);
        }

        [TestMethod()]
        public void MapTest1() {
            var _target = new[] { 3, 2, 9, 6 };
            var _expected = new[] { 6, 4, 18, 12 };
            var _result = _target.Map(x => x * 2).ToArray();
            CollectionAssert.AreEqual(_result, _expected);
        }

        [TestMethod()]
        public void FilterTest1() {
            var _target = new[] { 3, 2, 9, 6 };
            var _expected = new[] { 3, 9 };
            var _result = _target.Where(x => x % 2 == 1).ToArray();
            CollectionAssert.AreEqual(_result, _expected);
        }

        [TestMethod()]
        public void SortTest1() {
            var _target = new[] {
                new { P = 3},
                new { P = 2},
                new { P = 9},
                new { P = 6}
            };
            var _expected = new[] {
                new { P = 2},
                new { P = 3},
                new { P = 6},
                new { P = 9}
            };
            var _result = _target.Sort(x => x.P).ToArray();
            CollectionAssert.AreEqual(_result, _expected);
        }

        [TestMethod()]
        public void FoldTest1() {
            var _target = new[] { 3, 2, 9, 6 };
            var _expected = 20;
            var _result = _target.Fold((x, y) => x + y);
            Assert.AreEqual(_result, _expected);
        }
    }
}