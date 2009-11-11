#region License Information

/**********************************************************************************
Shared Source License for Cropper
Copyright 9/07/2004 Brian Scott
http://blogs.geekdojo.net/brian

This license governs use of the accompanying software ('Software'), and your
use of the Software constitutes acceptance of this license.

You may use the Software for any commercial or noncommercial purpose,
including distributing derivative works.

In return, we simply require that you agree:
1. Not to remove any copyright or other notices from the Software. 
2. That if you distribute the Software in source code form you do so only
   under this license (i.e. you must include a complete copy of this license
   with your distribution), and if you distribute the Software solely in
   object form you only do so under a license that complies with this
   license.
3. That the Software comes "as is", with no warranties. None whatsoever.
   This means no express, implied or statutory warranty, including without
   limitation, warranties of merchantability or fitness for a particular
   purpose or any warranty of title or non-infringement. Also, you must pass
   this disclaimer on whenever you distribute the Software or derivative
   works.
4. That no contributor to the Software will be liable for any of those types
   of damages known as indirect, special, consequential, or incidental
   related to the Software or this license, to the maximum extent the law
   permits, no matter what legal theory it�s based on. Also, you must pass
   this limitation of liability on whenever you distribute the Software or
   derivative works.
5. That if you sue anyone over patents that you think may apply to the
   Software for a person's use of the Software, your license to the Software
   ends automatically.
6. That the patent rights, if any, granted in this license only apply to the
   Software, not to any derivative works you make.
7. That the Software is subject to U.S. export jurisdiction at the time it
   is licensed to you, and it may be subject to additional export or import
   laws in other places.  You agree to comply with all such laws and
   regulations that may apply to the Software after delivery of the software
   to you.
8. That if you are an agency of the U.S. Government, (i) Software provided
   pursuant to a solicitation issued on or after December 1, 1995, is
   provided with the commercial license rights set forth in this license,
   and (ii) Software provided pursuant to a solicitation issued prior to
   December 1, 1995, is provided with �Restricted Rights� as set forth in
   FAR, 48 C.F.R. 52.227-14 (June 1987) or DFAR, 48 C.F.R. 252.227-7013
   (Oct 1988), as applicable.
9. That your rights under this License end automatically if you breach it in
   any way.
10.That all rights not expressly granted to you in this license are reserved.

**********************************************************************************/

#endregion

using NUnit.Framework;

namespace Fusion8.Cropper.Core
{
    [TestFixture]
    public class CropSizeTests
    {
        [Test]
        public void Width_is_0_by_default()
        {
            int expected = 0;

            CropSize size = new CropSize();

            Assert.AreEqual(expected, size.Width);
        }

        [Test]
        public void Height_is_0_by_default()
        {
            int expected = 0;

            CropSize size = new CropSize();

            Assert.AreEqual(expected, size.Height);
        }

        [Test]
        public void Width_property_is_not_altered()
        {
            int width = 119;

            CropSize size = new CropSize();
            size.Width = width;

            Assert.AreEqual(width, size.Width);
        }

        [Test]
        public void Height_property_is_not_altered()
        {
            int height = 104;

            CropSize size = new CropSize();
            size.Height = height;

            Assert.AreEqual(height, size.Height);
        }

        [Test]
        public void Constructor_parameters_are_not_altered()
        {
            int width = 119;
            int height = 104;

            CropSize size = new CropSize(width, height);

            Assert.AreEqual(width, size.Width);
            Assert.AreEqual(height, size.Height);
        }

        [Test]
        public void ToString_returns_width_x_height()
        {
            int width = 119;
            int height = 104;
            string expected = width + " x " + height;

            CropSize size = new CropSize(width, height);

            Assert.AreEqual(expected, size.ToString());
        }

        [Test]
        public void Two_CropSize_are_not_equal_if_Width_differs()
        {
            int height = 104;

            CropSize left = new CropSize(0, height);
            CropSize right = new CropSize(1, height);

            Assert.IsFalse(left.Equals(right));
            Assert.IsFalse(left.Equals((object)right));
        }

        [Test]
        public void Two_CropSize_are_not_equal_if_Height_differs()
        {
            int width = 119;

            CropSize left = new CropSize(width, 0);
            CropSize right = new CropSize(width, 1);

            Assert.IsFalse(left.Equals(right));
            Assert.IsFalse(left.Equals((object)right));
        }

        [Test]
        public void Two_CropSize_are_equal_if_Width_and_Height_match()
        {
            int width = 119;
            int height = 104;

            CropSize left = new CropSize(width, height);
            CropSize right = new CropSize(width, height);

            Assert.IsTrue(left.Equals(right));
            Assert.IsTrue(left.Equals((object)right));
        }

        [Test]
        public void CompareTo_uses_Width()
        {
            int expected = -1;
            int height = 104;

            CropSize left = new CropSize(0, height);
            CropSize right = new CropSize(1, height);

            Assert.AreEqual(expected, left.CompareTo(right));
        }

        [Test]
        public void CompareTo_uses_Height()
        {
            int expected = -1;
            int width = 119;

            CropSize left = new CropSize(width, 0);
            CropSize right = new CropSize(width, 1);

            Assert.AreEqual(expected, left.CompareTo(right));
        }

        [Test]
        public void Two_CropSize_CompareTo()
        {
            int expected = 0;
            int width = 119;
            int height = 104;

            CropSize left = new CropSize(width, height);
            CropSize right = new CropSize(width, height);

            Assert.AreEqual(expected, left.CompareTo(right));
        }

        [Test]
        public void Evaluating_equals_returns_false_if_the_object_is_not_a_CropSize()
        {
            CropSize size = new CropSize();
            object obj = new object();

            Assert.IsFalse(size.Equals(obj));
        }

        [Test]
        public void GetHashCode_uses_Width_and_Height()
        {
            int width = 119;
            int height = 104;
            int expected = width + 29 * height;

            CropSize size = new CropSize(width, height);

            Assert.AreEqual(expected, size.GetHashCode());
        }
    }
}