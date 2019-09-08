using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BulletClassLibrary;

namespace BulletTests
{
    [TestClass]
    public class UnitTest2
    {
        Hitbox hitbox = new Hitbox(100, 100, new Point(50, 50));

        [TestMethod]
        public void TestMethod1()
        {
            Point point = new Point(99, 80);
            bool hit = false;

            var corners = checkCorner(point);

            if (point.Y < hitbox.topL.Y || point.Y > hitbox.botL.Y || point.X < hitbox.midTopL.X || point.X > hitbox.midTopR.X)
                hit = false;

            else if (pointInTriangle(point, corners[0], corners[1], corners[2]))
                hit = false;
            else hit = true;

            bool expected = false;
            Assert.AreEqual(expected, hit);
        }

        private List<Point> checkCorner(Point point)
        {
            if (point.X > hitbox.position.X && point.Y < hitbox.position.Y)
                return new List<Point> { new Point(hitbox.midTopR.X, hitbox.topR.Y), hitbox.topR, hitbox.midTopR };
            if (point.X > hitbox.position.X && point.Y > hitbox.position.Y)
                return new List<Point>() { new Point(hitbox.midTopR.X, hitbox.botR.Y), hitbox.botR, hitbox.midBotR };
            if (point.X < hitbox.position.X && point.Y > hitbox.position.Y)
                return new List<Point>() { new Point(hitbox.midBotL.X, hitbox.botR.Y), hitbox.botL, hitbox.midBotL };
            return new List<Point>() { new Point(hitbox.midBotL.X, hitbox.topR.Y), hitbox.topL, hitbox.midTopL };
        }

        private bool pointInTriangle(Point check, Point corner1, Point corner2, Point corner3)
        {
            double first, second, third;
            bool hasNeg, hasPos;

            first = sign(check, corner1, corner2);
            second = sign(check, corner2, corner3);
            third = sign(check, corner3, corner1);

            hasNeg = (first < 0) || (second < 0) || (third < 0);
            hasPos = (first > 0) || (second > 0) || (third > 0);

            return !(hasNeg && hasPos);
        }

        private double sign(Point check, Point corner1, Point corner2)
        {
            return (check.X - corner2.X) * (corner1.Y - corner2.Y) - (corner1.X - corner2.X) * (check.Y - corner2.Y);
        }
    }
}
