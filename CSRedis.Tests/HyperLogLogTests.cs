﻿using CSRedis.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSRedis.Tests
{
    [TestClass]
    public class HyperLogLogTests
    {
        [TestMethod, TestCategory("HyperLogLog")]
        public void PfAddTest()
        {
            using (var mock = new MockConnector("MockHost", 9999, ":1\r\n"))
            using (var redis = new RedisClient(mock))
            {
                Assert.IsTrue(redis.PfAdd("test", "test1", "test2"));
                Assert.AreEqual("*4\r\n$5\r\nPFADD\r\n$4\r\ntest\r\n$5\r\ntest1\r\n$5\r\ntest2\r\n", mock.GetMessage());
            }
        }

        [TestMethod, TestCategory("HyperLogLog")]
        public void PfCountTest()
        {
            using (var mock = new MockConnector("MockHost", 9999, ":2\r\n"))
            using (var redis = new RedisClient(mock))
            {
                Assert.AreEqual(2, redis.PfCount("test1", "test2"));
                Assert.AreEqual("*3\r\n$7\r\nPFCOUNT\r\n$5\r\ntest1\r\n$5\r\ntest2\r\n", mock.GetMessage());
            }
        }

        [TestMethod, TestCategory("HyperLogLog")]
        public void PfMergeTest()
        {
            using (var mock = new MockConnector("MockHost", 9999, "+OK\r\n"))
            using (var redis = new RedisClient(mock))
            {
                Assert.AreEqual("OK", redis.PfMerge("destination", "source1", "source2"));
                Assert.AreEqual("*4\r\n$7\r\nPFMERGE\r\n$11\r\ndestination\r\n$7\r\nsource1\r\n$7\r\nsource2\r\n", mock.GetMessage());
            }
        }
    }
}
